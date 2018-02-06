import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';
import Errors from '../../../error';

interface Type{
    id: number;
    name: string;
    description: string;    
}


@Component
export default class TypeEdit extends Vue {
    type = <Type>{};
    errors= new Errors();

    mounted(){        
        axios.get('api/Type/' + this.$route.params.id)            
            .then(response => this.type = response.data);        
    }

    onSubmit() {
        axios.put('api/Type/' + this.$route.params.id, this.type, {
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
        window.location.href = '/types';
    }
}
