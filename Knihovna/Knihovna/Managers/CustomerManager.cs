using Knihovna.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Managers
{
   public class CustomerManager
    {
        Repo<Customer>  CustomerRepository
        {
            get; set;
        }

        public CustomerManager(Repository repo)
        {
            CustomerRepository = new();
            CustomerRepository.col = repo.GetInstance().GetCollection<Customer>("customer");
        }

        public void addCustomer(Customer zakaznik)
        {
            CustomerRepository.Add(zakaznik);
        }
        public void removeCustomer(Customer zakaznik)
        {
            CustomerRepository.RemoveById(zakaznik.Id);
        }
        public void editCustomer(Customer zakaznik)
        {
            CustomerRepository.UpdateById(zakaznik);
        }
        public ObservableCollection<Customer> getCustomer()
        {

            return CustomerRepository.GetAll();
        }
        public Customer getCustomerById(int id)
        {
            return CustomerRepository.GetById(id);
        }
    }
}
