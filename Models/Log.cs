
namespace Stryker.BC.API.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public string LogMessage { get; set; }
        public int LogType { get; set; }

        public DateTime LogDate { get; set; }

    }
}
