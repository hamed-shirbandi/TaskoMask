using DNTCaptcha.Core;
using TaskoMask.Services.Identity.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDNTCaptcha(options=>options.UseCookieStorageProvider(SameSiteMode.Strict).AbsoluteExpiration(minutes: 7)
        .ShowThousandsSeparators(false)
        .WithNoise(pixelsDensity: 25, linesCount: 3)
        .WithEncryptionKey("CaptchaEncryptionKey")
        .InputNames(
            new DNTCaptchaComponent
            {
                CaptchaHiddenInputName = "DNTCaptchaText",
                CaptchaHiddenTokenName = "DNTCaptchaToken",
                CaptchaInputName = "DNTCaptchaInputText"
            })
        .Identifier("dntCaptcha")// This is optional. Change it if you don't like its default name.
    );
builder.Services.AddControllers(); // this is necessary for the captcha's image provider
var app = builder
    .ConfigureServices()
    .ConfigurePipeline();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();

    // this is necessary for the captcha's image provider
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
