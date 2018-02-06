import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';
import Errors from '../../../error';

interface Studio{
    id: number;
    name: string;
    country: string;    
}


@Component
export default class StudioEdit extends Vue {
    studio = <Studio>{};
    errors= new Errors();

    mounted(){        
        axios.get('api/Studio/' + this.$route.params.id)            
            .then(response => this.studio = response.data);        
    }

    onSubmit() {
        axios.put('api/Studio/' + this.$route.params.id, this.studio, {
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
