using ShalanAppBE.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShalanAppBE.Models
{
    public class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Country { get; set; }

        public int Position { get; set; }

        public int Title { get; set; }

        public DateTime CrtDate { get; set; }

        public static explicit operator User(Database.Entities.User user)
        {
            if (user == null)
            {
                return null;
            }

            User result = new User();

            result.Id = user.Id;
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.Country = (int)user.Country;
            result.Position = (int)user.Position;
            result.Title = (int)user.Title;
            result.CrtDate = user.CrtDate;

            return result;
        }

        public static explicit operator Database.Entities.User(User user)
        {
            if (user == null)
            {
                return null;
            }

            Database.Entities.User result = new Database.Entities.User();

            result.Id = user.Id;
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.Country = (Country)user.Country;
            result.Position = (Position)user.Position;
            result.Title = (Title)user.Title;
            result.CrtDate = user.CrtDate;

            return result;
        }

        public static List<User> ToModel(List<Database.Entities.User> users)
        {
            List<User> result = new List<User>();

            users.ForEach(x => {
                result.Add((User)x);
            });

            return result;
        }
    }
}
