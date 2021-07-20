import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '././components/dashboard/dashboard.component';
import { LoginComponent } from '././components/login/login.component';

const routes: Routes =
  [
    {
      path: '', pathMatch: 'full', redirectTo: '/login'
    },
    {
      path: 'Dashboard', component: DashboardComponent, data: { title: 'Dashboard' }
    },
    {
      path: 'login', component: LoginComponent, data: { title: 'Login' }
    },
    
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

  

 }
