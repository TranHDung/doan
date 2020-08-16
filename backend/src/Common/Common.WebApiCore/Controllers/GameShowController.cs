using Common.Services.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Common.Utils;
using Common.DTO;
using System.Linq;

namespace Common.WebApiCore.Controllers
{
    [Route("gameshow")]
    public class GameShowController : BaseApiController
    {
        private readonly IGameShowRepository _gameShowRepos;

        public GameShowController(IGameShowRepository gameShowRepos)
        {
            _gameShowRepos = gameShowRepos;
        }

        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var entity = await _gameShowRepos.GetAll().ToListAsync();
            return Ok(entity);
        }

        [HttpGet("open/{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> Open(string name)
        {
            var entity = new GameShow();
            entity.IsOpen = true;
            entity.IsOnline = true;
            entity.Name = name;
            var idGameShow = await _gameShowRepos.AddAndGetIdAsyn(entity);
            return Ok(idGameShow);
        }

        [HttpGet("close/{gameShowId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Close(int gameShowId)
        {
            var entity = await _gameShowRepos.FirstOrDefaultAsync(g => g.Id == gameShowId);
            entity.IsOnline = false;
            entity.IsOpen = false;
            _gameShowRepos.Update(entity);
            return Ok("Ok");
        }

        [HttpGet("start/{gameShowId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Start(int gameShowId)
        {
            var entity = await _gameShowRepos.FirstOrDefaultAsync(g => g.Id == gameShowId);
            entity.IsOpen = false;
            _gameShowRepos.Update(entity);
            return Ok("Ok");
        }

        [HttpPost]
        [Route("update")]
        [AllowAnonymous]
        public IActionResult Update(GameShowDTO dto)
        {

            var entity = dto.MapTo<GameShow>();

            _gameShowRepos.Update(entity);
            return Ok();
        }

        [HttpGet("remove/{id}")]
        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            _gameShowRepos.Remove(id);
            return Ok();
        }

        [HttpPost]
        [Route("add-question")]
        [AllowAnonymous]
        public async Task<IActionResult> AddQuestionGameShow(QuestionGameShow entity)
        {
            await _gameShowRepos.AddQuestionGameShow(entity);
            return Ok("Ok");
        }

        [HttpPost]
        [Route("join")]
        [AllowAnonymous]
        public async Task<IActionResult> Join(UserGameShow entity)
        {
            await _gameShowRepos.AddUserGameShow(entity);
            return Ok("Ok");
        }

        [HttpGet("joined/{gameShowId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Joined(int gameShowId)
        {
            var users = await _gameShowRepos.GetUsersJoinGameShow(gameShowId);
            return Ok(users);
        }

        [HttpGet("find")]
        [AllowAnonymous]
        public async Task<IActionResult> Find()
        {
            var entities = await _gameShowRepos.GetAll()
                                                .Where(g => g.IsOpen)
                                                .Select(g => new MiniGameShowDTO 
                                                { 
                                                    Id = g.Id,
                                                    Name = g.Name
                                                }).ToListAsync();
            return Ok(entities);
        }
    }
}