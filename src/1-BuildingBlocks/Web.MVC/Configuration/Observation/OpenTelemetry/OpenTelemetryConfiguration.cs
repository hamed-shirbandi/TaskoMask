// Copyright (c) CodeBlock.Dev. All rights reserved.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Observation.OpenTelemetry;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Observation.OpenTelemetry;

internal static class OpenTelemetryConfiguration
{
    public static void AddOpenTelemetry(this WebApplicationBuilder builder)
    {
        var openTelemetrySettings = builder.Configuration.GetSection("OpenTelemetry").Get<OpenTelemetrySettings>();
        if (openTelemetrySettings == null)
            return;

        if (!openTelemetrySettings.IsEnabled())
            return;

        builder
            .Services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(openTelemetrySettings.ServiceName))
            .WithTracing(openTelemetrySettings)
            .WithMetrics(openTelemetrySettings);

        builder.AddOpenTelemetryLogging(openTelemetrySettings);
    }

    private static OpenTelemetryBuilder WithTracing(this OpenTelemetryBuilder builder, OpenTelemetrySettings settings)
    {
        if (!settings.ExportTracing)
            return builder;

        return builder.WithTracing(tracing =>
        {
            tracing
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddOtlpExporter(options =>
                {
                    options.Endpoint = new Uri(settings.TracingEndpoint);
                });
        });
    }

    private static OpenTelemetryBuilder WithMetrics(this OpenTelemetryBuilder builder, OpenTelemetrySettings settings)
    {
        if (!settings.ExportMetrics)
            return builder;

        return builder.WithMetrics(metrics =>
        {
            metrics
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddOtlpExporter(options =>
                {
                    options.Endpoint = new Uri(settings.MetricsEndpoint);
                });
        });
    }

    private static void AddOpenTelemetryLogging(this WebApplicationBuilder builder, OpenTelemetrySettings settings)
    {
        if (!settings.ExportLogging)
            return;

        builder.Logging.AddOpenTelemetry(logging =>
            logging.AddOtlpExporter(options =>
            {
                options.Endpoint = new Uri(settings.LoggingEndpoint);
            })
        );
    }
}
