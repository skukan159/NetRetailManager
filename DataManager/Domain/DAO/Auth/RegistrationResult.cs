using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Domain.DAO.Auth
{
    public class RegistrationResult
    {
        public bool Success { get; set; }
        public string UserId { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
