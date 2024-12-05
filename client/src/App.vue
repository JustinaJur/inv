<template>
  <InvoiceGeneratorSimple msg="Sąskaitų generatorius" />
</template>

<script>
////import InvoiceGenerator from "./components/InvoiceGenerator.vue";
import InvoiceGeneratorSimple from "./components/InvoiceGeneratorSimple.vue";

export default {
  name: "App",
  components: {
    // InvoiceGenerator,
    InvoiceGeneratorSimple,
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
