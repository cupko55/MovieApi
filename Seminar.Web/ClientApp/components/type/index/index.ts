import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface Type{
    id: number;
    name: string;
    description: string;    
}

@Component
export default class TypesIndex extends Vue{
    types: Type[] = [];    

    mounted(){
        this.onLoad();
    }

    onDelete(id:number){        
        axios.delete('api/Type/' + id, {
                headers:{
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + sessionStorage.getItem('token'),
                    'Api-Version': '1.0'
                }
            })
            .then(this.onSuccess)
            .catch((error) => {
                if(error.response.status == 401)
                    alert("Morate biti prijavljeni");
            });
    }

    onWrongDelete(id:number){
        axios.delete('api/Type/' + id, {
            headers:{
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem('token'),
                'Api-Version': '1.1'
            }
        })
        .then(this.onSuccess)
        .catch(error => console.log(error.response));
    }

    onLoad(){
        axios.get('api/Type')
            .then(response => this.types = response.data);
    }

    onSuccess(){
        alert('Žanr je obrisan');
        this.onLoad();
    }
}