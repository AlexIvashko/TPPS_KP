using System.Collections.Generic;

namespace travel_agency.DAO
{
    public interface IGenericDAO <T>
    {
        void SaveOrUpdate(T item);
        T GetById(long id);
        List<T> GetAll();
        void Delete(T item);
    }
}
