import Vue from 'vue';
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import App from './App.vue';
import router from './router';

axios.defaults.baseURL = 'https://localhost:44327';

new Vue({
    router,
    render: h => h(App)
  }).$mount('#app');
