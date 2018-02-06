import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface Type{
    id: number;
    name: string;
    description: string;    
}
interface LeadingActor{
    id: number;
    firstName: string;
    lastName: string;    
}
interface Studio{
    id: number;
    name: string;    
}
interface Movie{
    id: number;
    name: string;
    description: string;
    rating: number;
    nominationsCount: number;
    nominationsWin: number;
    types: Type;
    leadingActors: LeadingActor
    studio:Studio;
}

@Component
export default class MovieDetails extends Vue{
    movie = <Movie>{};

    mounted(){        
        axios.get('api/Movie/' + this.$route.params.id)            
            .then(response => this.movie = response.data);
        
    }
}