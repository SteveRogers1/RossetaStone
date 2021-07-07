using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RossetaStone.Models
{
    public static class Role
    {
        public const string Administrator = "Admin";
        public const string User = "User";

        public static IEnumerable<string> AllRoles
        {
            get
            {
                yield return Administrator;
                yield return User;
            }
        }

    }
}
