using System;
using System.Collections.Generic;

namespace MyFlatWEB.Models
{
    public class UserRoles
    {
        public static string EMail { get; set; } = "";

        public static List<string> Roles { get; set; } = new List<string> { "Anonymus" };
    }
}
