using MyFlatWEB.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Data
{
    public class DataManager
    {
        public IAccountRepository Accounts { get; set; }

        public IRenderingRepository Rendering { get; set; }

        public DataManager(IAccountRepository accounts,
                           IRenderingRepository rendering)
        {
            Accounts = accounts;
            Rendering = rendering;
        }
    }
}
