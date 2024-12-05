const PDF_BASE_API = "http://localhost:5198/api/pdf";

export const uploadExcelAndGeneratePdf = async (file) => {
  const formData = new FormData();
  formData.append("file", file);

  const pdfBlob = await sendExcelToBackend(formData);
  downloadPdf(pdfBlob);
};

export const sendExcelToBackend = async (formData) => {
  try {
    const response = await fetch(`${PDF_BASE_API}/generatePdf`, {
      method: "POST",
      body: formData,
    });

    if (!response.ok) {
      throw new Error("Failed to generate PDF");
    }

    return await response.blob();
  } catch (error) {
    console.error(error);
    alert("Error generating PDF");
    throw error;
  }
};

function downloadPdf(blob) {
  const url = window.URL.createObjectURL(blob);
  const link = document.createElement("a");
  link.href = url;
  link.download = "generated_file.pdf";
  link.click();
}
