import { jsPDF } from "jspdf";
import { addBookAntiqueBold } from "@/assets/fonts/Book-Antique-Bold.js";
import { addBookAntiqueNormal } from "@/assets/fonts/Book-Antique-Normal.js";

export const loadFonts = async () => {
  await Promise.all([
    jsPDF.API.events.push(["addFonts", addBookAntiqueBold]),
    jsPDF.API.events.push(["addFonts", addBookAntiqueNormal]),
  ]);
};
