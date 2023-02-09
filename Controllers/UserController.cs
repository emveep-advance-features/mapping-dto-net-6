using Microsoft.AspNetCore.Mvc;
using mapping_dto.Data;
using mapping_dto.Models;
using mapping_dto.Dtos;
using AutoMapper;

namespace simple.crud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public IActionResult create([FromForm] UserCreateDto userCreateDto)
        {
            var user = mapper.Map<User>(userCreateDto);
            repository.create(user);
            return Ok(user);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> getAll()
        {
            var users = repository.getAll();
            var mappedData = mapper.Map<IEnumerable<UserReadDto>>(users);
            return Ok(mappedData);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var user = repository.getUserById(id);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            var model = mapper.Map<UserReadDto>(user);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult update(int id, [FromForm] UserUpdateDto userUpdateDto)
        {
            var user = repository.getUserById(id);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            mapper.Map(userUpdateDto, user);
            repository.update(user);
            repository.saveChanges();
            return Ok("Success Update Data");
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            repository.delete(id);
            repository.saveChanges();
            return Ok("Deleted");
        }
    }
}