using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Test.RepositoryCore.DAL
{
    public class DALBase
    {
        protected EssenceTesteContext contexto;

        public DALBase()
        {
            contexto = new EssenceTesteContext();
        }
    }
}
