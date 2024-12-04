// Copyright (c) CodeBlock.Dev. All rights reserved.
// See LICENSE in the project root for license information.

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Observation.OpenTelemetry;

internal class OpenTelemetrySettings
{
    public string ServiceName { get; set; }
    public bool ExportMetrics { get; set; }
    public string MetricsEndpoint { get; set; }
    public bool ExportTracing { get; set; }
    public string TracingEndpoint { get; set; }
    public bool ExportLogging { get; set; }
    public string LoggingEndpoint { get; set; }

    public bool IsEnabled()
    {
        return ExportLogging || ExportMetrics || ExportTracing;
    }
}
