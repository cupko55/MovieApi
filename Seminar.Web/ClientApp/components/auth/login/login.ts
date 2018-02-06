import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';
import Errors from '../../../error';

@Component
export default class Login extends Vue {
    email: string = '';
    password: string = '';
    errors= new Errors();

    onSubmit() {
        axios.post('api/Account/Login',{
            email: this.email,
            password: this.password,
        })
        .then(response => this.onSuccess(response.data))
        .catch((error) => {
            if(error.response.status == 401){
                alert("Nepostojeća kombinacija emaila i passworda");
            }
            else{
                this.errors.record(error.response.data);
            }
        });
    }

    onSuccess(data:string){                
        sessionStorage.setItem('token', data);
        window.location.href = '/';
    }
}
