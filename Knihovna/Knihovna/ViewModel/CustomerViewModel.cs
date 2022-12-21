using Knihovna.Managers;
using Knihovna.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Knihovna.ViewModel
{
    public class CustomerViewModel
    {
        public static ObservableCollection<Customer>? Customers
        {
            get;
            set;
        }
        public static CustomerManager CustomerManager { get; set; }
        public static void LoadZakaznici(Repository repository)
        {



            CustomerManager customerManager = new(repository);
            CustomerManager = customerManager;
            if (customerManager.getCustomer().Count() == 0)
            {
                Customers.Add(new Customer { Name = "Dominik", Surrname = "Lopauer", LibraryId = 0 });
                Customers.Add(new Customer { Name = "Pavel", Surrname = "Horňak", LibraryId = 1 });
                Customers.Add(new Customer { Name = "Petr", Surrname = "Dolňak", LibraryId = 1 });
                CustomerViewModel.Customers[0].Borrowed = 2;
                CustomerViewModel.Customers[1].Borrowed = 1;

                foreach (var item in Customers)
                {
                    customerManager.addCustomer(item);
                }
            }
            else
            {

                IEnumerable<Customer> Lb = customerManager.getCustomer();
                foreach (var item in Lb)
                {
                    Customers.Add(item);
                }
            }
        }
    }
}