import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface Movie{
    id: number;
    name: string;
    description: string;
    rating: number;
    nominationsCount: number;
    nominationsWin: number;
}

@Component
export default class MovieIndex extends Vue{
    movies: Movie[] = [];

    mounted(){
        this.onLoad();
    }

    onLoad()
    {
        axios.get('api/Movie')
            .then(response => this.movies = response.data);
    }

    onDelete(id:number){
        axios.delete('api/Movie/' + id, {
                headers:{
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + sessionStorage.getItem('token')
                }
            })
            .then(this.onSuccess)
            .catch((error) =>{
                if(error.response.status == 401)
                {
                    alert("Morate biti prijavljeni");
                }
            });
    }

    onSuccess(){
        alert("Film je obrisan");
        this.onLoad();
    }
}