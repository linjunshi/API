using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApi.Models;

namespace ApplicationApi.Repositories
{
    interface ICustomersRepo
    {
        Customer create_customer (CustomerViewModel c);
        bool delete_customer (string email);
        ICollection<Customer> get_all_customers();
        Customer get_customer (string email);
        Task<Customer> update_customer(CustomerViewModel custView);
    }
}
