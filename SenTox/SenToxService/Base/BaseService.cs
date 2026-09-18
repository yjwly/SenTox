using SenToxRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenToxService.Base
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        public IBaseRepository<T> Rep { get; }

        public BaseService(IBaseRepository<T> rep)
        {
            Rep = rep;
        }
    }
}
