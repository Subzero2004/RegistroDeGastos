<script setup>
import { ref } from 'vue'
import axios from 'axios'

const datosGastos = ref([])

async function cargarDatosApi() {
  try {
    const response = await axios.get('http://localhost:5167/api/Gasto')
    datosGastos.value = response.data
  } catch (error) {
    console.error('Error al obtener datos:', error)
  }
}

cargarDatosApi()
</script>

<template>
  <div class="container-historial">
    <router-link :to="'/'" class="button-historial">Formulario</router-link>
    <h1 class="title">History</h1>
    <table class="table-container">
      <thead>
        <tr>
          <th>Fecha</th>
          <th>Descripción</th>
          <th>Monto</th>
          <th>Nombre Comercio</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="gasto in datosGastos" :key="gasto.ID">
          <td>{{ gasto.fecha }}</td>
          <td>{{ gasto.descripcion }}</td>
          <td>${{ gasto.monto }}</td>
          <td>{{ gasto.nombrecomercio }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style>
.container-historial {
  width: 100%;
  height: 100%;
  display: flex;
  align-items: center;
  flex-direction: column;
  gap: 20px;
}

.title {
  text-align: left;
  font-size: 2rem;
  margin-bottom: 20px;
  border-bottom: 2px solid #334b6b;
  display: inline-block;
}

.table-container {
  width: 80%;
  border-collapse: collapse;
  margin-top: 10px;
}

td {
  padding: 10px;
  text-align: left;
  border-bottom: 1px solid #334b6b;
}

th {
  background-color: #2a2a5a;
  padding: 10px;
  text-align: left;
  border-bottom: 1px solid #334b6b;
}
</style>
