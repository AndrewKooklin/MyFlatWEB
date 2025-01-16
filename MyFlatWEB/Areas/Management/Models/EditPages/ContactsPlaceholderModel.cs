using MyFlatWEB.Models.Rendering;
using System;
using System.Collections.Generic;

namespace MyFlatWEB.Areas.Management.Models.EditPages
{
    public class ContactsPlaceholderModel
    {
        public ContactModel Contacts { get; set; }

        public List<SocialModel> SocialLinks { get; set; }
    }
}
