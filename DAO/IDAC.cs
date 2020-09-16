using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAC
    {
        List<T> GetList<T>(T Model);
        List<T> GetList<T>();
        T GetFirst<T>(T Model);
        T GetFirst<T>(int id);
        void Insert<T>(T Model);
        void Update<T>(T Model);
        void Delete(int[] id);
    }
}
