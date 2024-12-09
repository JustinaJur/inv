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
        // Get the environment name (Development or Production)
        var environment = builder.Environment.EnvironmentName;

        // Fetch the appropriate CORS URL based on the environment
        var corsUrl = environment == "Development"
            ? builder.Configuration["CORS:Development"]  // Fetch from appsettings.Development.json
            : builder.Configuration["CORS:Production"]; // Fetch from appsettings.Production.json

        Console.WriteLine(environment);
        Console.WriteLine(corsUrl);

        // Ensure corsUrl is not null or empty
        if (string.IsNullOrEmpty(corsUrl))
        {
            throw new InvalidOperationException("CORS URL is not configured properly in appsettings.");
        }

        // Configure the CORS policy to allow the necessary origins
        policy.WithOrigins(corsUrl)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IPdfRepository, PdfRepository>();
builder.Services.AddScoped<IPdfService, PdfService>();
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();