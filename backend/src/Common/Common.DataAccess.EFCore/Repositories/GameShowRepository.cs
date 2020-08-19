using Common.DataAccess.EFCore.Repositories;
using Common.DTO;
using Common.Entities;
using Common.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            entity.Created();
            await Context.UserGameShows.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task AddQuestionGameShow(QuestionGameShow entity)
        {
            entity.Created();
            await Context.QuestionGameShows.AddAsync(entity);
            await Context.SaveChangesAsync();
        }
        public async Task<int> AddAndGetIdAsyn(GameShow entity)
        {
            entity.Created();
            await Context.GameShows.AddAsync(entity);
            await SaveChangesAsync();
            return entity.Id;
        }

        public async Task<List<UserJoinGameShowDTO>> GetUsersJoinGameShow(int gameShowId)
        {
            var users = await Context.UserGameShows
                               .Include(u => u.GameShow)
                               .Include(u => u.User)
                               .Where(u => u.GameshowId == gameShowId)
                               .Select(u => new UserJoinGameShowDTO
                               {
                                   Name = u.User.Login,
                                   Id = u.Id,
                                   Score = u.Score
                               })
                               .ToListAsync();
            return users;
        }

        public async Task UpdateScore(UserGameShow data) 
        {
            var entity = await Context.UserGameShows.FirstOrDefaultAsync(u => u.UserId == data.UserId && u.GameshowId == data.GameshowId);
            entity.Score = data.Score;
            Context.UserGameShows.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
