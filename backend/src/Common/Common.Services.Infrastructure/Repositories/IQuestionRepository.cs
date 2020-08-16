using Common.DTO;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task AddQuestionGameShow(QuestionGameShow entity);
        Task AddOrUpdateAnswer(UserGameShow entity);
        Task<Question> GetQuestionNewest(int gameShowId);
    }
}
