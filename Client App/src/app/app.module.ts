import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from '././components/login/login.component';
import { DashboardComponent } from '././components/dashboard/dashboard.component';
import { HeaderComponent } from '././components/header/header.component';
import { FooterComponent } from '././components/footer/footer.component';
import { SidebarComponent } from '././components/sidebar/sidebar.component';
import { SocialLoginModule, SocialAuthServiceConfig } from 'angularx-social-login';
import {
  GoogleLoginProvider,
  FacebookLoginProvider
} from 'angularx-social-login';
import { AuthenticationService } from './services/authentication.service';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ChatPopupComponent } from './components/chat-popup/chat-popup.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    ChatPopupComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,  
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SocialLoginModule,
  ],
  providers: [AuthenticationService,{
    provide: 'SocialAuthServiceConfig',
    useValue: {
      autoLogin: false,
      providers: [
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider('304581212733-2bf910hhut8tdjmqog1ab8ooj7ja50u9.apps.googleusercontent.com')
        },
        {
          id: FacebookLoginProvider.PROVIDER_ID,
          provider: new FacebookLoginProvider("460231375003008")
        }
      ]
    } as SocialAuthServiceConfig,
  }],


  entryComponents: [LoginComponent, HeaderComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
