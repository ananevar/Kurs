using JKH.Components;
using JKH.Components.Account;
using JKH.Data;
using Tesseract;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddHttpClient();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();


app.MapPost("/api/ocr/meter", async (HttpRequest request) =>
{
    // 1. Проверяем, что пришёл multipart/form-data
    if (!request.HasFormContentType)
        return Results.BadRequest("Expected multipart/form-data.");

    // 2. Читаем форму
    var form = await request.ReadFormAsync();
    var file = form.Files["file"];

    if (file is null || file.Length == 0)
        return Results.BadRequest("Файл не передан.");

    // 3. Ограничение размера (6 МБ)
    if (file.Length > 6 * 1024 * 1024)
        return Results.BadRequest("Файл слишком большой (макс. 6 МБ).");

    // 4. Читаем файл в память
    await using var ms = new MemoryStream();
    await file.CopyToAsync(ms);
    var bytes = ms.ToArray();

    // 5. Инициализируем Tesseract
    // ВАЖНО: папка tessdata должна быть рядом с exe (bin/Debug/netX.X/)
    using var engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);

    // 6. Ограничиваем символы — только цифры
    engine.SetVariable("tessedit_char_whitelist", "0123456789.,");
    engine.SetVariable("user_defined_dpi", "300");

    // 7. OCR
    using var img = Pix.LoadFromMemory(bytes);
    using var page = engine.Process(img, PageSegMode.SingleLine);
    var text = (page.GetText() ?? "").Trim();

    // 8. Вытаскиваем первое число
    var match = Regex.Match(text.Replace(" ", ""), @"\d+(?:[.,]\d+)?");
    var raw = match.Success ? match.Value : "";

    // нормализуем десятичный разделитель
    var value = raw.Replace(',', '.');

    // 9. Возвращаем JSON
    return Results.Ok(new
    {
        rawText = text,
        value
    });
});


app.Run();
