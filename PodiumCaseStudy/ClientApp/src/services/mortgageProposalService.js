import axios from 'axios';

var path = "/api/Mortgage/";
const headers = {
    'Content-Type': 'application/json',
};

export default {
    getProposal(payload){
        return axios.post(path, payload, {headers: headers});
    }
}