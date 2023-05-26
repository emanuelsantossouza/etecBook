import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  registerForm!: FormGroup;

  constructor(private fb: FormBuilder){

  }

  ngOnInit():void{
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', Validators.compose([ Validators.required, Validators.email])],
      password: [ '', Validators.compose([Validators.required, Validators.minLength(8)])]
    })
  }

  get f(){
    return this.registerForm.controls;
  }

  CheckName(){
    return this.f[`name`].dirty && this.f[`name`].errors?.[`required`];
  }

  CheckEmail(){
    return this.f[`email`].dirty && this.f[`email`].errors?.[`required`];
  }

  CheckEmailValid(){
    return this.f[`email`].dirty && this.f[`email`].errors?.[`required`];
  }


}
