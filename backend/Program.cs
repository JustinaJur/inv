using inv.Data;
using inv.Services;
using OfficeOpenXml;
using static inv.Services.PDFService;

var builder = WebApplication.CreateBuilder(args);

// Fetch the environment-specific CORS URL from the environment variables
var allowedOrigin = builder.Configuration["CORS_ALLOWED_ORIGIN"] ??
                    builder.Configuration["CORS:Production"] ??
                    "https://inv-w4uc.onrender.com"; // Fallback to default if not found

// Add CORS with dynamic URL
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        // Get the environment name (Development or Production)
        var environment = builder.Environment.EnvironmentName;

        // Log the environment to see if it's picking up correctly
        Console.WriteLine($"Environment: {environment}");

        // Fetch the CORS URL based on the environment from environment variables
        var corsUrl = environment == "Development"
            ? builder.Configuration["CORS:Development"]  // Fallback URL for development (if needed)
            : allowedOrigin; // Use the production environment variable or fallback

        Console.WriteLine($"CORS URL: {corsUrl}");

        // Ensure corsUrl is not null or empty
        if (string.IsNullOrEmpty(corsUrl))
        {
            throw new InvalidOperationException("CORS URL is not configured properly.");
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