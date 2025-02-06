<template>
  <a-modal v-model="visible" title="Create Project" on-ok="handleOk" footer="">
    
          <form-project  :form="form" :rules="rules" 
            :label-col="labelCol"
            :wrapper-col="wrapperCol"
            @submit="handleOk" />

          <template slot="footer">
            <a-button key="back" @click="handleCancel">
              Return
            </a-button>
            <a-button key="submit" type="primary" :loading="loading" @click="handleOk">
              Submit
            </a-button>
          </template>

  </a-modal>   
</template>
      
  <script>
  import FormProject from '../components/Forms/FormProject.vue';

  export default ({
    components:{
      FormProject
    },
    props:{
      visible: {
				type: Boolean,
				default: false,
			},
    },

    mounted() {
    console.log(this.props)
    },
    components: {
	
		},
    data(){
      return {
        
      loading: false,
        showOthers: false
      }
    },
    methods: {
			showModal() {
			this.visibleCreate = true;
			},
			handleOk(e) {
        e.code = '';
        this.$store.dispatch("project/addProject", e).then(
							() => {
							this.$router.push("/project");
							},
							(error) => {
							this.loading = false;
							this.message =
								(error.response &&
								error.response.data &&
								error.response.data.message) ||
								error.message ||
								error.toString();
							}
						);

			this.visible = false;
      this.$emit('submit',this.visible )
			},
      handleCancel(e) {
        this.visible = false;
        this.$emit('submit',this.visible )
      },
      handleSelectChange(value) {
        console.log(value);
        this.showOthers = value == "Others";
        // this.form.setFieldsValue({
        //   note: `Hi, ${value === 'male' ? 'man' : 'lady'}!`,
        // });
      },
		},

  })
  </script>