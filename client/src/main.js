import { createApp } from "vue";
import App from "./App.vue";
import router from "./router"; // Import the router

// Create and mount the app with the router
const app = createApp(App);
app.use(router);
app.mount("#app");
