using System;

namespace Genspil
{
    public class Request
    {
        private static int _nextId = 1;

        public int RequestID { get; private set; }
        public DateTime Date { get; set; }        
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        internal BoardGame BoardGame { get; set; }

        // Constructor
        public Request(DateTime date)
        {
            RequestID = _nextId++;
            Date = date;
        }
        public Request(int requestID, DateTime date)
        {
            RequestID = requestID;
            Date = date;
            _nextId = Math.Max(_nextId, requestID + 1); // Sørger for at ID'er forbliver unikke
        }

        // Eksempelmetode (valgfri – til test/debug)
        public override string ToString()
        {
            return $"Forespørgsel ID: {RequestID}, Dato: {Date.ToShortDateString()}, " +
                   $"Kunde: {Customer?.Name}, Medarbejder: {Employee?.Name}, Spil: {BoardGame?.Name}";
        }

        //Til at gemme til fil
        public string ToFileString()
        {
            return $"Request|{RequestID}|{Date:yyyy-MM-dd}|" +
                   $"{(Customer != null ? Customer.Name : "N/A")}|{(Customer != null ? Customer.Email : "N/A")}|{(Customer != null ? Customer.Phone.ToString() : "N/A")}|" +
                   $"{(Employee != null ? Employee.Name : "N/A")}|{(Employee != null ? Employee.getEmail() : "N/A")}|{(Employee != null ? Employee.getPhone().ToString() : "N/A")}|" +
                   $"{(BoardGame != null ? BoardGame.Name : "N/A")}|{(BoardGame != null ? BoardGame.Edition : "N/A")}|" +
                   $"{(BoardGame != null ? BoardGame.Genre : "N/A")}|{(BoardGame != null ? BoardGame.MinPlayerCount.ToString() : "N/A")}|" +
                   $"{(BoardGame != null ? BoardGame.MaxPlayerCount.ToString() : "N/A")}|{(BoardGame != null ? BoardGame.Language : "N/A")}";
        }

        //Til at indlæse fra fil
        public static Request FromString(string data)
        {
            string[] parts = data.Split('|');
            if (parts.Length < 15)
                throw new FormatException("Ugyldigt Request-format.");

            int requestId = int.Parse(parts[1]);
            DateTime date = DateTime.Parse(parts[2]);

            Request request = new Request(requestId, date);

            // Kundeoplysninger
            if (parts[3] != "N/A")
            {
                string customerName = parts[3];
                string customerEmail = parts[4];
                int customerPhone = int.Parse(parts[5]);
                request.Customer = new Customer(customerName, customerEmail, customerPhone);
            }

            // Medarbejderoplysninger
            if (parts[6] != "N/A")
            {
                string employeeName = parts[6];
                string employeeEmail = parts[7];
                int employeePhone = int.Parse(parts[8]);
                request.Employee = new Employee(employeeName, employeeEmail, employeePhone);
            }

            // BoardGame-oplysninger
            if (parts[9] != "N/A")
            {
                string bgName = parts[9];
                string bgEdition = parts[10];
                string bgGenre = parts[11];
                int bgMinPlayerCount = int.Parse(parts[12]);
                int bgMaxPlayerCount = int.Parse(parts[13]);
                string bgLanguage = parts[14];

                // Forudsætter en BoardGame-konstruktor, der modtager alle disse oplysninger
                request.BoardGame = new BoardGame(bgName, bgEdition, bgGenre, bgMinPlayerCount, bgMaxPlayerCount, bgLanguage, new List<Product>(), new List<Request>());
            }

            return request;
        }
    }
}
