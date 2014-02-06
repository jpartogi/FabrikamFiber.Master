namespace FabrikamFiber.DAL.Services
{
    using System;
    using System.Collections.Generic;

    using DAL.Data;
    using DAL.Models;

    public interface IEmployeeService
    {
        IEnumerable<Employee> All();

        Employee Find(int id);

        void InsertOrUpdate(Employee customer);

        void Delete(int id);

        void Save();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> All()
        {
            return employeeRepository.All;
        }

        public Employee Find(int id)
        {
            return employeeRepository.Find(id);
        }

        public void InsertOrUpdate(Employee employee)
        {
            employeeRepository.InsertOrUpdate(employee);
        }

        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }

        public void Save()
        {
            employeeRepository.Save();
        }
    }
}
