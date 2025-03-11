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
    public class IndiraGandhiNationalWidowPensionController : ApiController
    {
        [HttpPost]
        [Route("SaveIndiraGandhiNationalWidowPension")]
        public string SaveIndiraGandhiNationalWidowPension(IndiraGandhiNationalWidowPensionDto dataDto)
        {
            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var addData = context.IndiraGandhiNationalWidowPensions.FirstOrDefault(x => x.Id == dataDto.Id);

                    addData.Name = dataDto.Name;
                    addData.PensionCode = dataDto.PensionCode;
                    addData.CareOf = dataDto.CareOf;
                    addData.Gender = dataDto.Gender;
                    addData.WardNumber = dataDto.WardNumber;
                    addData.HouseNumber = dataDto.HouseNumber;
                    addData.Address = dataDto.Address;
                    addData.PostOffice = dataDto.PostOffice;
                    addData.Pincode = dataDto.Pincode;
                    addData.MobileNumber = dataDto.MobileNumber;
                    addData.RationCardNumber = dataDto.RationCardNumber;
                    addData.Income = dataDto.Income;
                    addData.WardMemberName = dataDto.WardMemberName;
                    addData.ModeOfPayment = dataDto.ModeOfPayment;
                    addData.IsServicePension = dataDto.IsServicePension;
                    addData.IsIncomeTaxPayable = dataDto.IsIncomeTaxPayable;
                    addData.IsEmployeeProvidentPensionTaker = dataDto.IsEmployeeProvidentPensionTaker;
                    addData.LandOwnership = dataDto.LandOwnership;
                    addData.ResidingYears = dataDto.ResidingYears;

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

                    IndiraGandhiNationalWidowPension addData = new IndiraGandhiNationalWidowPension();

                    addData.Date = DateTime.Now;

                    addData.Name = dataDto.Name;
                    addData.PensionCode = dataDto.PensionCode;
                    addData.CareOf = dataDto.CareOf;
                    addData.Gender = dataDto.Gender;
                    addData.WardNumber = dataDto.WardNumber;
                    addData.HouseNumber = dataDto.HouseNumber;
                    addData.Address = dataDto.Address;
                    addData.PostOffice = dataDto.PostOffice;
                    addData.Pincode = dataDto.Pincode;
                    addData.MobileNumber = dataDto.MobileNumber;
                    addData.RationCardNumber = dataDto.RationCardNumber;
                    addData.Income = dataDto.Income;
                    addData.WardMemberName = dataDto.WardMemberName;
                    addData.ModeOfPayment = dataDto.ModeOfPayment;
                    addData.IsServicePension = dataDto.IsServicePension;
                    addData.IsIncomeTaxPayable = dataDto.IsIncomeTaxPayable;
                    addData.IsEmployeeProvidentPensionTaker = dataDto.IsEmployeeProvidentPensionTaker;
                    addData.LandOwnership = dataDto.LandOwnership;
                    addData.ResidingYears = dataDto.ResidingYears;

                    addData.CustomerId = dataDto.CustomerId;
                    addData.VillageId = dataDto.VillageId;
                    addData.DistrictId = dataDto.DistrictId;
                    addData.StateId = dataDto.StateId;

                    context.IndiraGandhiNationalWidowPensions.Add(addData);
                    context.SaveChanges();


                    return "success";
                }
            }
        }

        [HttpGet]
        [Route("IndiraGandhiNationalWidowPensionsById/{id}")]
        public IndiraGandhiNationalWidowPensionDto IndiraGandhiNationalWidowPensionsById(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IndiraGandhiNationalWidowPensions.Where(x => x.Id == id).Select(x => new IndiraGandhiNationalWidowPensionDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    PensionCode = x.PensionCode,
                    CareOf = x.CareOf,
                    Gender = x.Gender,
                    WardNumber = x.WardNumber,
                    HouseNumber = x.HouseNumber,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    MobileNumber = x.MobileNumber,
                    RationCardNumber = x.RationCardNumber,
                    Income = x.Income,
                    WardMemberName = x.WardMemberName,
                    ModeOfPayment = x.ModeOfPayment,
                    IsServicePension = x.IsServicePension,
                    IsIncomeTaxPayable = x.IsIncomeTaxPayable,
                    IsEmployeeProvidentPensionTaker = x.IsEmployeeProvidentPensionTaker,
                    LandOwnership = x.LandOwnership,
                    ResidingYears = x.ResidingYears,

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
        [Route("GetAllIndiraGandhiNationalWidowPensions")]
        public List<IndiraGandhiNationalWidowPensionDto> GetAllIndiraGandhiNationalWidowPensions()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IndiraGandhiNationalWidowPensions.Select(x => new IndiraGandhiNationalWidowPensionDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    PensionCode = x.PensionCode,
                    CareOf = x.CareOf,
                    Gender = x.Gender,
                    WardNumber = x.WardNumber,
                    HouseNumber = x.HouseNumber,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    MobileNumber = x.MobileNumber,
                    RationCardNumber = x.RationCardNumber,
                    Income = x.Income,
                    WardMemberName = x.WardMemberName,
                    ModeOfPayment = x.ModeOfPayment,
                    IsServicePension = x.IsServicePension,
                    IsIncomeTaxPayable = x.IsIncomeTaxPayable,
                    IsEmployeeProvidentPensionTaker = x.IsEmployeeProvidentPensionTaker,
                    LandOwnership = x.LandOwnership,
                    ResidingYears = x.ResidingYears,

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
        [Route("IndiraGandhiNationalWidowPensionsByCustomerId/{id}")]
        public List<IndiraGandhiNationalWidowPensionDto> IndiraGandhiNationalWidowPensionsByCustomerId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IndiraGandhiNationalWidowPensions.Where(x => x.CustomerId == id).Select(x => new IndiraGandhiNationalWidowPensionDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    PensionCode = x.PensionCode,
                    CareOf = x.CareOf,
                    Gender = x.Gender,
                    WardNumber = x.WardNumber,
                    HouseNumber = x.HouseNumber,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    MobileNumber = x.MobileNumber,
                    RationCardNumber = x.RationCardNumber,
                    Income = x.Income,
                    WardMemberName = x.WardMemberName,
                    ModeOfPayment = x.ModeOfPayment,
                    IsServicePension = x.IsServicePension,
                    IsIncomeTaxPayable = x.IsIncomeTaxPayable,
                    IsEmployeeProvidentPensionTaker = x.IsEmployeeProvidentPensionTaker,
                    LandOwnership = x.LandOwnership,
                    ResidingYears = x.ResidingYears,

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
        [Route("NewIndiraGandhiNationalWidowPensionsByVillageId/{id}")]
        public List<IndiraGandhiNationalWidowPensionDto> NewIndiraGandhiNationalWidowPensionsByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IndiraGandhiNationalWidowPensions.Where(x => x.VillageId == id && x.IssueById == null).Select(x => new IndiraGandhiNationalWidowPensionDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    PensionCode = x.PensionCode,
                    CareOf = x.CareOf,
                    Gender = x.Gender,
                    WardNumber = x.WardNumber,
                    HouseNumber = x.HouseNumber,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    MobileNumber = x.MobileNumber,
                    RationCardNumber = x.RationCardNumber,
                    Income = x.Income,
                    WardMemberName = x.WardMemberName,
                    ModeOfPayment = x.ModeOfPayment,
                    IsServicePension = x.IsServicePension,
                    IsIncomeTaxPayable = x.IsIncomeTaxPayable,
                    IsEmployeeProvidentPensionTaker = x.IsEmployeeProvidentPensionTaker,
                    LandOwnership = x.LandOwnership,
                    ResidingYears = x.ResidingYears,

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
        [Route("IndiraGandhiNationalWidowPensionsForApprovalByVillageId/{id}")]
        public List<IndiraGandhiNationalWidowPensionDto> IndiraGandhiNationalWidowPensionsForApprovalByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IndiraGandhiNationalWidowPensions.Where(x => x.VillageId == id && x.ApproveById == null && x.IssueById != null).Select(x => new IndiraGandhiNationalWidowPensionDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    PensionCode = x.PensionCode,
                    CareOf = x.CareOf,
                    Gender = x.Gender,
                    WardNumber = x.WardNumber,
                    HouseNumber = x.HouseNumber,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    MobileNumber = x.MobileNumber,
                    RationCardNumber = x.RationCardNumber,
                    Income = x.Income,
                    WardMemberName = x.WardMemberName,
                    ModeOfPayment = x.ModeOfPayment,
                    IsServicePension = x.IsServicePension,
                    IsIncomeTaxPayable = x.IsIncomeTaxPayable,
                    IsEmployeeProvidentPensionTaker = x.IsEmployeeProvidentPensionTaker,
                    LandOwnership = x.LandOwnership,
                    ResidingYears = x.ResidingYears,

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
        [Route("ApprovedIndiraGandhiNationalWidowPensionsByVillageId/{id}")]
        public List<IndiraGandhiNationalWidowPensionDto> ApprovedIndiraGandhiNationalWidowPensionsByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {
                var dataList = context.IndiraGandhiNationalWidowPensions.Where(x => x.VillageId == id && x.ApproveById != null).Select(x => new IndiraGandhiNationalWidowPensionDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    PensionCode = x.PensionCode,
                    CareOf = x.CareOf,
                    Gender = x.Gender,
                    WardNumber = x.WardNumber,
                    HouseNumber = x.HouseNumber,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    MobileNumber = x.MobileNumber,
                    RationCardNumber = x.RationCardNumber,
                    Income = x.Income,
                    WardMemberName = x.WardMemberName,
                    ModeOfPayment = x.ModeOfPayment,
                    IsServicePension = x.IsServicePension,
                    IsIncomeTaxPayable = x.IsIncomeTaxPayable,
                    IsEmployeeProvidentPensionTaker = x.IsEmployeeProvidentPensionTaker,
                    LandOwnership = x.LandOwnership,
                    ResidingYears = x.ResidingYears,

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
        [Route("DeleteIndiraGandhiNationalWidowPension/{id}")]
        public string DeleteIndiraGandhiNationalWidowPension(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.IndiraGandhiNationalWidowPensions.FirstOrDefault(x => x.Id == id);

                if (deleteData.IssueById != null)
                {
                    return "Request Under Process Cannot Delete Application.";
                }

                context.IndiraGandhiNationalWidowPensions.Remove(deleteData);
                context.SaveChanges();
            }

            return "Success";
        }

    }
}
