using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using smartVillage.Dtos;
using smartVillage.Model;

namespace smartVillage.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SnehapoorvamController : ApiController
    {
        [HttpPost]
        [Route("SaveSnehapoorvam")]
        public string SaveSnehapoorvam(SnehapoorvamDto dataDto)
        {
            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var addData = context.Snehapoorvams.FirstOrDefault(x => x.Id == dataDto.Id);

                    addData.Name = dataDto.Name;
                    addData.MobileNo = dataDto.MobileNo;
                    addData.Address = dataDto.Address;
                    addData.PinCode = dataDto.PinCode;
                    addData.DOB = dataDto.DOB;
                    addData.Age = dataDto.Age;
                    addData.Gender = dataDto.Gender;
                    addData.School = dataDto.School;
                    addData.NatureOfSchool = dataDto.NatureOfSchool;
                    addData.ClassStudied = dataDto.ClassStudied;
                    addData.SchoolDistrict = dataDto.SchoolDistrict;
                    addData.JobType = dataDto.JobType;
                    addData.RevenueDistrict = dataDto.RevenueDistrict;
                    addData.FatherName = dataDto.FatherName;
                    addData.IsFatherAlive = dataDto.IsFatherAlive;
                    addData.MotherName = dataDto.MotherName;
                    addData.IsMotherAlive = dataDto.IsMotherAlive;
                    addData.GuardianName = dataDto.GuardianName;
                    addData.GuardianNameNo = dataDto.GuardianNameNo;
                    addData.GuardianAddress = dataDto.GuardianAddress;
                    addData.RelationshipwithStudent = dataDto.RelationshipwithStudent;

                    addData.CustomerId = dataDto.CustomerId;
                    addData.VillageId = dataDto.VillageId;
                    addData.DistrictId = dataDto.DistrictId;
                    addData.StateId = dataDto.StateId;

                    context.Entry(addData).State = EntityState.Modified;
                    context.SaveChanges();
                    return "success";
                }
                else
                {

                    Snehapoorvam addData = new Snehapoorvam();

                    addData.Date = DateTime.Now;

                    addData.Name = dataDto.Name;
                    addData.MobileNo = dataDto.MobileNo;
                    addData.Address = dataDto.Address;
                    addData.Age = dataDto.Age;
                    addData.PinCode = dataDto.PinCode;
                    addData.DOB = dataDto.DOB;
                    addData.Gender = dataDto.Gender;
                    addData.School = dataDto.School;
                    addData.NatureOfSchool = dataDto.NatureOfSchool;
                    addData.ClassStudied = dataDto.ClassStudied;
                    addData.SchoolDistrict = dataDto.SchoolDistrict;
                    addData.JobType = dataDto.JobType;
                    addData.RevenueDistrict = dataDto.RevenueDistrict;
                    addData.FatherName = dataDto.FatherName;
                    addData.IsFatherAlive = dataDto.IsFatherAlive;
                    addData.MotherName = dataDto.MotherName;
                    addData.IsMotherAlive = dataDto.IsMotherAlive;
                    addData.GuardianName = dataDto.GuardianName;
                    addData.GuardianNameNo = dataDto.GuardianNameNo;
                    addData.GuardianAddress = dataDto.GuardianAddress;
                    addData.RelationshipwithStudent = dataDto.RelationshipwithStudent;

                    addData.CustomerId = dataDto.CustomerId;
                    addData.VillageId = dataDto.VillageId;
                    addData.DistrictId = dataDto.DistrictId;
                    addData.StateId = dataDto.StateId;

                    context.Snehapoorvams.Add(addData);
                    context.SaveChanges();


                    return "success";
                }
            }
        }

        [HttpGet]
        [Route("SnehapoorvamsById/{id}")]
        public SnehapoorvamDto SnehapoorvamsById(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Snehapoorvams.Where(x => x.Id == id).Select(x => new SnehapoorvamDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    Address = x.Address,
                    Age = x.Age,
                    PinCode = x.PinCode,
                    DOB = x.DOB,
                    Gender = x.Gender,
                    School = x.School,
                    NatureOfSchool = x.NatureOfSchool,
                    ClassStudied = x.ClassStudied,
                    SchoolDistrict = x.SchoolDistrict,
                    JobType = x.JobType,
                    RevenueDistrict = x.RevenueDistrict,
                    FatherName = x.FatherName,
                    IsFatherAlive = x.IsFatherAlive,
                    MotherName = x.MotherName,
                    IsMotherAlive = x.IsMotherAlive,
                    GuardianName = x.GuardianName,
                    GuardianNameNo = x.GuardianNameNo,
                    GuardianAddress = x.GuardianAddress,
                    RelationshipwithStudent = x.RelationshipwithStudent,

                    CustomerId = x.CustomerId,
                    Customer = new CustomerDto
                    {
                        Id = x.Customer.Id,
                        Name = x.Customer.Name,
                    },
                    VillageId = x.VillageId,
                    Village = new VillageDto
                    {
                        Id = x.Village.Id,
                        Name = x.Village.Name,
                    },
                    DistrictId = x.DistrictId,
                    District = new DistrictDto
                    {
                        Id = x.District.Id,
                        Name = x.District.Name,
                    },
                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },

                    IssueDate = x.IssueDate,
                    IssueById = x.IssueById,
                    IssueBy = new UserDto
                    {
                        Id = x.IssueBy != null ? x.IssueBy.Id : 0,
                        UserName = x.IssueBy != null ? x.IssueBy.UserName : "",
                    },
                    ApproveById = x.ApproveById,
                    ApproveBy = new UserDto
                    {
                        Id = x.ApproveBy != null ? x.ApproveBy.Id : 0,
                        UserName = x.ApproveBy != null ? x.ApproveBy.UserName : "",
                    },
                }).ToList().FirstOrDefault();

                return dataList;

            }
        }

        [HttpGet]
        [Route("GetAllSnehapoorvams")]
        public List<SnehapoorvamDto> GetAllSnehapoorvams()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Snehapoorvams.Select(x => new SnehapoorvamDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    Address = x.Address,
                    Age = x.Age,
                    PinCode = x.PinCode,
                    DOB = x.DOB,
                    Gender = x.Gender,
                    School = x.School,
                    NatureOfSchool = x.NatureOfSchool,
                    ClassStudied = x.ClassStudied,
                    SchoolDistrict = x.SchoolDistrict,
                    JobType = x.JobType,
                    RevenueDistrict = x.RevenueDistrict,
                    FatherName = x.FatherName,
                    IsFatherAlive = x.IsFatherAlive,
                    MotherName = x.MotherName,
                    IsMotherAlive = x.IsMotherAlive,
                    GuardianName = x.GuardianName,
                    GuardianNameNo = x.GuardianNameNo,
                    GuardianAddress = x.GuardianAddress,
                    RelationshipwithStudent = x.RelationshipwithStudent,

                    CustomerId = x.CustomerId,
                    Customer = new CustomerDto
                    {
                        Id = x.Customer.Id,
                        Name = x.Customer.Name,
                    },
                    VillageId = x.VillageId,
                    Village = new VillageDto
                    {
                        Id = x.Village.Id,
                        Name = x.Village.Name,
                    },
                    DistrictId = x.DistrictId,
                    District = new DistrictDto
                    {
                        Id = x.District.Id,
                        Name = x.District.Name,
                    },
                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },

                    IssueDate = x.IssueDate,
                    IssueById = x.IssueById,
                    IssueBy = new UserDto
                    {
                        Id = x.IssueBy != null ? x.IssueBy.Id : 0,
                        UserName = x.IssueBy != null ? x.IssueBy.UserName : "",
                    },
                    ApproveById = x.ApproveById,
                    ApproveBy = new UserDto
                    {
                        Id = x.ApproveBy != null ? x.ApproveBy.Id : 0,
                        UserName = x.ApproveBy != null ? x.ApproveBy.UserName : "",
                    },
                }).ToList();

                return dataList;

            }
        }


        [HttpGet]
        [Route("SnehapoorvamsByCustomerId/{id}")]
        public List<SnehapoorvamDto> SnehapoorvamsByCustomerId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Snehapoorvams.Where(x => x.CustomerId == id).Select(x => new SnehapoorvamDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    Address = x.Address,
                    Age = x.Age,
                    PinCode = x.PinCode,
                    DOB = x.DOB,
                    Gender = x.Gender,
                    School = x.School,
                    NatureOfSchool = x.NatureOfSchool,
                    ClassStudied = x.ClassStudied,
                    SchoolDistrict = x.SchoolDistrict,
                    JobType = x.JobType,
                    RevenueDistrict = x.RevenueDistrict,
                    FatherName = x.FatherName,
                    IsFatherAlive = x.IsFatherAlive,
                    MotherName = x.MotherName,
                    IsMotherAlive = x.IsMotherAlive,
                    GuardianName = x.GuardianName,
                    GuardianNameNo = x.GuardianNameNo,
                    GuardianAddress = x.GuardianAddress,
                    RelationshipwithStudent = x.RelationshipwithStudent,

                    CustomerId = x.CustomerId,
                    Customer = new CustomerDto
                    {
                        Id = x.Customer.Id,
                        Name = x.Customer.Name,
                    },
                    VillageId = x.VillageId,
                    Village = new VillageDto
                    {
                        Id = x.Village.Id,
                        Name = x.Village.Name,
                    },
                    DistrictId = x.DistrictId,
                    District = new DistrictDto
                    {
                        Id = x.District.Id,
                        Name = x.District.Name,
                    },
                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },

                    IssueDate = x.IssueDate,
                    IssueById = x.IssueById,
                    IssueBy = new UserDto
                    {
                        Id = x.IssueBy != null ? x.IssueBy.Id : 0,
                        UserName = x.IssueBy != null ? x.IssueBy.UserName : "",
                    },
                    ApproveById = x.ApproveById,
                    ApproveBy = new UserDto
                    {
                        Id = x.ApproveBy != null ? x.ApproveBy.Id : 0,
                        UserName = x.ApproveBy != null ? x.ApproveBy.UserName : "",
                    },
                }).ToList();

                return dataList;

            }
        }

        [HttpGet]
        [Route("NewSnehapoorvamsByVillageId/{id}")]
        public List<SnehapoorvamDto> NewSnehapoorvamsByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Snehapoorvams.Where(x => x.VillageId == id && x.IssueById == null).Select(x => new SnehapoorvamDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    Address = x.Address,
                    Age = x.Age,
                    PinCode = x.PinCode,
                    DOB = x.DOB,
                    Gender = x.Gender,
                    School = x.School,
                    NatureOfSchool = x.NatureOfSchool,
                    ClassStudied = x.ClassStudied,
                    SchoolDistrict = x.SchoolDistrict,
                    JobType = x.JobType,
                    RevenueDistrict = x.RevenueDistrict,
                    FatherName = x.FatherName,
                    IsFatherAlive = x.IsFatherAlive,
                    MotherName = x.MotherName,
                    IsMotherAlive = x.IsMotherAlive,
                    GuardianName = x.GuardianName,
                    GuardianNameNo = x.GuardianNameNo,
                    GuardianAddress = x.GuardianAddress,
                    RelationshipwithStudent = x.RelationshipwithStudent,

                    CustomerId = x.CustomerId,
                    Customer = new CustomerDto
                    {
                        Id = x.Customer.Id,
                        Name = x.Customer.Name,
                    },
                    VillageId = x.VillageId,
                    Village = new VillageDto
                    {
                        Id = x.Village.Id,
                        Name = x.Village.Name,
                    },
                    DistrictId = x.DistrictId,
                    District = new DistrictDto
                    {
                        Id = x.District.Id,
                        Name = x.District.Name,
                    },
                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },

                    IssueDate = x.IssueDate,
                    IssueById = x.IssueById,
                    IssueBy = new UserDto
                    {
                        Id = x.IssueBy != null ? x.IssueBy.Id : 0,
                        UserName = x.IssueBy != null ? x.IssueBy.UserName : "",
                    },
                    ApproveById = x.ApproveById,
                    ApproveBy = new UserDto
                    {
                        Id = x.ApproveBy != null ? x.ApproveBy.Id : 0,
                        UserName = x.ApproveBy != null ? x.ApproveBy.UserName : "",
                    },
                }).ToList();

                return dataList;

            }
        }

        [HttpGet]
        [Route("SnehapoorvamsForApprovalByVillageId/{id}")]
        public List<SnehapoorvamDto> SnehapoorvamsForApprovalByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Snehapoorvams.Where(x => x.VillageId == id && x.ApproveById == null && x.IssueById != null).Select(x => new SnehapoorvamDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    Address = x.Address,
                    Age = x.Age,
                    PinCode = x.PinCode,
                    DOB = x.DOB,
                    Gender = x.Gender,
                    School = x.School,
                    NatureOfSchool = x.NatureOfSchool,
                    ClassStudied = x.ClassStudied,
                    SchoolDistrict = x.SchoolDistrict,
                    JobType = x.JobType,
                    RevenueDistrict = x.RevenueDistrict,
                    FatherName = x.FatherName,
                    IsFatherAlive = x.IsFatherAlive,
                    MotherName = x.MotherName,
                    IsMotherAlive = x.IsMotherAlive,
                    GuardianName = x.GuardianName,
                    GuardianNameNo = x.GuardianNameNo,
                    GuardianAddress = x.GuardianAddress,
                    RelationshipwithStudent = x.RelationshipwithStudent,

                    CustomerId = x.CustomerId,
                    Customer = new CustomerDto
                    {
                        Id = x.Customer.Id,
                        Name = x.Customer.Name,
                    },
                    VillageId = x.VillageId,
                    Village = new VillageDto
                    {
                        Id = x.Village.Id,
                        Name = x.Village.Name,
                    },
                    DistrictId = x.DistrictId,
                    District = new DistrictDto
                    {
                        Id = x.District.Id,
                        Name = x.District.Name,
                    },
                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },

                    IssueDate = x.IssueDate,
                    IssueById = x.IssueById,
                    IssueBy = new UserDto
                    {
                        Id = x.IssueBy != null ? x.IssueBy.Id : 0,
                        UserName = x.IssueBy != null ? x.IssueBy.UserName : "",
                    },
                    ApproveById = x.ApproveById,
                    ApproveBy = new UserDto
                    {
                        Id = x.ApproveBy != null ? x.ApproveBy.Id : 0,
                        UserName = x.ApproveBy != null ? x.ApproveBy.UserName : "",
                    },
                }).ToList();

                return dataList;

            }
        }

        [HttpGet]
        [Route("ApprovedSnehapoorvamsByVillageId/{id}")]
        public List<SnehapoorvamDto> ApprovedSnehapoorvamsByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {
                var dataList = context.Snehapoorvams.Where(x => x.VillageId == id && x.ApproveById != null).Select(x => new SnehapoorvamDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    Address = x.Address,
                    Age = x.Age,
                    PinCode = x.PinCode,
                    DOB = x.DOB,
                    Gender = x.Gender,
                    School = x.School,
                    NatureOfSchool = x.NatureOfSchool,
                    ClassStudied = x.ClassStudied,
                    SchoolDistrict = x.SchoolDistrict,
                    JobType = x.JobType,
                    RevenueDistrict = x.RevenueDistrict,
                    FatherName = x.FatherName,
                    IsFatherAlive = x.IsFatherAlive,
                    MotherName = x.MotherName,
                    IsMotherAlive = x.IsMotherAlive,
                    GuardianName = x.GuardianName,
                    GuardianNameNo = x.GuardianNameNo,
                    GuardianAddress = x.GuardianAddress,
                    RelationshipwithStudent = x.RelationshipwithStudent,

                    CustomerId = x.CustomerId,
                    Customer = new CustomerDto
                    {
                        Id = x.Customer.Id,
                        Name = x.Customer.Name,
                    },
                    VillageId = x.VillageId,
                    Village = new VillageDto
                    {
                        Id = x.Village.Id,
                        Name = x.Village.Name,
                    },
                    DistrictId = x.DistrictId,
                    District = new DistrictDto
                    {
                        Id = x.District.Id,
                        Name = x.District.Name,
                    },
                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },

                    IssueDate = x.IssueDate,
                    IssueById = x.IssueById,
                    IssueBy = new UserDto
                    {
                        Id = x.IssueBy != null ? x.IssueBy.Id : 0,
                        UserName = x.IssueBy != null ? x.IssueBy.UserName : "",
                    },
                    ApproveById = x.ApproveById,
                    ApproveBy = new UserDto
                    {
                        Id = x.ApproveBy != null ? x.ApproveBy.Id : 0,
                        UserName = x.ApproveBy != null ? x.ApproveBy.UserName : "",
                    },
                }).ToList();

                return dataList;

            }
        }

        [HttpGet]
        [Route("DeleteSnehapoorvam/{id}")]
        public string DeleteSnehapoorvam(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.Snehapoorvams.FirstOrDefault(x => x.Id == id);

                if (deleteData.IssueById != null)
                {
                    return "Request Under Process Cannot Delete Application.";
                }

                context.Snehapoorvams.Remove(deleteData);
                context.SaveChanges();
            }

            return "Success";
        }

    }
}
