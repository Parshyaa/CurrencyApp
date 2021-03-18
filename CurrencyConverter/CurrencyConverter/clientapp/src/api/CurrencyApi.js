import axios from 'axios'
export default {
    getUrlBase() {
        return "http://localhost:8082/api/";
    },
    getRate() {
        var base = this.getUrlBase();
        return axios.get(base + 'currency/getRate');
    },
}