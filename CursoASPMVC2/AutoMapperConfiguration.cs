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
            AutoMapper.Mapper.CreateMap<CursoASPMVC2.Domain.Invoice, CursoASPMVC2.ViewModel.EditInvoiceComplete>();
            AutoMapper.Mapper.CreateMap<CursoASPMVC2.Domain.Invoice, CursoASPMVC2.ViewModel.DetailsInvoice>();
            AutoMapper.Mapper.CreateMap<CursoASPMVC2.Domain.InvoiceLine, CursoASPMVC2.ViewModel.DetailsInvoiceLine>();
            AutoMapper.Mapper.CreateMap<Service.DTO.Invoice, CursoASPMVC2.ViewModel.CreateInvoiceComplete>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers.Select(u => new System.Web.Mvc.SelectListItem
                            {
                                Text = u.Name,
                                Value = u.CustomerId.ToString()
                            }).ToList()))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(u => new System.Web.Mvc.SelectListItem
                {
                    Text = u.Title,
                    Value = u.ProductId.ToString()
                }).ToList()));

            //Capa de aplicación
            AutoMapper.Mapper.CreateMap<CursoASPMVC2.Domain.Invoice, CursoASPMVC2.Service.DTO.Invoice>();

#if DEBUG
            //AutoMapper.Mapper.AssertConfigurationIsValid();
#endif
            //AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}