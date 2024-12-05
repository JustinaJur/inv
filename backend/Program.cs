using inv.Data;
using inv.Services;
using OfficeOpenXml;
using static inv.Services.PDFService;

var builder = WebApplication.CreateBuilder(args);
var corsUrls = builder.Configuration.GetSection("CORS").Get<IDictionary<string, string>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        if (builder.Environment.IsDevelopment())
        {
            policy.WithOrigins(corsUrls["Development"])
                  .AllowAnyHeader()
                  .AllowAnyMethod();
            Console.WriteLine("Development")

        }
        else
        {
            policy.WithOrigins(corsUrls["Production"])
               .AllowAnyHeader()
               .AllowAnyMethod();
            Console.WriteLine("Production")
        }
    });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IPdfRepository, PdfRepository>();
builder.Services.AddScoped<IPdfService, PdfService>();
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;




var app = builder.Build();

app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();