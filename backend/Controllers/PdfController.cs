using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PdfController : ControllerBase
{
    private readonly IPdfService _pdfService;

    public PdfController(IPdfService pdfService)
    {
        _pdfService = pdfService;
    }

    [HttpPost("generatePdf")]
    public async Task<IActionResult> GeneratePdf(IFormFile file, [FromForm] string fullName)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        if (!file.FileName.EndsWith(".xlsx"))
        {
            return BadRequest("Only Excel files are allowed.");
        }

        Console.WriteLine(fullName);
        var pdfBytes = await _pdfService.GeneratePdfFromExcel(file);
        //   var pdfBytes = await _pdfService.GeneratePdfFromExcel(file, name, bankAccount, email);

        return File(pdfBytes, "application/pdf", "saskaita.pdf");
    }

    [HttpGet("test")]
    public ActionResult<string> GetTest()
    {
        return Ok("labas");
    }
}