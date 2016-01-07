using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoASPMVC2.Service
{
    public class ProductsService
    {
        private CursoASPMVC2.Domain.CursoASPMVCEntities Entities;
        public ProductsService()
        {
            this.Entities = new Domain.CursoASPMVCEntities();
        }
        public CursoASPMVC2.Domain.CursoASPMVCEntities GetEntities()
        {
            return this.Entities;
        }
    }
}
