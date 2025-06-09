import { createRouter, createWebHistory } from 'vue-router'
import FormView from '@/views/FormView.vue'
import HistorialView from '@/views/HistorialView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'form',
      component: FormView,
    },
    {
      path: '/historial',
      name: 'historial',
      component: HistorialView,
    },
  ],
})

export default router
