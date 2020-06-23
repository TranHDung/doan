using Common.DataAccess.EFCore.Repositories;
using Common.Entities;
using Common.Services.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataAccess.EFCore
{
    public class QuestionRepository: Repository<Question>, IQuestionRepository
    {
        private readonly DataContext Context;
        public QuestionRepository(DataContext context) : base(context)
        {
            Context = context;
        }
    }
}
