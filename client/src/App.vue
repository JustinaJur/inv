<template>
  <InvoiceGenerator msg="Sąskaitų generatorius" />
</template>

<script>
import InvoiceGenerator from "./components/InvoiceGenerator.vue";

export default {
  name: "App",
  components: {
    InvoiceGenerator,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
