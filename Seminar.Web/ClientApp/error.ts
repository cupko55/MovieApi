export default class Errors{
    errors= <any>{};

    constructor(){

    }

    get(field:string){        
        if(this.errors.hasOwnProperty(field)){            
            return (this.errors[field][0]);            
        }                
    }

    record(errors:{}){
        this.errors = errors;
    }

    clear(field:string){
        delete this.errors[field];
    }
}