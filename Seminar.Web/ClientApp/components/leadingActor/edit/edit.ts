import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';
import Errors from '../../../error';

interface LeadingActor{
    id: number;
    firstName: string;
    lastName: string;    
}


@Component
export default class TypeEdit extends Vue {
    actor = <LeadingActor>{};
    errors= new Errors();

    mounted(){        
        axios.get('api/LeadingActor/' + this.$route.params.id)            
            .then(response => this.actor = response.data);        
    }

    onSubmit() {
        axios.put('api/LeadingActor/' + this.$route.params.id, this.actor, {
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
        window.location.href = '/actors';
    }
}
