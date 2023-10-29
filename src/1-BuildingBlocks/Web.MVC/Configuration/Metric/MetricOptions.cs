namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Metric;

public class MetricOptions
{
    /// <summary>
    /// Set it to true if you want to run the metrics on a stand alone kestrel server
    /// </summary>
    public bool StandAloneKestrelServerEnabled { get; set; }
    public ushort Port { get; set; }
    public string Url { get; set; }

    /// <summary>
    /// It is used when StandAloneKestrelServerEnabled is true.
    /// Will listen for requests using this hostname. "+" indicates listen on all hostnames.
    /// By setting this to "localhost", you can easily prevent access from remote systems.-
    /// </summary>
    public string Hostname { get; set; }

    /// <summary>
    /// Set it to true if you want to use the built-in metrics for http requests.
    /// The metrics are:
    /// Number of HTTP requests in progress.
    /// Total number of received HTTP requests.
    /// Duration of HTTP requests.
    /// </summary>
    public bool HttpMetricsEnabled { get; set; }

    /// <summary>
    /// The library enables various default metrics and integrations by default.
    /// If these default metrics are not desirable, set SuppressDefaultMetrics to true.
    /// </summary>
    public bool SuppressDefaultMetrics { get; set; }
}
