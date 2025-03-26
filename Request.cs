using System;

namespace Genspil
{
    public class Request
    {
        // Properties
        public int RequestID { get; set; }
        public DateTime Date { get; set; }

        // Relations
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public BoardGame BoardGame { get; set; }

        // Constructor
        public Request(int requestID, DateTime date)
        {
            RequestID = requestID;
            Date = date;
        }

        // Eksempelmetode (valgfri – til test/debug)
        public override string ToString()
        {
            return $"Forespørgsel ID: {RequestID}, Dato: {Date.ToShortDateString()}, " +
                   $"Kunde: {Customer?.Name}, Medarbejder: {Employee?.Name}, Spil: {BoardGame?.Name}";
        }
    }
}
