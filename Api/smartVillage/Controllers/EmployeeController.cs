using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using smartVillage.Dtos;
using smartVillage.Model;
using System.Web.Http.Cors;

namespace smartVillage.Controllers
{
    public class EmployeeController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
            [HttpPost]
            [Route("SaveEmployee")]
            public string SaveEmployee(EmployeeDto dataDto)
            {

                using (smartVillageDB context = new smartVillageDB())
                {

                    if (dataDto.Id > 0)
                    {
                        var editData = context.Employees.FirstOrDefault(x => x.Id == dataDto.Id);

                        editData.Name = dataDto.Name;
                        editData.MobileNo = dataDto.MobileNo;
                        editData.Email = dataDto.Email;
                        editData.Address = dataDto.Address;
                        editData.EmployeeCode = dataDto.EmployeeCode;
                        editData.StateId = dataDto.StateId;
                        editData.DistrictId = dataDto.DistrictId;
                        editData.VillageId = dataDto.VillageId;
                        editData.DesignationId = dataDto.DesignationId;
                        editData.DepartmentId = dataDto.DepartmentId;


                        if (dataDto.Photo != null && dataDto.Photo != "" && editData.Photo != dataDto.Photo && !dataDto.Photo.Contains("UploadedFiles"))
                        {
                            Guid id = Guid.NewGuid();
                            var imgData = dataDto.Photo.Substring(dataDto.Photo.IndexOf(",") + 1);
                            byte[] bytes = Convert.FromBase64String(imgData);
                            Image image;
                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                image = Image.FromStream(ms);
                            }
                            Bitmap b = new Bitmap(image);
                            string filePath = System.Web.HttpContext.Current.Server.MapPath("~") + "UploadedFiles\\" + id + ".jpg";
                            b.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            editData.Photo = string.Concat("UploadedFiles\\" + id + ".jpg");
                        }


                        context.Entry(editData).State = EntityState.Modified;
                        context.SaveChanges();
                        return "success";
                    }
                    else
                    {

                        var old = context.Employees.FirstOrDefault(x => x.IsActive && x.Email == dataDto.Email);
                        if (old != null)
                        {
                            return "Email Id Already Exist";
                        }

                       Employee addData = new Employee();

                        addData.Name = dataDto.Name;
                        addData.MobileNo = dataDto.MobileNo;
                        addData.Email = dataDto.Email;
                        addData.Date = DateTime.Now;
                        addData.Address = dataDto.Address;
                        addData.EmployeeCode = dataDto.EmployeeCode;
                        addData.StateId = dataDto.StateId;
                        addData.DistrictId = dataDto.DistrictId;
                        addData.VillageId = dataDto.VillageId;
                        addData.DesignationId = dataDto.DesignationId;
                        addData.DepartmentId = dataDto.DepartmentId;

                        if (dataDto.Photo != null && dataDto.Photo != "")
                        {
                            Guid id = Guid.NewGuid();
                            var imgData = dataDto.Photo.Substring(dataDto.Photo.IndexOf(",") + 1);
                            byte[] bytes = Convert.FromBase64String(imgData);
                            Image image;
                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                image = Image.FromStream(ms);
                            }
                            Bitmap b = new Bitmap(image);
                            string filePath = System.Web.HttpContext.Current.Server.MapPath("~") + "UploadedFiles\\" + id + ".jpg";
                            b.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            addData.Photo = string.Concat("UploadedFiles\\" + id + ".jpg");
                        }

                        addData.IsActive = true;

                        context.Employees.Add(addData);
                        context.SaveChanges();

                        User user = new User();

                        user.UserName = dataDto.Email;
                        user.IsActive = true;                      
                        user.Role = "Employee";
                        var passwordSalt = AuthenticationBL.CreatePasswordSalt(Encoding.ASCII.GetBytes(dataDto.Password));
                        user.PasswordSalt = Convert.ToBase64String(passwordSalt);
                        var password = AuthenticationBL.CreateSaltedPassword(passwordSalt, Encoding.ASCII.GetBytes(dataDto.Password));
                        user.Password = Convert.ToBase64String(password);

                        context.Users.Add(user);
                        context.SaveChanges();

                        return "success";
                    }

                }

            }
        

    [HttpGet]
    [Route("GetEmployee")]
    public List<EmployeeDto> GetEmployee()
    {

        using (smartVillageDB context = new smartVillageDB())
        {

            var dataList = context.Employees.Where(x => x.IsActive == true).Select(x => new EmployeeDto
            {
                Id = x.Id,
                Name = x.Name,
                MobileNo = x.MobileNo,
                Email = x.Email,
                Address = x.Address,
                Photo = x.Photo,
                Date = x.Date,
                StateId = x.StateId,
                State = new StateDto
                {
                    Id = x.State.Id,
                    Name = x.State.Name,
                },
                DistrictId = x.DistrictId,
                District = new DistrictDto
                {
                    Id = x.District.Id,
                    Name = x.District.Name,
                },

                VillageId = x.VillageId,
                Village = new VillageDto
                {
                    Id = x.Village.Id,
                    Name = x.Village.Name,
                },
                DesignationId = x.DesignationId,
                Designation = new DesignationDto
                {
                    Id = x.Designation.Id,
                    Name = x.Designation.Name,
                },
                DepartmentId = x.DepartmentId,
                Department = new DepartmentDto
                {
                    Id = x.Department.Id,
                    Name = x.Department.Name,
                },


                IsActive = x.IsActive,
            }).ToList();

            return dataList;

        }
    }
    [HttpGet]
    [Route("DeleteEmployee/{id}")]
    public bool DeleteEmployee(long id)
    {
        using (smartVillageDB context = new smartVillageDB())
        {
            var deleteData = context.Employees.FirstOrDefault(x => x.Id == id);
            deleteData.IsActive = false;

            context.Entry(deleteData).Property(x => x.IsActive).IsModified = true;
            context.SaveChanges();
        }

        return true;
    }



    [HttpGet]
    [Route("GetEmployeeById/{id}")]
    public EmployeeDto GetEmployeeById(long id)
    {
        using (smartVillageDB context = new smartVillageDB())
        {
            var dataSourceResult = context.Employees.Where(x => x.IsActive == true && x.Id == id)
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    Email = x.Email,
                    Address = x.Address,
                    DistrictId = x.DistrictId,
                    District = new DistrictDto
                    {
                        Id = x.District.Id,
                        Name = x.District.Name
                    },
                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },
                    VillageId = x.VillageId,
                    Village = new VillageDto
                    {
                        Id = x.Village.Id,
                        Name = x.Village.Name
                    },
                    DesignationId = x.DesignationId,
                    Designation = new DesignationDto
                    {
                        Id = x.Designation.Id,
                        Name = x.Designation.Name
                    },
                    DepartmentId = x.DepartmentId,
                    Department = new DepartmentDto
                    {
                        Id = x.Department.Id,
                        Name = x.Department.Name
                    }

                }).ToList().FirstOrDefault();

            return dataSourceResult;
        }
    }
        }
}