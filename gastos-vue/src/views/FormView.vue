<script setup>
import { ref } from 'vue'
import axios from 'axios'

let datosGasto = ref({
  fecha: '',
  descripcion: '',
  monto: '',
  nombrecomercio: '',
})

const enviarDatos = async () => {
  try {
    const response = await axios.post('http://localhost:5167/api/Gasto', datosGasto.value)
    console.log('Datos enviados:', response.data)
  } catch (error) {
    console.error('Error al enviar datos:', error)
  }
}
</script>

<template>
  <div class="container">
    <h1 class="title">Formulario</h1>
    <form class="form-style" @submit.prevent="enviarDatos" id="formulario-carga">
      <h2 class="subtitle">Gastos</h2>
      <label class="title-column" for="monto"
        >Monto
        <input
          class="input-style"
          v-model="datosGasto.monto"
          type="number"
          name="monto"
          id="monto"
        />
      </label>

      <label class="title-column" for="descripcion"
        >Descripción
        <input
          class="input-style"
          v-model="datosGasto.descripcion"
          type="text"
          name="descripcion"
          id="descripcion"
        />
      </label>

      <label class="title-column" for="fecha"
        >Fecha
        <input class="input-style" v-model="datosGasto.fecha" type="date" name="fecha" id="fecha" />
      </label>

      <label class="title-column" for="comercio"
        >Nombre de Comercio
        <input
          class="input-style"
          v-model="datosGasto.nombrecomercio"
          type="text"
          name="nombreComercio"
          id="nombreComercio"
        />
      </label>

      <button class="button-style" type="submit" value="Guardar">SUBMIT</button>
    </form>
  </div>
</template>

<style>
body {
  margin: 0;
  padding: 0;
  background-color: #0c162d;
  font-family: sans-serif;
  color: white;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
}

.container {
  width: 80%;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  margin: auto;
}

.subtitle {
  font-size: xx-large;
}

.title {
  font-size: 2.8rem;
  margin-bottom: 20px;
  border-bottom: 3px solid #334b6b;
}

.form-style {
  background-color: #121f3d;
  padding: 30px;
  border-radius: 12px;
  border: 2px solid #334b6b;
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100%;
}

.title-column {
  font-size: 1.3rem;
  margin-top: 15px;
  text-align: left;
  width: 100%;
  display: flex;
  gap: 10px;
  flex-direction: column;
}

.input-style {
  padding: 18px;
  border-radius: 8px;
  border: none;
  margin-top: 5px;
  background-color: #1c2b45;
  color: white;
  font-size: 1.2rem;
}

.button-style {
  margin-top: 60px;
  width: 50%;
  padding: 18px;
  font-size: 1.3rem;
  background-color: #506ea0;
  color: white;
  font-weight: bold;
  border: none;
  border-radius: 8px;
  cursor: pointer;
}

button:hover {
  background-color: #3b5a8a;
}
</style>
