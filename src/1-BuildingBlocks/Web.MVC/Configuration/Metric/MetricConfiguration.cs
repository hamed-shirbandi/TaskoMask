using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Metric
{
    public static class MetricConfiguration
    {
        public static void AddMetrics(this IServiceCollection services, IConfiguration configuration)
        {
            var metricOptions = configuration.GetSection("Metric").Get<MetricOptions>();

            //It starts the metrics exporter as a background service using a stand alone kestrel
            if (metricOptions.StandAloneKestrelServerEnabled)
            {
                services.AddMetricServer(options =>
                {
                    options.Port = metricOptions.Port;
                    options.Url = metricOptions.Url;
                    options.Hostname = metricOptions.Hostname;
                });
            }

            //Inject IMetricFactory to be used in application objects instead of coupling their implementation with Metrics
            services.AddSingleton<IMetricFactory>(Metrics.DefaultFactory);
        }

        public static void UseMetrics(this IApplicationBuilder app, IConfiguration configuration)
        {
            var metricOptions = configuration.GetSection("Metric").Get<MetricOptions>();

            //If kestrel server is not enabled then use current app server
            if (!metricOptions.StandAloneKestrelServerEnabled)
                app.UseMetricServer(metricOptions.Port, metricOptions.Url);

            if (metricOptions.HttpMetricsEnabled)
            {
                app.UseHttpMetrics(options =>
                {
                    options.AddCustomLabel("host", context => context.Request.Host.Host);
                });
            }

            if (metricOptions.SuppressDefaultMetrics)
                Metrics.SuppressDefaultMetrics();
        }
    }
}
