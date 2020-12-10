﻿using LDW.Application.Features.UserFeatures.Commands;
using LDW.Application.Features.UserFeatures.Queries;
using LDW.Application.Interfaces.Services;
using LDW.Application.Models;
using LDW.Domain.Common;
using LDW.Domain.Entities.Options;
using LDW.Domain.Resources;
using LDW.WebAPI.Controllers.v1.Base;
using LDW.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;

namespace LDW.WebAPI.Controllers.v1
{
    [Authorize]
    public class UserController : BaseV1Controller
    {

        private readonly AzureStorageOptions _azureStorageConfig;
        private readonly IImageService _imageService;

        public UserController(IOptions<AzureStorageOptions> azureStorageConfig,
                IImageService imageService)
        {
            _azureStorageConfig = azureStorageConfig.Value;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await Mediator.Send(new GetUserByIdQuery(User.Identity.Name));

            var response = new
            {
                user.UserName,
                user.Email,
                user.EmailConfirmed,
                user.PhoneNumber,
                user.PhotoUrl
            };

            return Ok(response);
        }


        [HttpPut]
        [Route("upload-user-photo")]
        public async Task<IActionResult> UploadUserPhoto( IFormFile formFile)
        {
            if (formFile == null)
            {
                return BadRequest(message: Translations.FILE_REQUIRED);
            }

            if (string.IsNullOrEmpty(_azureStorageConfig.AccountKey)
                || string.IsNullOrEmpty(_azureStorageConfig.AccountName))
            {
                return BadRequest(message: Translations.AzureAuthFailed);
            }

            if (string.IsNullOrEmpty(_azureStorageConfig.ImageContainer) ||
                string.IsNullOrEmpty(_azureStorageConfig.ThumbnailContainer))
            {
                return BadRequest(message: Translations.AzureImageContainerNotProvided);
            }

            string photoUrl = string.Empty;
            string compressedPhotoUrl = string.Empty;

            if (!ImageHelper.IsImage(formFile))
            {
                return new UnsupportedMediaTypeResult();
            }

            var fileName = formFile.FileName;
            var lastIndexOf = fileName.LastIndexOf('.');
            var type = fileName.Remove(0, lastIndexOf + 1);

            var ticks = DateTime.Now.Ticks;
            var photoName = $"{User.Identity.Name}_photo_{ticks}.{type}";
            var compressedPhotoName = $"{User.Identity.Name}_compressedPhoto_{ticks}.{type}";

            using (var stream = formFile.OpenReadStream())
            {
                var result = await _imageService.UploadFileToStorage(stream, photoName, _azureStorageConfig, false);
                if (!result.IsSuccess)
                {
                    return BadRequest(
                        message: Translations.AzureImageUploadFailed,
                        ex: result.Exception);
                }

                photoUrl = result.Value;
            }

            using (var stream = formFile.OpenReadStream())
            {
                var compressedPhotoStream = ImageHelper.CompressPhoto(stream, _azureStorageConfig.ImageMaxSize, type);
                OperationResult<string> result = null;
                using (compressedPhotoStream)
                {
                    result = await _imageService.UploadFileToStorage(compressedPhotoStream, compressedPhotoName, _azureStorageConfig, true);
                }

                if (result?.IsSuccess != true)
                {
                    return BadRequest(
                        message: Translations.AzureImageUploadFailed,
                        ex: result.Exception);
                }

                compressedPhotoUrl = result.Value;
            }

            var user = await Mediator.Send(new GetUserByIdQuery(User.Identity.Name));

            var userModel = new UserModel
            {
                UserName = user.UserName,
                PhotoUrl = photoUrl,
                CompressedPhotoUrl = compressedPhotoUrl,
                Email = user.Email
            };

            var updateResult = await Mediator.Send(new UpdateUserCommand(userModel));
            return Ok(updateResult);
        }


        [HttpPatch]
        [Route("update-user-info")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Mediator.Send(new UpdateUserCommand(userModel));

            return Ok(result);
        }
    }
}