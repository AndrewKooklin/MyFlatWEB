using System.Collections.Generic;

namespace MyFlatWEB.Models.Account
{
    public class UserRolesModel
    {
        public static string EMail { get; set; } = "";

        public static List<string> Roles { get; set; } = new List<string> { "Anonymus" };
    }
}
