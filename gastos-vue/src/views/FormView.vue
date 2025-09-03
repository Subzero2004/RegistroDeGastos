<script setup>
import { ref } from 'vue'
import axios from 'axios'

let datosGasto = ref({
  fecha: '',
  descripcion: '',
  monto: '',
  nombrecomercio: '',
})

let ErrorDescripcion = ref('')
let ErrorMonto = ref('')
let ErrorFecha = ref('')
let ErrorNComercio = ref('')
let EnvioExitoso = ref('')

const enviarDatos = async () => {
  try {
    if (
      datosGasto.value.descripcion == '' ||
      datosGasto.value.descripcion.length < 3 ||
      datosGasto.value.descripcion.length > 250
    ) {
      ErrorDescripcion.value =
        'La descripcion no debe estar vacia y debe tener como minimo 3 caracteres y maximo 250'
    } else {
      ErrorDescripcion.value = ''
    }

    if (datosGasto.value.monto < 0 || datosGasto.value.monto == '') {
      ErrorMonto.value = 'El monto no debe estar vacia y debe ser mayor a 0'
    } else {
      ErrorMonto.value = ''
    }

    if (datosGasto.value.nombrecomercio == '') {
      ErrorNComercio.value =
        'El Nombre Comercio no debe estar vacia y debe tener como minimo 1 caracter y maximo 250'
    } else {
      ErrorNComercio.value = ''
    }

    if (datosGasto.value.fecha == '' || new Date(datosGasto.value.fecha) > new Date()) {
      ErrorFecha.value = 'La fecha no debe ser vacia y no debe ser futura, tampoco debe ser mayor a la fecha actual.'
    } else {
      ErrorFecha.value = ''
    }

    const response = await axios.post('http://localhost:5167/api/Gasto', datosGasto.value)
    console.log('Datos enviados:', response.data)
    if (response.status == 201) {
      datosGasto.value = {
        fecha: '',
        descripcion: '',
        monto: '',
        nombrecomercio: '',
      }
      EnvioExitoso.value = 'Envio de Datos Exitoso'
    } else {
      EnvioExitoso.value = ''
    }
  } catch (error) {
    console.error('Error al enviar datos:', error)
  }
}
</script>

<template>
  <div class="container">
    <h1 class="title">Formulario</h1>
    <form class="form-style" @submit.prevent="enviarDatos" id="formulario-carga">
      <router-link :to="'/historial'" class="button-historial">Historial</router-link>
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
        <p>{{ ErrorMonto }}</p>
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
        <p>{{ ErrorDescripcion }}</p>
      </label>

      <label class="title-column" for="fecha"
        >Fecha
        <input class="input-style" v-model="datosGasto.fecha" type="date" name="fecha" id="fecha" />
        <p>{{ ErrorFecha }}</p>
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
        <p>{{ ErrorNComercio }}</p>
      </label>

      <button class="button-style" type="submit" value="Guardar">SUBMIT</button>
      <p>{{ EnvioExitoso }}</p>
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
}

.button-historial {
  width: 80px;
  height: 20px;
  padding: 10px 20px;
  text-align: center;
  background-color: #506ea0;
  color: white;
  display: flex;
  align-items: center;
  justify-content: center;
  text-decoration-line: none;
  border-radius: 8px;
  position: absolute;
  left: 30px;
  top: 30px;
}

.container {
  width: 60%;
  height: auto;
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
  height: auto;
  position: relative;
}

.title-column {
  font-size: 1.3rem;
  text-align: left;
  width: 100%;
  display: flex;
  gap: 8px;
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

p {
  width: 100%;
  height: auto;
  text-align: center;
  font-size: medium;
  font-family: Georgia, 'Times New Roman', Times, serif;
  color: #506ea0;
}

button:hover {
  background-color: #3b5a8a;
}
</style>
