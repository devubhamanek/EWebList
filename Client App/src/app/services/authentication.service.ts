import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { Socialusers } from '../models/socialusers';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    url: string = environment.Base_Url + '/User';    
    public currentUser: any;

    constructor(private http: HttpClient) {     
       
        
    }

   
    public get currentUserValue(): User {
        return JSON.parse(localStorage.getItem('currentUser') || '{}');
    }
    
    signInWithGoogle(responce:Socialusers)    {
       
        return this.http.post<any>(`${this.url}/AuthenticateByGoogle`, responce)
    }

    signInWithFacebook(responce:Socialusers)    {
       
        return this.http.post<any>(`${this.url}/AuthenticateByFacebook`, responce)
    }

    // loginWithGoogle(userData: User) {
    //     console.log('log',userData);
    //     return this.http.post<any>(`${this.url}/AuthenticateByGoogle`, userData)
    //         .pipe(map(userg => {  
                     
    //             // login successful if there's a jwt token in the response               
    //             if (userg && userg.token) {
    //                 userg.Result.userToken = userg.token;                    
    //                 // store user details and jwt token in local storage to keep user logged in between page refreshes
    //                 localStorage.setItem('currentUser', userg.Result);
    //                 //localStorage.setItem('token', user.token);                   
                   
    //             }

    //             return userg;
    //         }));
    // }

    // loginWithFacebook(userData: User) {
    //     return this.http.post<any>(`${this.url}/AuthenticateByFacebook`, userData)
    //         .pipe(map(userf => {
    //             // login successful if there's a jwt token in the response

    //             if (userf && userf.token) {
    //                 userf.data.userToken = userf.token;
    //                 //console.log(user);
    //                 // store user details and jwt token in local storage to keep user logged in between page refreshes
    //                 localStorage.setItem('currentUser', JSON.stringify(userf.data));
    //                 //localStorage.setItem('token', user.token);                   
                  
    //             }

    //             return userf;
    //         }));
    // }
}