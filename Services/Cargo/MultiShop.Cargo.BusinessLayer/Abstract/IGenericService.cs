using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetAll();
        void TInsert(T entity);
        void TUpdate(T entity);
        T TGetById(int id);
        void TDelete(int id);
    }
}
