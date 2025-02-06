import { createStore } from "vuex";
import { auth } from "./auth.module";
import { project } from "./project.module";
import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
  modules: {
    auth,
    project,
  },
});

export default store;