using System.Collections.Generic;

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
