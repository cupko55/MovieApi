import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

const routes = [
    //{ path: '/', component: require('./components/home/home.vue.html') },
    { path: '/', name: 'movies', component: require('./components/movie/index/index.vue.html') },
    { path: '/movies/details/:id', name: 'movieDetails', component: require('./components/movie/details/details.vue.html') },
    { path: '/movies/create', name: 'movieCreate', component: require('./components/movie/create/create.vue.html') },
    { path: '/movies/edit/:id', name: 'movieEdit', component: require('./components/movie/edit/edit.vue.html') },
    { path: '/actors', name: 'actors', component: require('./components/leadingActor/index/index.vue.html') },
    { path: '/actors/details/:id', name: 'actorDetails', component: require('./components/leadingActor/details/details.vue.html') },
    { path: '/actors/create', name: 'actorCreate', component: require('./components/leadingActor/create/create.vue.html') },
    { path: '/actors/edit/:id', name: 'actorEdit', component: require('./components/leadingActor/edit/edit.vue.html') },
    { path: '/types', name: 'types', component: require('./components/type/index/index.vue.html') },
    { path: '/types/details/:id', name: 'typeDetails', component: require('./components/type/details/details.vue.html') },
    { path: '/types/create', name: 'typeCreate', component: require('./components/type/create/create.vue.html') },
    { path: '/types/edit/:id', name: 'typeEdit', component: require('./components/type/edit/edit.vue.html') },
    { path: '/studios', name: 'studios', component: require('./components/studio/index/index.vue.html') },
    { path: '/studios/details/:id', name: 'studioDetails', component: require('./components/studio/details/details.vue.html') },
    { path: '/studios/create', name: 'studioCreate', component: require('./components/studio/create/create.vue.html') },
    { path: '/studios/edit/:id', name: 'studioEdit', component: require('./components/studio/edit/edit.vue.html') },
    { path: '/register', name: 'register', component: require('./components/auth/register/register.vue.html') },
    { path: '/login', name: 'login', component: require('./components/auth/login/login.vue.html') }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html')),    
});