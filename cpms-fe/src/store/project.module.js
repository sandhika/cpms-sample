import ProjectService from '../services/project.service';


export const project = {
    namespaced: true,
  state: {
    projects: []
  },
  actions: {
        initApp(context) {
        return ProjectService.getAll().then((response) => {
            context.commit("initProjects", response);
          });
        },
        addProject(context, project) {
            return ProjectService.create(project).then((response)=> {
                context.commit("addProject", {
                  id: response.id,
                  ...project
                });
              });
        },
        updateProject(context, project) {
          return ProjectService.update(project.id,project)
            .then((response) => {
              context.commit("updateProject", project);
            });
        },
        deleteProject(context, projectID) {
          return ProjectService.delete(projectID)
            .then((response) => {
              context.commit("deleteCategory", projectID);
            });
        }
  },
  mutations: {
    initProjects(state, projects) {
      state.projects = projects;
      console.log(projects);
    },
    addProject(state, project) {
      state.projects.push(project);
    },
    updateProject(state, project) {
      let index = state.projects.findIndex((c) => c.id == project.id);
      if (index > -1) {
        state.projects[index] = project;
      }
    },
    deleteProject(state, projectID) {
      let index = state.projects.findIndex((c) => c.id == projectID);
      if (index > -1) {
        state.projects.splice(index, 1);
      }
    }
  },
  getters: {
    getAllProject(state) {
      return state.projects;
    }
  }
};