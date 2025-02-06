<template>
      <a-form-model 
        ref="ruleForm"
        :model="form"
        :rules="rules"
        :label-col="labelCol"
        :wrapper-col="wrapperCol"
        @submit="handleSubmit" @submit.native.prevent
      >
   
      <a-form-model-item  label="Project Category ">
        <a-select
          v-decorator="[
            'projectCategory',
            { rules: [{ required: true, message: 'Please select your Stage!' }] },
          ]"
          placeholder="Select a option and change input text above"
          @change="handleSelectChange" 
        >
          <a-select-option value="Education">
            Education
          </a-select-option>
          <a-select-option value="Health">
            Health
          </a-select-option>
          <a-select-option value="Office">
            Office
          </a-select-option>
          <a-select-option value="Others">
            Others
          </a-select-option>
        </a-select>
      </a-form-model-item >
      
      <a-form-model-item  v-show="showOthers" label="Others">
      <a-input 
          v-decorator="['others', { rules: [{ required: false, message: '' }] }]" 
          v-show="showOthers"
        />
      </a-form-model-item >

      <a-form-model-item  label="Name">
        <a-input 
          v-decorator="['name', { rules: [{ required: true, message: 'Please input your name!' }] }]"
        />
      </a-form-model-item >

      <a-form-model-item  label="Start Date">
        <a-date-picker v-decorator="[
            'startDate',
            { rules: [{ required: true, message: 'Please select your Start Date!' }] },
          ]" />
       </a-form-model-item >

       <a-form-model-item  label="End Date">
        <a-date-picker v-decorator="[
            'endDate',
            { rules: [{ required: true, message: 'Please select your End Date!' }] },
          ]" />
       </a-form-model-item >
 
      <a-form-model-item  label="Description">
        
        <a-textarea v-decorator="['description', { rules: [{ required: false, message: 'Please input your description!' }] }]" auto-size />
    
      </a-form-model-item >
      <a-form-model-item  label="Project Stage">
        <a-select
          v-decorator="[
            'projectStage',
            { rules: [{ required: true, message: 'Please select your Stage!' }] },
          ]"
          placeholder="Select a option and change input text above"
          
        >
          <a-select-option value="1">
            Concept
          </a-select-option>
          <a-select-option value="2">
            Design &amp; Documentation
          </a-select-option>
          <a-select-option value="3">
            Pre-Construction
          </a-select-option>
          <a-select-option value="4">
            Construction
          </a-select-option>
        </a-select>
      </a-form-model-item >

      <a-form-model-item :wrapper-col="{span: 14, offset: 4}">
      <a-button type="primary"  @click="handleSubmit">
        Submit
      </a-button>
    </a-form-model-item>
     
    
    </a-form-model>
  </template>
  
  <script>

  
    
  export default {
    // props: 
    // {
    //   form :Object,
    //   rules: Object,
    //   labelCol: Object,
    //   wrapperCol: Object,
    // },

    // setup(props) {
    //   // setup() receives props as the first argument.
    //   console.log("data => ",props);
    //   // this.form.setFieldsValue({

    //   // });
    // },
    data: function(){
      return {
        formLayout: 'horizontal',
        form:  {
            name: 'hola',
            projectCategory :'Education',
            startDate : new Date(),
            endDate : new Date(),
            projectStage: 1,
            description: 'Ini Hanya Deskiprsi',
            },
            rules: {
                name: [
                  { required: true, message: 'Please input Activity name', trigger: 'blur' },
                  { min: 3, max: 5, message: 'Length should be 3 to 5', trigger: 'blur' },
                ],
                region: [{ required: true, message: 'Please select Activity zone', trigger: 'change' }],
                startDate: [{ required: true, message: 'Please pick a date', trigger: 'change' }],
                endDate: [{ required: true, message: 'Please pick a date', trigger: 'change' }],
               
                projectCategory: [
                  {
                    type: 'array',
                    required: true,
                    message: 'Please select at least one activity type',
                    trigger: 'change',
                  },
                ],
                projectStage: [
                  {
                    type: 'array',
                    required: true,
                    message: 'Please select at least one activity type',
                    trigger: 'change',
                  },
                ],
                description: [{ required: true, message: 'Please input activity form', trigger: 'blur' }],
      },
      labelCol: { span: 8 },
      wrapperCol: { span: 14 },
        showOthers: false
      };
    },
    methods: {
      handleSubmit(e) {
        this.$refs.ruleForm.validate(valid => {
        if (valid) {
          console.log(this.form);
          this.$emit('submit',this.form);
        } else {
          console.log('error submit!!');
          return false;
        }
      });
      },
      handleSelectChange(value) {
        console.log(value);
        this.showOthers = value == "Others";
        // this.form.setFieldsValue({
        //   note: `Hi, ${value === 'male' ? 'man' : 'lady'}!`,
        // });
      },
     


      
    },
    
  };
  </script>