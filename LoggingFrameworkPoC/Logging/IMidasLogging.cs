using LoggingFrameworkPoC.Logging;
using System;
namespace LoggingFrameworkPoC
{
    public interface IMidasLogging
    {
        LogLevel LogLevel { get; }
        string TrainId { get; }
        string DetectorName { get; }
        string DetectorSite { get; }
        int TrackNumber { get; }
        string TrainArrivalTimeUTC { get; } 
        string CarIdNumber { get; }
        string CarAxleNumber { get; }
        char ComponentSide { get; }
        string PrimaryImage { get; }
        string DefectFound { get; }
        string LogTime { get; }
        string Message { get; }
        string ErrorMessage { get; }
        string TraceId { get; }
        void LogInformation(string TrainId, string DetectorName, string DetectorSite,
                             string TraceId, string Message);
        void LogError(string TrainId, string DetectorName, string DetectorSite,
                            string TraceId, string ErrorMessage);
    }
}
