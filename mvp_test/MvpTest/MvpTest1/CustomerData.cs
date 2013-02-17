using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{
    class CustomerData
    {
        public CustomerModel ReadData(string _id)
        {
            CustomerModel customer = new CustomerModel();
            customer.CustomerIdInput = _id ;
            customer.CustomerName = _id + "abcd";
            return customer;
        }
    }
}
