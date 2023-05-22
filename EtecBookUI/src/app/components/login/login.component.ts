import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginForm!: FormGroup;

  constructor(private fb: FormBuilder){}


  ngOnInit():void{
    this.loginForm = this.fb.group({
      email:['', Validators.required],
      senha:['', Validators.compose, Validators.min(6)]
    });
  }
  login(){

  }
}
