using System;
using System.Data.SQLite;
namespace LoggingFrameworkPoC.Logging
{
    public class MidasLogging : IMidasLogging
    {
        public LogLevel LogLevel { get; set; }
        public string TrainId { get; set; }
        public string DetectorName { get; set; }
        public string DetectorSite { get; set; }
        public int TrackNumber { get; set; }
        public string TrainArrivalTimeUTC { get; set; } 
        public string CarIdNumber { get; set; }
        public string CarAxleNumber { get; set; }
        public char ComponentSide { get; set; }
        public string PrimaryImage { get; set; }
        public string DefectFound { get; set; }
        public string LogTime { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string TraceId { get; set; }

        private readonly string _sqlServerConnectionString;
        public MidasLogging(string SQLServerConnectionString)
        {
            _sqlServerConnectionString = SQLServerConnectionString;
        }   

        /// <summary>
        /// Use this method to Log information messages
        /// </summary>
        /// <param name="TrainId"></param>
        /// <param name="DetectorName"></param>
        /// <param name="DetectorSite"></param>
        /// <param name="TraceId"></param>
        /// <param name="Message"></param>
        public void LogInformation(string TrainId, string DetectorName, string DetectorSite,  
                             string TraceId, string Message)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_sqlServerConnectionString))
            {
                //Open connection to DB
                conn.Open();
                string valueSql = TrainId+",\""+DetectorName+"\",\""+ DetectorSite + "\",\"" + DateTime.UtcNow+ "\",\"Log Service" + "\",\""+Message+"\",\"" +TraceId+"\",\"" + LogLevel.Information+"\"";
                //Query to be fired                   
                string sql = @"INSERT INTO LoggingPoC(TrainId, Detector,DetectorSite,CreatedOn,CreatedBy,Message,TraceId,LogLevel) VALUES(" + valueSql+")";

                //Executing the query
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    //Executing the query                    
                    cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                }
                //Close connection to DB
                conn.Close();
            }
        }

        /// <summary>
        /// Use this method to log detailed informational log messages
        /// </summary>
        /// <param name="TrainId"></param>
        /// <param name="DetectorName"></param>
        /// <param name="DetectorSite"></param>
        /// <param name="TrackNumber"></param>
        /// <param name="TrainArrivalTimeUTC"></param>
        /// <param name="CarIdNumber"></param>
        /// <param name="CarAxleNumber"></param>
        /// <param name="ComponentSide"></param>
        /// <param name="PrimaryImage"></param>
        /// <param name="DefectFound"></param>
        /// <param name="TraceId"></param>
        /// <param name="Message"></param>
        public void LogInformationWithTrainDetails(string TrainId, string DetectorName, string DetectorSite, int TrackNumber,
                             string TrainArrivalTimeUTC, string CarIdNumber, string CarAxleNumber, string ComponentSide,
                             string PrimaryImage, string DefectFound, string TraceId, string Message)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_sqlServerConnectionString))
            {
                //Open connection to DB
                conn.Open();
                string valueSql = TrainId + ",\"" + DetectorName + "\",\"" + DetectorSite + "\",\"" + TrackNumber + "\",\"" + TrainArrivalTimeUTC + "\",\""
                                + CarIdNumber + "\",\"" + CarAxleNumber + "\",\"" + ComponentSide +  "\",\""  + PrimaryImage + "\",\"" + DefectFound + "\",\"" +
                                 DateTime.UtcNow + "\",\"Log Service" + "\",\"" + Message + "\",\"" + TraceId + "\",\"" + LogLevel.Information + "\"";
                //Query to be fired                   
                string sql = @"INSERT INTO LoggingPoC(TrainId, DetectorName,DetectorSite,TrackNumber,TrainArrivalTimeUTC,CarIdNumber,CarAxleNumber,ComponentSide,PrimaryImage,
                             DefectFound,CreatedOn,CreatedBy,Message,TraceId,LogLevel) VALUES(" + valueSql + ")";

                //Executing the query
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    //Executing the query                    
                    cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                }
                //Close connection to DB
                conn.Close();
            }
        }

        /// <summary>
        /// Use this method to log error messages
        /// </summary>
        /// <param name="TrainId"></param>
        /// <param name="DetectorName"></param>
        /// <param name="LocationId"></param>
        /// <param name="TraceId"></param>
        /// <param name="ErrorMessage"></param>
        public void LogError(string TrainId, string DetectorName, string LocationId,
                            string TraceId, string ErrorMessage)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_sqlServerConnectionString))
            {
                //Open connection to DB
                conn.Open();
                string valueSql = TrainId + ",\"" + DetectorName + "\",\"" + LocationId + "\",\"" + DateTime.UtcNow + "\",\"Log Service" + "\",\"" + ErrorMessage + "\",\"" + TraceId + "\",\"" + LogLevel.Error + "\"";
                //Query to be fired                   
                string sql = @"INSERT INTO LoggingPoC(TrainId, Detector,DetectorSite,CreatedOn,CreatedBy,Message,TraceId,LogLevel) VALUES(" + valueSql + ")";

                //Executing the query
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    //Executing the query                    
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                //Close connection to DB
                conn.Close();
            }
        }

        /// <summary>
        /// Use this method to log detailed Error log messages
        /// </summary>
        /// <param name="TrainId"></param>
        /// <param name="DetectorName"></param>
        /// <param name="DetectorSite"></param>
        /// <param name="TrackNumber"></param>
        /// <param name="TrainArrivalTimeUTC"></param>
        /// <param name="CarIdNumber"></param>
        /// <param name="CarAxleNumber"></param>
        /// <param name="ComponentSide"></param>
        /// <param name="PrimaryImage"></param>
        /// <param name="DefectFound"></param>
        /// <param name="TraceId"></param>
        /// <param name="ErrorMessage"></param>
        public void LogErrorWithTrainDetails(string TrainId, string DetectorName, string DetectorSite, int TrackNumber,
                           string TrainArrivalTimeUTC, string CarIdNumber, string CarAxleNumber, string ComponentSide,
                           string PrimaryImage, string DefectFound, string TraceId, string ErrorMessage)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_sqlServerConnectionString))
            {
                //Open connection to DB
                conn.Open();
                string valueSql = TrainId + ",\"" + DetectorName + "\",\"" + DetectorSite + "\",\"" + TrackNumber + "\",\"" + TrainArrivalTimeUTC + "\",\""
                                + CarIdNumber + "\",\"" + CarAxleNumber + "\",\"" + ComponentSide + "\",\"" + PrimaryImage + "\",\"" + DefectFound + "\",\"" +
                                 DateTime.UtcNow + "\",\"Log Service" + "\",\"" + ErrorMessage + "\",\"" + TraceId + "\",\"" + LogLevel.Error + "\"";
                //Query to be fired                   
                string sql = @"INSERT INTO LoggingPoC(TrainId, DetectorName,DetectorSite,TrackNumber,TrainArrivalTimeUTC,CarIdNumber,CarAxleNumber,ComponentSide,PrimaryImage,
                             DefectFound,CreatedOn,CreatedBy,ErrorMessage,TraceId,LogLevel) VALUES(" + valueSql + ")";

                //Executing the query
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    //Executing the query                    
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                //Close connection to DB
                conn.Close();
            }
        }
    }
}
