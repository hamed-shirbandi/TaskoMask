// Copyright (c) CodeBlock.Dev. All rights reserved.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Observation.Serilog;

public static class SerilogConfiguration
{
    /// <summary>
    ///
    /// </summary>
    public static void AddCustomSerilog(this WebApplicationBuilder builder)
    {
        var serilogConfig = builder.Configuration.GetSection("Serilog");
        if (!serilogConfig.Exists())
            return;

        Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
        builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));
    }

    public static void UseCustomSerilog(this WebApplication app)
    {
        var serilogConfig = app.Configuration.GetSection("Serilog");
        if (!serilogConfig.Exists())
            return;

        app.UseSerilogRequestLogging();
    }
}
