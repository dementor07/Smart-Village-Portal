using smartVillage.Dtos;
using smartVillage.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace smartVillage.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("SaveUser")]
        public string SaveUser(UserDto userDto)
        {
            if (userDto != null)
            {
                using (smartVillageDB context = new smartVillageDB())
                {

                    var token = Request.Headers.Authorization.Parameter;
                    UserSession userSession = AuthenticationBL.IsTokenValid(token);
                    var usert = context.Users.FirstOrDefault(X => X.Id == userSession.UserId);

                    if (userDto.Id <= 0)
                    {

                        var old = context.Users.Where(x => x.UserName == userDto.UserName).Count();
                        if (old > 0)
                        {
                            return "User Name Already Exist";
                        }

                        User user = new User();
                        user.UserName = userDto.UserName;
                        user.Role = userDto.Role;
                        user.CustomerId = userDto.CustomerId;

                        var passwordSalt = AuthenticationBL.CreatePasswordSalt(Encoding.ASCII.GetBytes(userDto.Password));
                        user.PasswordSalt = Convert.ToBase64String(passwordSalt);
                        var password = AuthenticationBL.CreateSaltedPassword(passwordSalt, Encoding.ASCII.GetBytes(userDto.Password));
                        user.Password = Convert.ToBase64String(password);

                        context.Users.Add(user);
                        context.SaveChanges();


                        return "Success";
                    }
                    else
                    {
                        var old = context.Users.Where(x => x.UserName == userDto.UserName && x.Id != userDto.Id).Count();
                        if (old > 0)
                        {
                            return "User Name Already Exist";
                        }

                        var oldData = context.Users.FirstOrDefault(x => x.Id == userDto.Id);

                        if (oldData != null)
                        {
                            oldData.UserName = userDto.UserName;
                            oldData.Role = userDto.Role;
                            oldData.CustomerId = userDto.CustomerId;


                            var passwordSalt = AuthenticationBL.CreatePasswordSalt(Encoding.ASCII.GetBytes(userDto.Password));
                            oldData.PasswordSalt = Convert.ToBase64String(passwordSalt);
                            var password = AuthenticationBL.CreateSaltedPassword(passwordSalt, Encoding.ASCII.GetBytes(userDto.Password));
                            oldData.Password = Convert.ToBase64String(password);


                            context.Entry(oldData).State = EntityState.Modified;

                            context.SaveChanges();


                            return "Success";

                        }
                    }


                    return "Failed";
                }
            }
            return "Failed";
        }



        [HttpGet]
        [Route("GetUsers")]
        public List<UserDto> GetUsers()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Users.Where(x => x.Role != "SA" && x.Role != "CA").Select(x => new UserDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Role = x.Role,
                    IsBlocked = x.IsBlocked,
                    CustomerId = x.CustomerId,
                    Customer = new CustomerDto
                    {
                        Id = x.Customer != null ? x.Customer.Id : 0,
                        Name = x.Customer != null ? x.Customer.Name : "",
                        MobileNo = x.Customer != null ? x.Customer.MobileNo : "",
                    },

                    

                    IsActive = x.IsActive,
                }).ToList();

                return dataList;

            }
        }


        [HttpGet]
        [Route("BlockUser/{Id}")]
        public string BlockUser(long Id)
        {
            if (Id > 0)
            {
                using (smartVillageDB context = new smartVillageDB())
                {
                    var deleteData = context.Users.FirstOrDefault(x => x.Id == Id);

                    if (deleteData != null)
                    {
                        if (deleteData.IsBlocked)
                        {
                            deleteData.IsBlocked = false;
                            context.Entry(deleteData).Property(x => x.IsBlocked).IsModified = true;
                            context.SaveChanges();
                        }
                        else
                        {
                            deleteData.IsBlocked = true;
                            context.Entry(deleteData).Property(x => x.IsBlocked).IsModified = true;
                            context.SaveChanges();
                        }
                        return "Success";
                    }
                    return "Failed";
                }
            }
            return "Failed";
        }

        [HttpPost]
        [Route("UsersInAdmin")]
        public List<UserDto> UsersInAdmin(UserDto Request)
        {
            using (smartVillageDB context = new smartVillageDB())
            {

                var query = context.Users.Where(x => x.Id > 0);

                if (Request.Role != null && Request.Role != "")
                {
                    query = query.Where(x => x.Role == Request.Role);
                }

                var dataSourceResult = query
                    .Select(x => new UserDto
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        Role = x.Role,
                        IsBlocked = x.IsBlocked,
                        CustomerId = x.CustomerId,
                        Customer = new CustomerDto
                        {
                            Id = x.Customer != null ? x.Customer.Id : 0,
                            Name = x.Customer != null ? x.Customer.Name : "",
                            MobileNo = x.Customer != null ? x.Customer.MobileNo : "",
                        },
                      

                    }).OrderByDescending(x => x.Id).ToList();

                return dataSourceResult;
            }
        }
    }
}
