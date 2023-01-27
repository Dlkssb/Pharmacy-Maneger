using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Maneger.IRepository
{
    public interface IRepository<T> where T : class
    {

        public T Get();
        public T GetEl(int Id);

        public void Delete(int id);
        public int Insert(T entity);
        public int Update(T entity);


    }
}
