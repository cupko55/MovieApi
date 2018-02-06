import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface LeadingActor{
    id: number;
    firstName: string;
    lastName: string;
    price: number;
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
export default class TypeDetails extends Vue{
    actor = <LeadingActor>{};

    mounted(){        
        axios.get('api/LeadingActor/' + this.$route.params.id)            
            .then(response => this.actor = response.data);        
    }
}