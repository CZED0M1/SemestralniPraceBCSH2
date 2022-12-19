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
        Repo<Zakaznik>  CustomerRepository
        {
            get; set;
        }

        public CustomerManager(Repository repo)
        {
            CustomerRepository = new();
            CustomerRepository.col = repo.GetInstance().GetCollection<Zakaznik>("zakaznik");
        }

        public void addCustomer(Zakaznik zakaznik)
        {
            CustomerRepository.Add(zakaznik);
        }
        public void removeCustomer(Zakaznik zakaznik)
        {
            CustomerRepository.RemoveById(zakaznik.Id);
        }
        public void editCustomer(Zakaznik zakaznik)
        {
            CustomerRepository.UpdateById(zakaznik);
        }
        public ObservableCollection<Zakaznik> getCustomer()
        {

            return CustomerRepository.GetAll();
        }
        public Zakaznik getCustomerById(int id)
        {
            return CustomerRepository.GetById(id);
        }
    }
}
