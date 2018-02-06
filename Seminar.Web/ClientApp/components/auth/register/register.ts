import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';
import Errors from '../../../error';

@Component
export default class Register extends Vue {
    email: string = '';
    password: string = '';
    phone: string = '';
    errors= new Errors();

    onSubmit() {
        axios.post('api/Account/Register',{
            email: this.email,
            password: this.password,
            phone: this.phone,
        })
        .then(response => this.onSuccess(response.data))
        .catch((error) => {
            if(error.response.status == 401){
                alert("Nesto je poslo po krivu");
            }
            else{
                alert("Nesto je poslo po krivu");
            }
        });
    }

    onSuccess(data:string){                
        sessionStorage.setItem('token', data);
        window.location.href = '/';
    }
}
