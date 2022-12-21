using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Model
{
    public class BorrowingModel
    {
    }
    public class Borrowing : INotifyPropertyChanged
    {
        private Book book;
        private Customer customer;
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }


        public Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                if (customer != value)
                {
                    customer = value;
                    RaisePropertyChanged("customer");
                }
            }
        }
        public Book Book
        {
            get { return book; }

            set
            {
                if (book != value)
                {
                    book = value;
                    RaisePropertyChanged("book");
                }
            }
        }
     

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}


