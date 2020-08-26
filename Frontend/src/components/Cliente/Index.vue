<template>
  <div>
        <h2>Clientes</h2>
        <div id="App" >
              <div class="active-pink-3 active-pink-4 mb-3">
                  <input type="text" v-model="search" placeholder="Buscar..."  style="width:20%">
              </div>
             <div v-for="index in filteredName" :key="index.id">
                
            </div> 
          </div>
            <el-table v-loading="loading" :data="filteredName" >
                  <el-table-column prop="nombre" label="Nombre" sortable></el-table-column>
                  <el-table-column prop="apellido" label="Apellido"  sortable></el-table-column>
                  <el-table-column prop="telefono" label="Telefono"  sortable></el-table-column>
                  <el-table-column align="right">
                      <template slot-scope="scope">
                        <el-button type="danger" @click="remove(scope.row.clienteId)">Eliminar</el-button>
                      <el-button @click="$router.push(`/cliente/${scope.row.clienteId}/edit`)">Editar</el-button>
                    </template>
                  </el-table-column>
        </el-table>

    </div>
</template>

<style>
   .active-pink-3 input[type=text] {
    border: 1px solid #f48fb1;
    box-shadow: 0 0 0 1px #f48fb1;
  }
</style>

<script>



export default {
  name:"App",

 
  data() {
    return {
        data: [],
        loading: false,
        search: '',
       
    };
  },
    computed: {
     filteredName: function(){
       return this.data.filter((data)=>{
        return data.nombre.includes(this.search);
     });
     }
   },
  created() {
    let self = this;
    self.getAll();
  },
  filters:{

  },
  methods: {
  getAll(){
      let self = this;

      self.loading = true;
      self.$store.state.services.clienteService
      .getAll()
      .then(r =>{
          self.loading = false;
         self.data = r.data;
      }).catch(r => {
          self.$message({
              message: "Ocurrio un error inesperado",
              type: "error"
          });
      });
  },
  remove(id){
      let self = this;
       self.$store.state.services.clienteService
      .remove(id)
      .then(r =>{
          self.loading = false;
         self.getAll();
      }).catch(r => {
          self.$message({
              message: "Ocurrio un error inesperado",
              type: "error"
          });
      });
  },
   
   }
  
};
</script>