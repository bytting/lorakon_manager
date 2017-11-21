using System;

namespace lorakon_manager
{
    public class LogEntry
    {
        public LogEntry()
        {
            CreateDate = DateTime.MinValue;
            Severity = 0;
            Message = String.Empty;
        }

        public LogEntry(DateTime createDate, int severity, string message)
        {
            CreateDate = createDate;
            Severity = severity;
            Message = message;
        }

        public DateTime CreateDate { get; set; }
        public int Severity { get; set; }
        public string Message { get; set; }
    }
}