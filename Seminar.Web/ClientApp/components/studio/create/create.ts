import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';
import Errors from '../../../error';

@Component
export default class StudioCreate extends Vue {
    name: string = '';
    country: string = '';
    errors= new Errors();

    onSubmit() {
        axios.post('api/Studio',this.$data, {
                headers:{
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + sessionStorage.getItem('token')
                }
            })
            .then(this.onSuccess)
            .catch((error) => {
                if(error.response.status == 401)
                {
                    alert("Morate biti prijavljeni");
                }
                else{
                    this.errors.record(error.response.data)
                }
            });
    }

    onSuccess(){
        window.location.href = '/studios';
    }
}
