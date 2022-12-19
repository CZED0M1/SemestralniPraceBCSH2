using Knihovna.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Knihovna
{
    public class Repository
    {
        public LiteDatabase database
        {
            get; set;  
        }

        public Repository()
        {
            string _BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            database = new LiteDatabase(Path.GetFullPath(Path.Combine(_BaseDirectory, @"..\..\..\..\Db\MyDb.db")));
        }

        public LiteDatabase GetInstance()
        {
            return database;
        }
    }
    internal class Repo<TKey>
    {
        public string text
        {
            get; set;
        }
        public ILiteCollection<TKey> col { get; set; }
        public TKey GetById(int id)
        {

            try
            {
                return col.FindById(id);
            }
            catch(Exception)
            {

            }
            return default(TKey);
        }

        public void UpdateById(TKey a )
        {
            try
            {
                col.Update(a);
            }
            catch (Exception)
            {

            }
        }

        public void RemoveById(int id)
        {

            try
            {
                var value = new LiteDB.BsonValue(id);
                col.Delete(value);
            }
            catch (Exception)
            {

            }
        }

        public ObservableCollection<TKey> GetAll()
        {
            IEnumerable<TKey> ienu = col.FindAll();
            ObservableCollection<TKey> collection = new ObservableCollection<TKey>();
            foreach (var item in ienu)
            {
                collection.Add(item);
            }
            return collection;
            
        }

        public void Add(TKey a)
        {
            col.Insert(a);
        }




    }
}
