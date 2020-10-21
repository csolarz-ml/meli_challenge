using System;
using System.Collections.Generic;
using System.Text;

namespace MeLi_Topsecret.Domain
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
