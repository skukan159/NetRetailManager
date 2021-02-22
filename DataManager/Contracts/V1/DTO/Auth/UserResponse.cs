using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Contracts.V1.DTO.Auth
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public ICollection<int> UploadedMomentIds { get; set; }
        public ICollection<int> SavedMomentIds { get; set; }
        public ICollection<int> LikedTipIds { get; set; }
    }
}
