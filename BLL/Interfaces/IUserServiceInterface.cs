using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Infrastructure;

namespace BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserBLL userDto);
        Task<ClaimsIdentity> Authenticate(UserBLL userDto);
        Task SetInitialData(UserBLL adminDto, List<string> roles);
    }
}
