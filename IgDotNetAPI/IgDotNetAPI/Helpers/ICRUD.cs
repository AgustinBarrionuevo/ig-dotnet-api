using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgDotNetAPI.Helpers
{
    interface ICRUD<T>
    {
        public void Create(T entity, ApplicationDbContext Context);
        public void Update(T entity, ApplicationDbContext Context);
        public void Delete(T entity, ApplicationDbContext Context);
    }
}
