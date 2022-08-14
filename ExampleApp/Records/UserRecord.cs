using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp.Records
{
    public record UserRecord(string FirstName, string LastName)
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string Phone { get; set; }
        public bool VerifiedEmail { get; set; } = false;
    }
}
