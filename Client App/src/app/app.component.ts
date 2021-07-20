import { Component } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'DemoDotNet';
  page: boolean = true 
  constructor(private router: Router, private route: ActivatedRoute) {
    
    this.router.events.subscribe(
      (event: any) => {
        if (event instanceof NavigationEnd) {
          // console.log('this.router.url', this.router.url);

          if (this.router.url === '/login') {
            this.page = false
               
          } 
          else{
            this.page = true
          }

        }
      }
    );

  }
  
}
