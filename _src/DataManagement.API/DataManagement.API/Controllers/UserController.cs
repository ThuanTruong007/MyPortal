using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataManagement.Business.Interfaces;
using DataManagement.Entities;
using System.Threading.Tasks;
using DataManagement.Repository.Interfaces;
using DataManagement.ApplicationService.Query;
using DataManagement.ApplicationService.Command;
// For more information on enabling Web API for empty projects, visit https//go.microsoft.com/fwlink/?LinkID=397860  
namespace DataManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserManager _userManager;
        readonly IAppDbRepository<User> _appDbRepository;
        readonly IUserRepository _userRepository;
        readonly IAppConfigRepository _appConfigRepository;
        readonly IQueryHandler<GetUserByIdQuery, User> _userByIdHandler;
        readonly ICommandHandler<DeleteUserByIdCommand, bool> _deleteUserByIdHandler;

        //public UserController(IUserManager userManager, IRepository<User> userRepository)
        public UserController(IAppDbRepository<User> userRepository
            , IUserRepository userRepository1
            , IUserManager userManager
            , IAppConfigRepository appConfigRepository
            , IQueryHandler<GetUserByIdQuery, User> userByIdHandler
            , ICommandHandler<DeleteUserByIdCommand, bool> deleteUserByIdHandler)

        {
            _userManager = userManager;
            _userRepository = userRepository1;
            _appDbRepository = userRepository;
            _appConfigRepository = appConfigRepository;
            _userByIdHandler = userByIdHandler;
            _deleteUserByIdHandler = deleteUserByIdHandler;
        }
        // GET<td style="border<td style="border: 1px dashed #ababab;"> 1px dashed #ababab;"> api/user  
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var result = await _userRepository.GetAllUser();
            var result1 = await _userManager.GetAllUser();
            //var message = _appConfigRepository.GetMessage();
            return Ok(result1);
        }
        // GET api/user/5  
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userManager.GetUserById(id);
            //var result =  _userManager.GetUserById(id);
            result = await _userByIdHandler.HandlerAsync(new GetUserByIdQuery() {UserId=id });
            return Ok(result);
        }

        // GET api/user/5,test  
        [HttpGet("{id}/{name}")]
        public async Task<IActionResult> Get(int id, string name)
        {
            var result = await _userManager.GetUserById(id);
            //var result =  _userManager.GetUserById(id);
            result = await _userByIdHandler.HandlerAsync(new GetUserByIdQuery() { UserId = id });
            return Ok(result);
        }
        //// POST api/user  
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            //_userManager.Insert(user);
            var result1 = await _userManager.AddUser(user);

            var result = await _userRepository.AddUser(user);
            user.UserId = result;

            return Ok(user);
        }
        //// PUT api/user/5  
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] User user)
        //{
        //    _userManager.UpdateUser(user); 
        //}
        // DELETE api/user/5  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userManager.DeleteUser(id);
            return Ok(result);
        }

        //GET api/user/5  
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var result = _userRepository.Get(id);
        //    return Ok(result);
        //}
    }
}