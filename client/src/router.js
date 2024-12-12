import { createRouter, createWebHistory } from "vue-router";
import LoginPage from "./components/LoginPage.vue";
// import Dashboard from "./components/Dashboard.vue";
import InvoiceGeneratorSimple from "./components/InvoiceGeneratorSimple.vue";

const routes = [
  {
    path: "/",
    name: "login",
    component: LoginPage,
  },
  {
    path: "/generator",
    name: "generator",
    component: InvoiceGeneratorSimple,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
