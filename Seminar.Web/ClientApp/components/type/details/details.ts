import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface Type{
    id: number;
    name: string;
    description: string;
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
    type = <Type>{};

    mounted(){        
        axios.get('api/Type/' + this.$route.params.id, {
                headers:{
                    'Api-Version': '1.0',                    
                }
            })            
            .then(response => this.type = response.data);        
    }
}