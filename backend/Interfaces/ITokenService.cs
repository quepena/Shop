using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace backend.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}