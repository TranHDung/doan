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
    public class QuestionRepository: Repository<Question>, IQuestionRepository
    {
        private readonly DataContext Context;
        public QuestionRepository(DataContext context) : base(context)
        {
            Context = context;
        }

        public async Task AddQuestionGameShow(QuestionGameShow entity) 
        {
            await Context.QuestionGameShows.AddAsync(entity);
        }

        public async Task AddOrUpdateAnswer(UserGameShow data) 
        {
            var entity = Context.UserGameShows.FirstOrDefault(u => u.GameshowId == data.GameshowId && u.UserId == data.UserId);
            if (entity != null)
            {
                await Context.UserGameShows.AddAsync(entity);
            }
            else 
            {
                Context.UserGameShows.Update(entity);
            }
        }

        public async Task<Question> GetQuestionNewest(int gameShowId)
        {
            var question = Context.QuestionGameShows.Include(u => u.Question).Where(u => u.GameshowId == gameShowId).OrderByDescending(u => u.CreateAt).FirstOrDefault()?.Question;
            return question;
        }
    }
}
