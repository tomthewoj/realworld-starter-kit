import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

interface CreateUserCommand {
  username: string;
  password: string;
  email: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './register.html',
  styleUrl: './register.css'
})

export class RegisterComponent {
  username: string = '';
  password: string = '';
  email: string = '';

  private apiUrl = 'https://localhost:7088/User/SignUp'; //toss Into environment
  constructor(private http: HttpClient, private router: Router) { }


  Register() {
    const user: CreateUserCommand =
    {
      username: this.username,
      password: this.password,
      email: this.email
    }
    this.addUser(user).subscribe({

      next: (response) => {
        console.log('User added successfully', response);
        // Navigate to the next page upon successful login
        //this.router.navigate(['/next-page']); // Replace with your route
      },
      error: (error) => {
        console.error('There was an error adding the user!', error);
      }
    });
  }
  addUser(user: CreateUserCommand): Observable<any> {
    console.log('Username:', this.username);
    return this.http.post(this.apiUrl, user);
  }
}
