// Note: Properties must be public and must have { get; set; } or will return empty

namespace Stryker.BC.API.Models
{
    public class LogModel
    {
        public int LogId { get; set; }
        public string LogMessage { get; set; }
        public int LogType { get; set; }
        public DateTime LogDate { get; set; }

    }
}
