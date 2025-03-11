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
    public class MedisepController : ApiController
    {
        [HttpPost]
        [Route("SaveMedisep")]
        public string SaveMedisep(MedisepDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var addData = context.Mediseps.FirstOrDefault(x => x.Id == dataDto.Id);

                    addData.Name = dataDto.Name;
                    addData.MobileNo = dataDto.MobileNo;
                    addData.DOB = dataDto.DOB;
                    addData.Age = dataDto.Age;
                    addData.Gender = dataDto.Gender;
                    addData.RetirementDate = dataDto.RetirementDate;
                    addData.PostOffice = dataDto.PostOffice;
                    addData.PenNo = dataDto.PenNo;
                    addData.PPO = dataDto.PPO;
                    addData.Treasury = dataDto.Treasury;
                    addData.Agency = dataDto.Agency;
                    addData.PensionSchemesAvailed = dataDto.PensionSchemesAvailed;
                    addData.AadharNo = dataDto.AadharNo;
                    addData.IdNo = dataDto.IdNo;
                    addData.PANno = dataDto.PANno;
                    addData.BloodGroup = dataDto.BloodGroup;
                    addData.IsSchemeUser = dataDto.IsSchemeUser;
                    addData.SchemeNo = dataDto.SchemeNo;
                    addData.PermanentAddress = dataDto.PermanentAddress;
                    addData.IsAllowanceGranted = dataDto.IsAllowanceGranted;
                    addData.Allowance = dataDto.Allowance;
                    addData.IsChildScheme = dataDto.IsChildScheme;
                    addData.PartnerName = dataDto.PartnerName;
                    addData.PartnerAadharNo = dataDto.PartnerAadharNo;
                    addData.PartnerIdNo = dataDto.PartnerIdNo;
                    addData.PartnerBloodGroup = dataDto.PartnerBloodGroup;
                    addData.ChildName = dataDto.ChildName;
                    addData.ChildAadhar = dataDto.ChildAadhar;
                    addData.ChildIDno = dataDto.ChildIDno;
                    addData.ChildDOB = dataDto.ChildDOB;
                    addData.ChildGender = dataDto.ChildGender;
                    addData.ChildBloodGroup = dataDto.ChildBloodGroup;

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

                    Medisep addData = new Medisep();

                    addData.Date = DateTime.Now;

                    addData.Name = dataDto.Name;
                    addData.MobileNo = dataDto.MobileNo;
                    addData.DOB = dataDto.DOB;
                    addData.Age = dataDto.Age;
                    addData.Gender = dataDto.Gender;
                    addData.RetirementDate = dataDto.RetirementDate;
                    addData.PostOffice = dataDto.PostOffice;
                    addData.PenNo = dataDto.PenNo;
                    addData.PPO = dataDto.PPO;
                    addData.Treasury = dataDto.Treasury;
                    addData.Agency = dataDto.Agency;
                    addData.PensionSchemesAvailed = dataDto.PensionSchemesAvailed;
                    addData.AadharNo = dataDto.AadharNo;
                    addData.IdNo = dataDto.IdNo;
                    addData.PANno = dataDto.PANno;
                    addData.BloodGroup = dataDto.BloodGroup;
                    addData.IsSchemeUser = dataDto.IsSchemeUser;
                    addData.SchemeNo = dataDto.SchemeNo;
                    addData.PermanentAddress = dataDto.PermanentAddress;
                    addData.IsAllowanceGranted = dataDto.IsAllowanceGranted;
                    addData.Allowance = dataDto.Allowance;
                    addData.IsChildScheme = dataDto.IsChildScheme;
                    addData.PartnerName = dataDto.PartnerName;
                    addData.PartnerAadharNo = dataDto.PartnerAadharNo;
                    addData.PartnerIdNo = dataDto.PartnerIdNo;
                    addData.PartnerBloodGroup = dataDto.PartnerBloodGroup;
                    addData.ChildName = dataDto.ChildName;
                    addData.ChildAadhar = dataDto.ChildAadhar;
                    addData.ChildIDno = dataDto.ChildIDno;
                    addData.ChildDOB = dataDto.ChildDOB;
                    addData.ChildGender = dataDto.ChildGender;
                    addData.ChildBloodGroup = dataDto.ChildBloodGroup;

                    addData.CustomerId = dataDto.CustomerId;
                    addData.VillageId = dataDto.VillageId;
                    addData.DistrictId = dataDto.DistrictId;
                    addData.StateId = dataDto.StateId;

                    context.Mediseps.Add(addData);
                    context.SaveChanges();


                    return "success";
                }
            }
        }

        [HttpGet]
        [Route("MedisepsById/{id}")]
        public MedisepDto MedisepsById(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Mediseps.Where(x => x.Id == id).Select(x => new MedisepDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    DOB = x.DOB,
                    Age = x.Age,
                    Gender = x.Gender,
                    RetirementDate = x.RetirementDate,
                    PostOffice = x.PostOffice,
                    PenNo = x.PenNo,
                    PPO = x.PPO,
                    Treasury = x.Treasury,
                    Agency = x.Agency,
                    PensionSchemesAvailed = x.PensionSchemesAvailed,
                    AadharNo = x.AadharNo,
                    IdNo = x.IdNo,
                    PANno = x.PANno,
                    BloodGroup = x.BloodGroup,
                    IsSchemeUser = x.IsSchemeUser,
                    SchemeNo = x.SchemeNo,
                    PermanentAddress = x.PermanentAddress,
                    IsAllowanceGranted = x.IsAllowanceGranted,
                    Allowance = x.Allowance,
                    IsChildScheme = x.IsChildScheme,
                    PartnerName = x.PartnerName,
                    PartnerAadharNo = x.PartnerAadharNo,
                    PartnerIdNo = x.PartnerIdNo,
                    PartnerBloodGroup = x.PartnerBloodGroup,
                    ChildName = x.ChildName,
                    ChildAadhar = x.ChildAadhar,
                    ChildIDno = x.ChildIDno,
                    ChildDOB = x.ChildDOB,
                    ChildGender = x.ChildGender,
                    ChildBloodGroup = x.ChildBloodGroup,

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
        [Route("GetAllMediseps")]
        public List<MedisepDto> GetAllMediseps()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Mediseps.Select(x => new MedisepDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    DOB = x.DOB,
                    Age = x.Age,
                    Gender = x.Gender,
                    RetirementDate = x.RetirementDate,
                    PostOffice = x.PostOffice,
                    PenNo = x.PenNo,
                    PPO = x.PPO,
                    Treasury = x.Treasury,
                    Agency = x.Agency,
                    PensionSchemesAvailed = x.PensionSchemesAvailed,
                    AadharNo = x.AadharNo,
                    IdNo = x.IdNo,
                    PANno = x.PANno,
                    BloodGroup = x.BloodGroup,
                    IsSchemeUser = x.IsSchemeUser,
                    SchemeNo = x.SchemeNo,
                    PermanentAddress = x.PermanentAddress,
                    IsAllowanceGranted = x.IsAllowanceGranted,
                    Allowance = x.Allowance,
                    IsChildScheme = x.IsChildScheme,
                    PartnerName = x.PartnerName,
                    PartnerAadharNo = x.PartnerAadharNo,
                    PartnerIdNo = x.PartnerIdNo,
                    PartnerBloodGroup = x.PartnerBloodGroup,
                    ChildName = x.ChildName,
                    ChildAadhar = x.ChildAadhar,
                    ChildIDno = x.ChildIDno,
                    ChildDOB = x.ChildDOB,
                    ChildGender = x.ChildGender,
                    ChildBloodGroup = x.ChildBloodGroup,

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
                        Id = x.IssueBy != null? x.IssueBy.Id : 0,
                        UserName = x.IssueBy != null? x.IssueBy.UserName : "",
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
        [Route("MedisepsByCustomerId/{id}")]
        public List<MedisepDto> MedisepsByCustomerId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Mediseps.Where(x => x.CustomerId == id).Select(x => new MedisepDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    DOB = x.DOB,
                    Age = x.Age,
                    Gender = x.Gender,
                    RetirementDate = x.RetirementDate,
                    PostOffice = x.PostOffice,
                    PenNo = x.PenNo,
                    PPO = x.PPO,
                    Treasury = x.Treasury,
                    Agency = x.Agency,
                    PensionSchemesAvailed = x.PensionSchemesAvailed,
                    AadharNo = x.AadharNo,
                    IdNo = x.IdNo,
                    PANno = x.PANno,
                    BloodGroup = x.BloodGroup,
                    IsSchemeUser = x.IsSchemeUser,
                    SchemeNo = x.SchemeNo,
                    PermanentAddress = x.PermanentAddress,
                    IsAllowanceGranted = x.IsAllowanceGranted,
                    Allowance = x.Allowance,
                    IsChildScheme = x.IsChildScheme,
                    PartnerName = x.PartnerName,
                    PartnerAadharNo = x.PartnerAadharNo,
                    PartnerIdNo = x.PartnerIdNo,
                    PartnerBloodGroup = x.PartnerBloodGroup,
                    ChildName = x.ChildName,
                    ChildAadhar = x.ChildAadhar,
                    ChildIDno = x.ChildIDno,
                    ChildDOB = x.ChildDOB,
                    ChildGender = x.ChildGender,
                    ChildBloodGroup = x.ChildBloodGroup,

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
        [Route("NewMedisepsByVillageId/{id}")]
        public List<MedisepDto> NewMedisepsByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Mediseps.Where(x => x.VillageId == id && x.IssueById == null).Select(x => new MedisepDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    DOB = x.DOB,
                    Age = x.Age,
                    Gender = x.Gender,
                    RetirementDate = x.RetirementDate,
                    PostOffice = x.PostOffice,
                    PenNo = x.PenNo,
                    PPO = x.PPO,
                    Treasury = x.Treasury,
                    Agency = x.Agency,
                    PensionSchemesAvailed = x.PensionSchemesAvailed,
                    AadharNo = x.AadharNo,
                    IdNo = x.IdNo,
                    PANno = x.PANno,
                    BloodGroup = x.BloodGroup,
                    IsSchemeUser = x.IsSchemeUser,
                    SchemeNo = x.SchemeNo,
                    PermanentAddress = x.PermanentAddress,
                    IsAllowanceGranted = x.IsAllowanceGranted,
                    Allowance = x.Allowance,
                    IsChildScheme = x.IsChildScheme,
                    PartnerName = x.PartnerName,
                    PartnerAadharNo = x.PartnerAadharNo,
                    PartnerIdNo = x.PartnerIdNo,
                    PartnerBloodGroup = x.PartnerBloodGroup,
                    ChildName = x.ChildName,
                    ChildAadhar = x.ChildAadhar,
                    ChildIDno = x.ChildIDno,
                    ChildDOB = x.ChildDOB,
                    ChildGender = x.ChildGender,
                    ChildBloodGroup = x.ChildBloodGroup,

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
        [Route("MedisepsForApprovalByVillageId/{id}")]
        public List<MedisepDto> MedisepsForApprovalByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Mediseps.Where(x => x.VillageId == id && x.ApproveById == null && x.IssueById != null).Select(x => new MedisepDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    DOB = x.DOB,
                    Age = x.Age,
                    Gender = x.Gender,
                    RetirementDate = x.RetirementDate,
                    PostOffice = x.PostOffice,
                    PenNo = x.PenNo,
                    PPO = x.PPO,
                    Treasury = x.Treasury,
                    Agency = x.Agency,
                    PensionSchemesAvailed = x.PensionSchemesAvailed,
                    AadharNo = x.AadharNo,
                    IdNo = x.IdNo,
                    PANno = x.PANno,
                    BloodGroup = x.BloodGroup,
                    IsSchemeUser = x.IsSchemeUser,
                    SchemeNo = x.SchemeNo,
                    PermanentAddress = x.PermanentAddress,
                    IsAllowanceGranted = x.IsAllowanceGranted,
                    Allowance = x.Allowance,
                    IsChildScheme = x.IsChildScheme,
                    PartnerName = x.PartnerName,
                    PartnerAadharNo = x.PartnerAadharNo,
                    PartnerIdNo = x.PartnerIdNo,
                    PartnerBloodGroup = x.PartnerBloodGroup,
                    ChildName = x.ChildName,
                    ChildAadhar = x.ChildAadhar,
                    ChildIDno = x.ChildIDno,
                    ChildDOB = x.ChildDOB,
                    ChildGender = x.ChildGender,
                    ChildBloodGroup = x.ChildBloodGroup,

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
        [Route("ApprovedMedisepsByVillageId/{id}")]
        public List<MedisepDto> ApprovedMedisepsByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {
                var dataList = context.Mediseps.Where(x => x.VillageId == id && x.ApproveById != null).Select(x => new MedisepDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    DOB = x.DOB,
                    Age = x.Age,
                    Gender = x.Gender,
                    RetirementDate = x.RetirementDate,
                    PostOffice = x.PostOffice,
                    PenNo = x.PenNo,
                    PPO = x.PPO,
                    Treasury = x.Treasury,
                    Agency = x.Agency,
                    PensionSchemesAvailed = x.PensionSchemesAvailed,
                    AadharNo = x.AadharNo,
                    IdNo = x.IdNo,
                    PANno = x.PANno,
                    BloodGroup = x.BloodGroup,
                    IsSchemeUser = x.IsSchemeUser,
                    SchemeNo = x.SchemeNo,
                    PermanentAddress = x.PermanentAddress,
                    IsAllowanceGranted = x.IsAllowanceGranted,
                    Allowance = x.Allowance,
                    IsChildScheme = x.IsChildScheme,
                    PartnerName = x.PartnerName,
                    PartnerAadharNo = x.PartnerAadharNo,
                    PartnerIdNo = x.PartnerIdNo,
                    PartnerBloodGroup = x.PartnerBloodGroup,
                    ChildName = x.ChildName,
                    ChildAadhar = x.ChildAadhar,
                    ChildIDno = x.ChildIDno,
                    ChildDOB = x.ChildDOB,
                    ChildGender = x.ChildGender,
                    ChildBloodGroup = x.ChildBloodGroup,

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
        [Route("DeleteMedisep/{id}")]
        public string DeleteMedisep(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.Mediseps.FirstOrDefault(x => x.Id == id);

                if (deleteData.IssueById != null)
                {
                    return "Request Under Process Cannot Delete Application.";
                }

                context.Mediseps.Remove(deleteData);
                context.SaveChanges();
            }

            return "Success";
        }
    }
}
