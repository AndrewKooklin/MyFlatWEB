﻿using MyFlatWEB.Data.Repositories.Abstract;

namespace MyFlatWEB.Data
{
    public class DataManager
    {
        public IAccountRepository Accounts { get; set; }

        public IRenderingRepository Rendering { get; set; }

        public IPageEditorRepository PageEditor { get; set; }

        public DataManager(IAccountRepository accounts,
                           IRenderingRepository rendering,
                           IPageEditorRepository pageEditor)
        {
            Accounts = accounts;
            Rendering = rendering;
            PageEditor = pageEditor;
        }
    }
}
