using Common.DataAccess.EFCore.Repositories;
using Common.Entities;
using Common.Services.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataAccess.EFCore
{
    public class GameShowRepository: Repository<GameShow>, IGameShowRepository
    {
        private readonly DataContext Context;
        public GameShowRepository(DataContext context) : base(context)
        {
            Context = context;
        }
        public async Task AddUserGameShow(UserGameShow entity)
        {
            await Context.UserGameShows.AddAsync(entity);
        }
    }
}
