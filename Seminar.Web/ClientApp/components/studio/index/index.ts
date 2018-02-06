import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface Studio{
    id: number;
    name: string;
    country: string;    
}

@Component
export default class TypesIndex extends Vue{
    studios: Studio[] = [];    

    mounted(){
        this.onLoad();
    }

    onDelete(id:number){        
        axios.delete('api/Studio/' + id, {
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

    onLoad(){
        axios.get('api/Studio')
            .then(response => this.studios = response.data);
    }

    onSuccess(){
        alert('Studio je obrisan');
        this.onLoad();
    }
}