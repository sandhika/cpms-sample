import axios from "axios";

const API_URL = "http://localhost:5097";

export default axios.create({
  baseURL: API_URL,
  headers: {
    "Content-type": "application/json",
    // 'Authorization': 'Bearer my-token',

    "Access-Control-Allow-Origin": "http://localhost:3000",
    "Access-Control-Allow-Credentials": "true",
  
  }
});
