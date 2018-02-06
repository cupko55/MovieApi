import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';
import Errors from '../../../error';

class Type{
    id: number;
    name: string;
    description: string;    
}

class LeadingActor{
    id: number;
    firstName: string;
    lastName: string;    
}

class Studio{
    id: number;
    name: string;
    country: string;
}

@Component
export default class MovieCreate extends Vue {
    name: string = '';
    description: string = '';
    rating: number = 0;
    nominationsCount: number = 0;
    nominationsWin: number = 0;
    leadingActorIDs = new Array<number>();
    typeIDs = new Array<number>();    
    studioId: number = 0;
    errors = new Errors();
    types = new Array<Type>();
    actors = new Array<LeadingActor>();
    studios = new Array<Studio>();

    mounted(){        
        axios.get('api/LeadingActor/')                    
            .then(response => this.actors = response.data);        

        axios.get('api/Type/')            
            .then(response => this.types = response.data);         

        axios.get('api/Studio/')            
            .then(response => this.studios = response.data);         
    }

    onSubmit() {
        axios.post('api/Movie',this.$data, {
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
        alert("Film je uspjesno spremljen");
        window.location.href = '/';
    }
}
