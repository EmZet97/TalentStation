using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TalentStation.Models.Common;
using TalentStation.Models.Database;
using TalentStation.Models.Database.DbModels;
using TalentStation.Models.Helpers;

namespace TalentStation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TalentStationDbContext _context;
        private readonly IMapper _mapper;

        public UserController(TalentStationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserResponse>> PutUserAsync([FromHeader] int? id, [FromBody] UserRequest user)
        {
            if(id is not null)
            {
                return await UpdateUserAsync(id.GetValueOrDefault(), user);
            }
            else
            {
                return await CreateNewUserAsync(user);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDbModel[]>> GetUsersAsync(int? id)
        {
            var users = id is not null ?
                await _context.Users.Where(u => u.Id == id).ToArrayAsync() :
                await _context.Users.ToArrayAsync();

            return users;
        }

        private async Task<ActionResult<UserResponse>> CreateNewUserAsync(UserRequest user)
        {
            if (await _context.Users.Where(u => u.Email.ToLower() == user.Email.ToLower()).SingleOrDefaultAsync() is not null)
            {
                return Conflict("Email address already in use");
            }

            var db_user = _mapper.Map<UserDbModel>(user);

            var db_password = new PasswordDbModel()
            {
                Password = Sha256Generator.ComputeString(user.Password),
                TimeStamp = DateTime.Now,
                User = db_user
            };

            await _context.Users.AddAsync(db_user);
            await _context.Passwords.AddAsync(db_password);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(db_user);
        }

        private async Task<ActionResult<UserResponse>> UpdateUserAsync(int id, UserRequest userUpdate)
        {
            var db_user = await _context.Users.AsNoTracking().Where(u => u.Id == id).FirstOrDefaultAsync();

            if(db_user is null)
            {
                return NotFound();
            }

            var db_password = await _context.Passwords.AsNoTracking().Where(p => p.UserId == db_user.Id).OrderBy(p => p.TimeStamp).LastAsync();

            if(db_password.Password != Sha256Generator.ComputeString(userUpdate.Password))
            {
                var new_password = new PasswordDbModel()
                {
                    Password = Sha256Generator.ComputeString(userUpdate.Password),
                    TimeStamp = DateTime.Now,
                    UserId = id
                };

                await _context.Passwords.AddAsync(new_password);
            }

            var updatedUser = _mapper.Map<UserDbModel>(userUpdate);
            updatedUser.Id = id;

            _context.Users.Update(updatedUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(updatedUser);
        }
    }
}
