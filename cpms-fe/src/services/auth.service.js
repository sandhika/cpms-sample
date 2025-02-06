import axios from '../http-common';


class AuthService {
  login(user) {
    return axios
      .post('/auth/login', {
        email: user.email,
        password: user.password
      })
      .then(response => {
        console.log("response=>",response);
        if (response.data.token) {
          localStorage.setItem('user', JSON.stringify(response.data));
        }

        return response.data;
      });
  }

  logout() {
    localStorage.removeItem('user');
  }

  register(user) {
    return axios.post('/auth/register', {
      username: user.username,
      email: user.email,
      password: user.password
    });
  }
}

export default new AuthService();