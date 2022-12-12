using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Knihovna
{

    internal class Repo<TKey,Tvalue>
    {
        LiteDatabase database;


        public void Connect()
        {
            try
            {
                database = new LiteDatabase(@"C:\Users\st64521\Documents\GitHub\SemestralniPraceBCSH2\Knihovna\Db\MyDb.db");

            }catch (Exception e)
            {

            }

        }
        public LiteDatabase GetInstance()
        {
            if (database != null) return database;
            else return null;
        }
        public void GetById()
        {
          LiteDatabase db= GetInstance();
            try
            {
                var col = db.GetCollection<TKey>("vypujcky");
            }
            catch(Exception)
            {

            }
        }
        public void UpdateById(TKey a )
        {
            LiteDatabase db = GetInstance();
            try
            {
                var col = db.GetCollection<TKey>("vypujcky");
                col.Update(a);
            }
            catch (Exception)
            {

            }
        }
        public void RemoveById(TKey a)
        {
            LiteDatabase db = GetInstance();
            try
            {
                var col = db.GetCollection<TKey>("vypujcky");
                var value = new LiteDB.BsonValue(a);
                col.Delete(value);
            }
            catch (Exception)
            {

            }
        }
        public void GetAll()
        {
            LiteDatabase db = GetInstance();
            try
            {
                var col = db.GetCollection<TKey>();
            }
            catch (Exception)
            {

            }
        }




    }
}
