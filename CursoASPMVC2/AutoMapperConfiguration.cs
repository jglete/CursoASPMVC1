using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoASPMVC2
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper()
        {
            AutoMapper.Mapper.CreateMap<CursoASPMVC2.ViewModel.CreateInvoice, CursoASPMVC2.Domain.Invoice>();

#if DEBUG
            //AutoMapper.Mapper.AssertConfigurationIsValid();
#endif
            //AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}