using DNTCaptcha.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Captcha;

public static class CaptchaConfiguration
{
    public static void AddCaptcha(this IServiceCollection services)
    {
        services.AddDNTCaptcha(options =>
            options
                .UseCookieStorageProvider(SameSiteMode.Strict)
                .AbsoluteExpiration(minutes: 7)
                .ShowThousandsSeparators(false)
                .WithNoise(pixelsDensity: 25, linesCount: 3)
                .WithEncryptionKey("CaptchaEncryptionKey")
                .InputNames(
                    new DNTCaptchaComponent
                    {
                        CaptchaHiddenInputName = "DNTCaptchaText",
                        CaptchaHiddenTokenName = "DNTCaptchaToken",
                        CaptchaInputName = "DNTCaptchaInputText",
                    }
                )
                .Identifier("dntCaptcha")
        );
    }
}
