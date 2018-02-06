import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface LeadingActor{
    id: number;
    firstName: string;
    lastName: string;    
}

@Component
export default class LeadingActorsIndex extends Vue{
    actors: LeadingActor[] = [];

    mounted(){
        this.onLoad();
    }

    onLoad(){
        axios.get('api/LeadingActor',)
            .then(response => this.actors = response.data);
    }

    onDelete(id:number){
        axios.delete('api/LeadingActor/' + id, {
                headers:{
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + sessionStorage.getItem('token')
                }
            })
            .then(this.onSuccess)
            .catch((error) => {
                if(error.response.status == 401)
                    alert("Morate biti prijavljeni");
            });
    }

    onSuccess(){
        alert("Glumac je obrisan");
        this.onLoad();
    }
}