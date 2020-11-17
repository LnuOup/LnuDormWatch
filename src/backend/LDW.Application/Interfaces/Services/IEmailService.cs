using LDW.Domain.Common;
using LDW.Domain.Entities.Options;
using System.Threading.Tasks;

namespace LDW.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task<OperationResult> SendVerificationEmail(string userName, string url, SmtpOptions config);
    }
}
