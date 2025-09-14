using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.ISystemServices
{
    public interface IUserBasicData
    {
        string GetRoleName();
        Guid GetUserId();
    }
}
