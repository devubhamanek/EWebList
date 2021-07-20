import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
import { SocialAuthService } from "angularx-social-login";
import { Socialusers } from 'src/app/models/socialusers';
import { User } from 'src/app/models/user';
import { AuthenticationService } from 'src/app/services/authentication.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public ShowSpinner: boolean = false;
  loginForm!: FormGroup;
  password_type = 'password';
  authData: any;

  response:any;  
  socialusers=new Socialusers();  

  constructor(private formBuilder: FormBuilder,
    private router: Router, private authService: SocialAuthService, private authenticationService: AuthenticationService) {

  }

  ngOnInit(): void {
    // this.checkLogin();
    this.loginForm = this.formBuilder.group({
      //email: ['', [Validators.required, Validators.email]],
      email: new FormControl('', Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$'),
        Validators.email,
        Validators.maxLength(100)
      ])),
      password: ['', Validators.compose([
        //Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z0-9$@$!%*?&]+$'),
        Validators.required
      ])],
    });
  }
  changePasswordType() {
    this.password_type = this.password_type === 'text' ? 'password' : 'text';
  }


  public socialSignIn(socialProvider: string) { 
    if (socialProvider === 'facebook') {        
      this.authService.signIn(FacebookLoginProvider.PROVIDER_ID).then(response => {  
        console.log(response); 
        return this.signInWithFacebook(response);        
      });  

    } else if (socialProvider === 'google') {            
      this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then(res => {   
        return this.signInWithGoogle(res);
      });  
    }  

  }
  
  signInWithFacebook(socialusers: Socialusers) { 
    this.ShowSpinner = true;
    this.authenticationService.signInWithFacebook(socialusers).subscribe((res: any) => {  
      this.socialusers=res;  
      this.response = res.userDetail;  
      localStorage.setItem('socialusers', JSON.stringify( this.socialusers));
      this.router.navigate([`/Dashboard`]);  
      this.ShowSpinner = false;
    })  
  }  

  signInWithGoogle(socialusers: Socialusers) {  
    this.ShowSpinner = true;
    this.authenticationService.signInWithGoogle(socialusers).subscribe((res: any) => {  
      this.socialusers=res;  
      this.response = res.userDetail;  
      localStorage.setItem('socialusers', JSON.stringify( this.socialusers));
      this.router.navigate([`/Dashboard`]);  
      this.ShowSpinner = false;
    })  
  }  

  
 
  

  // signInWithGoogle(): void {
  //   this.ShowSpinner = true;
  //   console.log("call Google ..")
  //   this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then(res => {
  //     this.authData = {
  //       email: res.email,
  //       firstName: res.firstName,
  //       lastName: res.lastName,
  //     }         
  //     this.authenticationService.loginWithGoogle(this.authData).subscribe(gUser => {

  //       if (gUser.Result.registrationStatus == "registered") {
  //         location.reload();
  //       }
  //       else if (gUser.Result.registrationStatus == "in_proccess") {
  //         location.reload();
  //       }
  //       else {
  //         location.reload();
  //       }
  //       this.ShowSpinner = false;
  //     })
  //   }, error => {
  //     console.log(error);
  //     this.ShowSpinner = false;
  //   });
  // }

  // signInWithFacebook(): void {
  //   this.ShowSpinner = true;
  //   console.log("call Facebook ..")
    // this.authService.signIn(FacebookLoginProvider.PROVIDER_ID).then(res => {
    //   // console.log('F_res', res)
    //   this.authData = {
    //     email: res.email
    //   }
    // })
  // }

  // signOut(): void {
  //   this.authService.signOut();
  // }

 // check user logged or not
//  checkLogin() {
//    debugger
//   if (this.authenticationService.currentUserValue) {
//     if (this.authenticationService.currentUserValue.roleID == 1) {
//       this.router.navigate(['/admin/admin-events']);
//     }
//     else if (this.authenticationService.currentUserValue.roleID == 2) {
//       this.router.navigate(['/dashboard']);
//     }
//   }
  // else if(this.authenticationService.currentUserValue.roleID==1) {
  //   this.router.navigate(['/admin/event-attendees/66']);
  // }
// }



  onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }
  }
}
