import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

@Component
export default class Navmenu extends Vue{
    data(){
        return{
            token: sessionStorage.getItem('token')
        }
    }
}