using System;
using Microsoft.AspNetCore.Identity;
using ShalanAppBE.Database.Enums;

namespace ShalanAppBE.Database.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Country Country { get; set; }

        public Position Position { get; set; }

        public Title Title { get; set; }

        public DateTime CrtDate { get; set; }
    }
}
