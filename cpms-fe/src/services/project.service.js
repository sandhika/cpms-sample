import axios from '../http-common';
import authHeader from './auth-header';


class ProjectService {
  getAll() {
    return axios.get('/project/all',{ headers: authHeader() });
  }

  getById(id) {
    return axios.get(`/project/byid${id}`, { headers: authHeader() });
  }

   delete() {
    return axios.delete(`/project/byid${id}`, { headers: authHeader() });
  }

   update(id,data) {
    return axios.put(`/project/byid${id}`,data, { headers: authHeader() });
  }
  
  create(data) {
    return axios.post('/project/add', data, { headers: authHeader() });
  }

}

export default new ProjectService();