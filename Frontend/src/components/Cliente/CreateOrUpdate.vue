<template>
<div>
<h2>{{ pageTitle }}</h2>
<el-form v-loading = "loading" :model="form" :rules="rules" ref="ruleForm" align="left">
    <el-form-item label="Nombre" prop="nombre">
        <el-input v-model="form.nombre" style="width:20%"></el-input>
    </el-form-item>
     <el-form-item label="Apellido" prop="apellido">
        <el-input v-model="form.apellido" style="width:20%"></el-input>
    </el-form-item>
     <el-form-item label="Telefono" prop="telefono">
        <el-input type="tel"  v-mask = "'(###) ### - ####'" v-model="form.telefono" style="width:20%"></el-input>
    </el-form-item>
    <el-form-item>
    <el-button @click="save" type="primary" >Guardar</el-button>
    </el-form-item>
</el-form>
</div>
</template>

<script>
export default {
  name: "ClienteCreateOrUpdate",
  data() {
    return {
        loading : false,
        form: {
            clienteId: 0,
            nombre: null,
            apellido: null,
            telefono: null,
        },
        rules: {
            nombre: [
                { required: true, message: 'Debe Ingresar un nombre', trigger: 'blur'},
                { min: 3, message: 'Debe contener como minimo 3 caracteres', trigger: 'blur'},
            ],
            apellido: [
                { required: true, message: 'Debe Ingresar el apellido', trigger: 'blur'},
            ],
             telefono: [
                { required: true},
            ],
        }
    };
  },
  computed: {
      pageTitle(){
         return this.form.clienteId === 0 ? "Nuevo cliente" : this.form.Nombre;
      }
  },
  created() {
      let self = this;
      self.get(self.$route.params.id);
  },
  methods: {
      get(id){
          if(id == undefined) return;
   
    let self = this;

    self.loading = true;
      self.$store.state.services.clienteService
      .get(id)
      .then(r => {
         self.loading = false;
         self.form.clienteId = r.data.clienteId;
          self.form.nombre = r.data.nombre;
           self.form.apellido = r.data.apellido;
            self.form.telefono = r.data.telefono;
      }).catch(r => {
          self.$message({
              message: "Ocurrio un error inesperado",
              type: "error"
          });
      });
    },
     
 
  save() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
          if(valid){
    self.loading = true;

    if(self.form.clienteId > 0){
        self.$store.state.services.clienteService
            .update(self.form)
            .then(r => {
             self.loading = false;
            self.$router.push('/cliente');
        }).catch(r => {
             self.$message({
              message: "Ocurrio un error inesperado",
              type: "error"
          });
            });
            }else{
            self.$store.state.services.clienteService
            .add(self.form)
            .then(r => {
                self.loading = false;
                self.$router.push('/cliente');
            }).catch(r => {
                self.$message({
                    message: "Ocurrio un error inesperado",
                    type: "error"
                });
            });
            }
            
          }
      });
  }
  }
};
</script>