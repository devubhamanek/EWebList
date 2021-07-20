import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  public currentUser: User = new User;

  data :any;
  constructor(private router: Router, private authenticationService: AuthenticationService) 
  { 
      

  }

  ngOnInit(){
    this.data = JSON.parse(localStorage.getItem('socialusers')|| '{}');       
    if (this.data.Result != undefined) {
      
      this.currentUser.firstName = this.data.Result.FirstName;
      this.currentUser.lastName = this.data.Result.LastName;
    }
  }
  logout() {    
    localStorage.clear();    
      this.router.navigate([`/login`]);  
    
}
}
