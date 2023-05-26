import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';


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
      senha:['', Validators.compose([Validators.minLength(8), Validators.required])]
    })
  }

  login(){

  }

  checkSenha(){
    return this.loginForm.controls['email'].dirty && this.loginForm.hasError('required, email')
  }

  OnSubmit(){
    if(this.loginForm.value){
      // dispaarar a validação
      console.log(this.loginForm.value);
    } else{
      // disparar error
      this.validateAllFormFileds(this.loginForm)
    }
  }

  private validateAllFormFileds(formGroup : FormGroup){
    Object.keys(formGroup.controls).forEach(field =>{
      const control = formGroup.get(field);
        if( control instanceof FormControl){
          control.markAsDirty({ onlySelf: true})
        }else if( control instanceof FormGroup){
          this.validateAllFormFileds(control)
        } 
    })
  }
}
