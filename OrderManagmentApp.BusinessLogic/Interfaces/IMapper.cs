using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.BusinessLogic.Interfaces
{
    public interface IMapper<Tin, Tout>
    {
        public Tout Map(Tin model);
    }
}
