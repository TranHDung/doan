using Common.DataAccess.EFCore.Repositories;
using Common.DTO;
using Common.Entities;
using Common.Services.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
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
    }
}
