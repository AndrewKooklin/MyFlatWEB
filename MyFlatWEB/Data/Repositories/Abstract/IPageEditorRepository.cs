﻿using MyFlatWEB.Areas.Management.Models.EditPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Data.Repositories.Abstract
{
    public interface IPageEditorRepository
    {
        HomePagePlaceholderModel GetHomePagePlaceholder(); 
    }
}
