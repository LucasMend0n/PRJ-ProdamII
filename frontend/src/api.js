import axios from 'axios';

const baseApi = axios.create({
    baseURL: 'http://localhost:5070'
});

export default baseApi