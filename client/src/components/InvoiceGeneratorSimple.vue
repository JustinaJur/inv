<template>
  <div class="inv-generator">
    <h1>{{ msg }}</h1>
    <div>
      <!-- <div class="inv-generator_input-fields">
        <label>Vardas Pavardė</label>
        <input type="input" placeholder="Vardas Pavardė" v-model="fullName" />
        <label>Sąskaitos numeris</label>
        <input
          type="input"
          placeholder="Sąskaitos numeris"
          v-model="accountNumber"
        />
        <label>Sąskaitos data</label>
        <input type="date" v-model="billDate" />
        <label>Už laikotarpį</label>
        <input type="month" v-model="serviceDate" />
        <label>Pamokos kaina</label>
        <input type="number" v-model="price" />
      </div>  -->

      <input type="file" @change="handleFileUpload" />
      <button @click="getPdf" class="cosmic-button">Generate PDF</button>
      <!-- <button @click="test" class="cosmic-button">Generate PDF</button> -->
    </div>
  </div>
</template>

<script>
import "jspdf-autotable";
import { loadFonts } from "@/services/helpers/fonts.js";
import {
  generatePdfFromExcel,
  //  test,
} from "@/services/pdfService.js";

export default {
  name: "inv-generator-simple",
  props: {
    msg: String,
  },
  data() {
    return {
      //   excelHeaders: null,
      //   excelBody: null,
      //   fileName: null,
      //   billDate: null,
      //   fullName: null,
      //   accountNumber: null,
      //   price: 6,
      //   serviceDate: null,
      file: null,
    };
  },
  created() {
    loadFonts();
  },
  methods: {
    handleFileUpload(event) {
      this.file = event.target.files[0];
    },
    async getPdf() {
      const { file } = this;

      if (!file) {
        alert("Please select an Excel file");
        return;
      }
      generatePdfFromExcel(file);
    },
  },
};
</script>

<style scoped>
.inv-generator {
  display: flex;
  flex-direction: column;
  align-items: center;
  height: 100vh;
}

.inv-generator_input-fields {
  display: flex;
  flex-direction: column;
  gap: 10px;
  max-width: 400px;
  margin: 0 auto;
  padding: 20px;
  background-color: #f9f9f9;
  border-radius: 8px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.inv-generator_input-fields label {
  font-size: 14px;
  font-weight: bold;
  margin-bottom: 5px;
  color: #333;
}

.inv-generator_input-fields input {
  padding: 10px;
  font-size: 16px;
  border: 1px solid #ddd;
  border-radius: 4px; /* Rounded corners for inputs */
  outline: none;
}

.inv-generator_input-fields input:focus {
  border-color: #007bff; /* Highlight the input on focus */
  box-shadow: 0 0 5px rgba(0, 123, 255, 0.5); /* Focus effect */
}

.inv-generator input[type="file"],
.inv-generator button {
  margin-bottom: 10px; /* Adds spacing between the input and button */
  width: 100%; /* Make the input and button take full width, but only up to the width of the container */
  max-width: 300px; /* Limits the width of the input and button */
}

.inv-generator button {
  cursor: pointer;
  padding: 10px;
  background-color: #4caf50;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  margin: 10px;
}

.inv-generator button:disabled {
  background-color: #ccc;
  cursor: not-allowed;
}

.cosmic-button {
  position: relative;
  padding: 12px 24px;
  font-size: 16px;
  font-weight: bold;
  text-transform: uppercase;
  border: 2px solid transparent;
  border-radius: 8px;
  background: linear-gradient(135deg, #8e2de2, #4a00e0);
  color: #fff;
  cursor: pointer;
  outline: none;
  transition: all 0.3s ease;
  box-shadow: 0 0 15px rgba(255, 255, 255, 0.2), 0 0 25px rgba(72, 61, 139, 0.5);
}

.cosmic-button:hover {
  background: linear-gradient(135deg, #4a00e0, #8e2de2); /* Hover effect */
  box-shadow: 0 0 30px rgba(255, 255, 255, 0.4), 0 0 40px rgba(72, 61, 139, 0.7);
}

.cosmic-button:focus {
  outline: none;
  box-shadow: 0 0 20px rgba(255, 255, 255, 0.6), 0 0 40px rgba(72, 61, 139, 1);
}
</style>
