using inv.Data;
using inv.Services;
using OfficeOpenXml;
using static inv.Services.PDFService;

var builder = WebApplication.CreateBuilder(args);
var corsUrls = builder.Configuration.GetSection("CORS").Get<IDictionary<string, string>>();
// Define CORS policy based on environment
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        // Allow CORS for local environment (localhost)
        if (builder.Environment.IsDevelopment())
        {
            policy.WithOrigins(corsUrls["Development"])  // Use Development URL from config
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
        else // Production environment
        {
            policy.WithOrigins(corsUrls["Production"])  // Production URL
               .AllowAnyHeader()
               .AllowAnyMethod();
        }
    });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IPdfRepository, PdfRepository>();
builder.Services.AddScoped<IPdfService, PdfService>();
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;




var app = builder.Build();
// Apply CORS policy based on environment
app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.Run();