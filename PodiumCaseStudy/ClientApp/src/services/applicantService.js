import axios from 'axios';

var path = "/api/applicant/";
const headers = {
    'Content-Type': 'application/json',
};

export default {
    createApplicant(payload){
        return axios.post(path, payload, {headers: headers});
    }
}