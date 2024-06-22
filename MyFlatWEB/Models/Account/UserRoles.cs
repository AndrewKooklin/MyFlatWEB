using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Models.Account
{
    public class UserRoles
    {
        public static string EMail { get; set; } = "";

        public static List<string> Roles { get; set; } = new List<string> { "Anonymus" };
    }
}
