import axios from "axios";

const BASE_URL = process.env.VUE_APP_BASE_URL || "http://localhost:5198";
console.log(process.env.VUE_APP_BASE_URL);
console.log(process.env);
console.log("env", process.env.NODE_ENV);

// Main method for handling file upload and PDF generation
export const generatePdfFromExcel = async (formData) => {
  try {
    /// const formData = createFormData(file);

    console.log(formData);
    const pdfBlob = await sendFileToBackend(formData);
    initiatePdfDownload(pdfBlob);
  } catch (error) {
    console.error("Error generating PDF:", error);
    alert("Something went wrong while generating the PDF.");
  }
};

// Main method for handling file upload and PDF generation
export const generatePdfFromExcel2 = async (file) => {
  if (!file) {
    alert("Please select a valid Excel file.");
    return;
  }

  try {
    const formData = createFormData(file);
    const pdfBlob = await sendFileToBackend(formData);
    initiatePdfDownload(pdfBlob);
  } catch (error) {
    console.error("Error generating PDF:", error);
    alert("Something went wrong while generating the PDF.");
  }
};

// Prepare FormData from the Excel file
const createFormData = (file) => {
  const formData = new FormData();
  formData.append("file", file);
  return formData;
};

// Send the Excel file to the backend API and get the generated PDF
const sendFileToBackend = async (formData) => {
  const { data } = await axios.post(
    `${BASE_URL}/api/pdf/generatePdf`,
    formData,
    {
      // headers: {
      //   "Content-Type": "multipart/form-data",
      // },
      responseType: "blob",
    }
  );
  return data;
};

// Handle the PDF blob and trigger file download
const initiatePdfDownload = (blob) => {
  const url = window.URL.createObjectURL(blob);
  const link = document.createElement("a");
  link.href = url;
  link.download = "generated_file.pdf";
  link.click();
};

export const test = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/api/pdf/test`);
    console.log(response);
    return response.data;
  } catch (error) {
    console.error("Error fetching data:", error);
  }
};
