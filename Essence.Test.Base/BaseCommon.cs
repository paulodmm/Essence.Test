using Essence.Test.RepositoryCore;
using Essence.Test.RepositoryCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Test.Base
{
    public class BaseCommon
    {
        public static void Register(object iServiceCollectionservices, string connectionString)
        {
            EssenceTesteContextFactory.Register(iServiceCollectionservices, connectionString);
        }
    }
}
