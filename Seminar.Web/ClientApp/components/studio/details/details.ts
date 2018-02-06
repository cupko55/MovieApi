import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface Studio{
    id: number;
    name: string;
    country: string;
    movies: Movie    
}
interface Movie{
    id: number;
    name: string;
    description: string;
    rating: number;
    nominationsCount: number;
    nominationsWin: number;
}

@Component
export default class StudioDetails extends Vue{
    studio = <Studio>{};

    mounted(){        
        axios.get('api/Studio/' + this.$route.params.id)            
            .then(response => this.studio = response.data);        
    }
}