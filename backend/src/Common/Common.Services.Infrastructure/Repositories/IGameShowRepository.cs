using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure.Repositories
{
    public interface IGameShowRepository : IRepository<GameShow>
    {
        Task AddUserGameShow(UserGameShow entity);
    }
}
