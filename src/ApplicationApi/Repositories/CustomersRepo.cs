using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApi.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ApplicationApi.Repositories
{
    public class CustomersRepo : ICustomersRepo
    {
        private CustomerContext db = new CustomerContext();

        private byte[] ReadToEnd(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public Customer create_customer(CustomerViewModel custView)
        {
            Customer c = new Customer
            {
                name = custView.name,
                email = custView.email,
                contact = custView.contact,
                experienceCompany = custView.experienceCompany,
                experienceDate = custView.experienceDate,
                experienceInRole = custView.experienceInRole,
                experienceTitle = custView.experienceTitle,
                comment = custView.comment,
                cv = ReadToEnd(custView.cv)
            };
            db.Customers.Add(c);
            db.SaveChanges();
            return c;
        }

        public bool delete_customer(int key)
        {

            Customer cust = db.Customers.FirstOrDefault(c => c.id == key);
            if (cust != null)
            {
                db.Remove(cust);
                db.SaveChanges();
            }
            return (db.Customers.FirstOrDefault(c => c.id == key) == null);
        }

        public ICollection<Customer> get_all_customers()
        {
            return db.Customers.ToList();
        }

        public Customer get_customer(int key)
        {
            return db.Customers.FirstOrDefault(c => c.id == key);
        }

        public Customer update_customer(Customer c)
        {
            Customer original = db.Customers.FirstOrDefault(i => i.id == c.id);
            if (original == null)
                return null;
            original.name = c.name;
            original.email = c.email;
            original.contact = c.contact;
            // to-do
            db.SaveChanges();
            return original;
        }
    }
}
