namespace FabrikamFiber.DAL.Services
{
    using System;
    using System.Collections.Generic;

    using DAL.Data;
    using DAL.Models;

    public interface ICustomerService
    {
        IEnumerable<Customer> All();

        Customer Find(int id);

        void InsertOrUpdate(Customer customer);

        void Delete(int id);

        void Save();
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Customer> All()
        {
            return customerRepository.All;
        }

        public Customer Find(int id)
        {
            return customerRepository.Find(id);
        }

        public void InsertOrUpdate(Customer customer)
        {
            customerRepository.InsertOrUpdate(customer);
        }

        public void Delete(int id)
        {
            customerRepository.Delete(id);
        }

        public void Save()
        {
            customerRepository.Save();
        }
    }
}
