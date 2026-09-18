using SenToxRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenToxService.Base
{
    public interface IBaseService<T> where T : class, new()
    {
        IBaseRepository<T> Rep { get; }
    }
}
