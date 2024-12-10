using inv.Data;
using inv.Services;
using OfficeOpenXml;
using static inv.Services.PDFService;

// var builder = WebApplication.CreateBuilder(args);

// // Fetch the environment-specific CORS URL from the environment variables
// var allowedOrigin = builder.Configuration["CORS_ALLOWED_ORIGIN"] ??
//                     builder.Configuration["CORS:Production"] ??
//                     "https://inv-w4uc.onrender.com"; // Fallback to default if not found

// // Add CORS with dynamic URL
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowSpecificOrigins", policy =>
//     {
//         // Get the environment name (Development or Production)
//         var environment = builder.Environment.EnvironmentName;

//         // Fetch the CORS URL based on the environment from environment variables
//         var corsUrl = environment == "Development"
//             ? builder.Configuration["CORS:Development"]  // Fallback URL for development (if needed)
//             : allowedOrigin; // Use the production environment variable or fallback

//         // Ensure corsUrl is not null or empty
//         if (string.IsNullOrEmpty(corsUrl))
//         {
//             throw new InvalidOperationException("CORS URL is not configured properly.");
//         }

//         // Configure the CORS policy to allow the necessary origins
//         policy.WithOrigins(corsUrl)
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//     });
// });


// builder.Services.AddControllers();
// builder.Services.AddScoped<IPdfRepository, PdfRepository>();
// builder.Services.AddScoped<IPdfService, PdfService>();
// ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseCors("AllowAllOrigins");
//     app.UseDeveloperExceptionPage();
// }
// else
// {
//     app.UseExceptionHandler("/Home/Error");
//     app.UseHsts();
// }




// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseRouting();

// app.UseCors("AllowSpecificOrigins");
// app.UseAuthorization();
// app.MapControllers();

// app.Run();


//var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//         policy =>
//         {
//             policy.WithOrigins("http://localhost:8080",
//                                 "https://inv-w4uc.onrender.com");
//         });
// });

// builder.Services.AddCors(builder =>
// {
//     builder.AddPolicy("AllowAll", options =>
//     {
//         options.AllowAnyOrigin()
//             .AllowAnyMethod()
//             .AllowAnyHeader();
//     });
// });

// builder.Services.AddControllers();
// builder.Services.AddScoped<IPdfRepository, PdfRepository>();
// builder.Services.AddScoped<IPdfService, PdfService>();
// ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// builder.Services.AddControllers();

// var app = builder.Build();

// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseRouting();

// app.UseCors("AllowAll");

// app.UseAuthorization();

// app.MapControllers();

// app.Run();

var builder = WebApplication.CreateBuilder(args);

// Get the CORS allowed origin based on the environment
string corsUrl;

// Check for the environment
if (builder.Environment.IsDevelopment())
{
    // Use the Development URL
    corsUrl = builder.Configuration["CORS:Development"];
}
else
{
    // Use the Production URL from the environment variable or fallback to a default
    corsUrl = builder.Configuration["CORS:Production"] ?? builder.Configuration["CORS_ALLOWED_ORIGIN"];
}

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins(corsUrl)  // Use the correct CORS URL depending on the environment
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
builder.Services.AddScoped<IPdfRepository, PdfRepository>();
builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddControllers();

var app = builder.Build();

// Enable CORS middleware
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();