import { Component, OnInit } from '@angular/core';
import {Form, FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {User} from '../../models/user';
import {UserService} from '../../service/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  editProfile: FormGroup;
  isInProgress: boolean;
  isSavingFailed: boolean;

  user: User;

  newImageFile: File;

  constructor(private router: Router,
              private formBuilder: FormBuilder,
              private userService: UserService) {
    this.isInProgress = true;
    this.user = {
      userName: '',
      email: ''
    };
  }

  ngOnInit(): void {
    this.editProfile = this.formBuilder.group({
      email: '',
      phoneNumber: ''
    });

    this.userService.getUserInfo()
      .subscribe(usr => {
        this.user = usr;

        this.editProfile = this.formBuilder.group({
          email: [usr.email, Validators.required],
          phoneNumber: [usr.phoneNumber, Validators.required]
        });

        this.isInProgress = false;
      });
  }

  onFileChanged(event: Event): void {
    this.newImageFile = event.target.files[0]; // pick the image
  }

  uploadPhoto(): void {
    this.isInProgress = true;

    const uploadData: FormData = new FormData();
    uploadData.append('formFile', this.newImageFile, this.newImageFile.name);

    this.userService.uploadUserPhoto(uploadData)
      .subscribe(res => {
        this.isInProgress = false;

        if (res !== undefined) {
          this.router.navigateByUrl('');
        }
        else {
          this.isSavingFailed = true; // show error msg
        }
      });
  }

  saveChanges(): void {
    const val = this.editProfile.value;

    if (val.email && val.phoneNumber && !this.isInProgress)
    {
      this.isInProgress = true;

      this.user.email = val.email;
      this.user.phoneNumber = val.phoneNumber;

      this.userService.updateUserInfo(this.user)
        .subscribe(res => {
          this.isInProgress = false;

          if (res !== undefined) {
            this.router.navigateByUrl('');
          }
          else {
            this.isSavingFailed = true; // show error msg
          }
        });

    }
  }

}
