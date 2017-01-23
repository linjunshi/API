using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApi.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace ApplicationApi.Repositories
{
    public class CustomersRepo : ICustomersRepo
    {
        private CustomerContext _db;

        public CustomersRepo (CustomerContext db)
        {
            _db = db;
        }

        private byte[] ReadToEnd(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public bool delete_customer(string email)
        {
            Customer cust = _db.Customers.FirstOrDefault(c => c.email == email);
            if (cust != null)
            {
                _db.Remove(cust);
                _db.SaveChanges();
            }
            return (_db.Customers.FirstOrDefault(c => c.email == email) == null);
        }

        public ICollection<Customer> get_all_customers()
        {
            return _db.Customers.ToList();
        }

        public Customer get_customer(CustomerViewModel custView)
        {
            return _db.Customers.FirstOrDefault(c => 
                (c.email == custView.email && c.experienceTitle == custView.experienceTitle)
            );
        }

        public async Task<Customer> create_customer(CustomerViewModel custView)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomerViewModel, Customer>();
                //cfg.CreateMap<IFormFile, byte[]>().ConstructUsing(ReadToEnd);
            });
            Customer c = Mapper.Map<Customer>(custView);
            _db.Customers.Add(c);
            _db.SaveChanges();
            await save_user_file(custView);
            return c;
        }

        public async Task<Customer> update_customer(CustomerViewModel custView)
        {
            Customer original = _db.Customers.FirstOrDefault(i => i.email == custView.email && i.experienceTitle == custView.experienceTitle);
            if (original == null)
                return null;

            // updating
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomerViewModel, Customer>();
            });
            Mapper.Map(custView, original);
            try {
                _db.SaveChanges();
            } catch (Exception e)
            {

            }
            // save files
            await save_user_file(custView);
            return original;
        }

        private async Task<bool> save_user_file(CustomerViewModel custView)
        {
            try {
                Directory.Delete($"CustumerFiles/{custView.email}_{custView.experienceTitle}", true);
            } catch { }

            Directory.CreateDirectory($"CustumerFiles/{custView.email}_{custView.experienceTitle}");
            using (var f = new FileStream($"CustumerFiles/{custView.email}_{custView.experienceTitle}/{custView.cv.FileName}", FileMode.Create))
            {
                await custView.cv.CopyToAsync(f);
            }
            return true;
        }
    }
}

// C:\Users\edward.lin\Documents\Visual Studio 2015\Projects\ApplicationApi\src\ApplicationApi\CustumerFiles