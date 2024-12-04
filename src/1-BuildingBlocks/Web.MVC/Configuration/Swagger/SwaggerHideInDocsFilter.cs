using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Swagger;

/// <summary>
/// Exclude unwanted APIs from swagger
/// </summary>
public class SwaggerHideInDocsFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var pathsToRemove = swaggerDoc.Paths.Where(pathItem => pathItem.Key.Contains("DNTCaptchaImage")).ToList();

        foreach (var item in pathsToRemove)
            swaggerDoc.Paths.Remove(item.Key);
    }
}
