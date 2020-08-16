using Common.Services.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Common.DTO;
using Common.Utils;
using System.Linq;
using Common.Services.Infrastructure;
using Common.DataAccess.EFCore.Repositories;

namespace Common.WebApiCore.Controllers
{
    [Route("question")]
    public class QuestionController : BaseApiController
    {
        private readonly IQuestionRepository _questionRepos;

        public QuestionController(IQuestionRepository questionRepos)
        {
            _questionRepos = questionRepos;
        }

        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var entity = await _questionRepos.GetAll().ToListAsync();
            return Ok(entity);
        }

        [HttpGet("get/{gameShowId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetQuestionNewest(int gameShowId)
        {
            var dto = _questionRepos.GetQuestionNewest(gameShowId).MapTo<QuestionDTO>(); ;
            return Ok(dto);
        }

        [HttpGet]
        [Route("list/{userId:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> List(int userId)
        {
            var entity = await _questionRepos.GetAll().Where(q => q.UserId == userId).ToListAsync();
            return Ok(entity);
        }

        [HttpPost]
        [Route("add-question-gameshow")]
        [AllowAnonymous]
        public async Task<IActionResult> AddQuestionGameshow(QuestionGameShow entity)
        {
            await _questionRepos.AddQuestionGameShow(entity);
            return Ok();
        }

        [HttpPost]
        [Route("add")]
        [AllowAnonymous]
        public async Task<IActionResult> Add(QuestionDTO dto)
        {

            var entity = dto.MapTo<Question>();

            await _questionRepos.AddAsync(entity);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        [AllowAnonymous]
        public IActionResult Update(QuestionDTO dto)
        {

            var entity = dto.MapTo<Question>();

            _questionRepos.Update(entity);
            return Ok();
        }

        [HttpGet]
        [Route("remove/{id:int}")]
        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            _questionRepos.Remove(id);
            return Ok();
        }

        [HttpPost]
        [Route("answer")]
        [AllowAnonymous]
        public async Task<IActionResult> Answer(UserGameShow entity)
        {
            await _questionRepos.AddOrUpdateAnswer(entity);
            return Ok("Ok");
        }
    }
}