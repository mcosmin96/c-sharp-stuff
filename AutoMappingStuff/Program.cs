using AutoMapper;
using AutoMappingStuff.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingStuff
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mapcfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Store, StoreDto>();
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Seller, SellerDto>();
                cfg.CreateMap<Person, PersonDto>();
                cfg.CreateMap<Person, PersonDto>()
                .Include<Person, PersonDto>()
                .Include<Customer, CustomerDto>()
                .Include<Seller, SellerDto>();
                //cfg.CreateMap<Customer, CustomerDto>();
            });
            var mapper = mapcfg.CreateMapper();

            Customer c = new Customer() { Name = "Asd" };

            //CustomerDto cD = mapper.Map<CustomerDto>(c);

            Store s = new Store()
            {
                People = new Person[]
                {
                    new Customer() { Name = "Asd" },
                    new Seller() { CompanyName = "Ltd", Name = "Abc" }
                }
            };

            StoreDto sD = mapper.Map<StoreDto>(s);
        }
    }
}
