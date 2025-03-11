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
    public class VayomadhuramController : ApiController
    {
        [HttpPost]
        [Route("SaveVayomadhuram")]
        public string SaveVayomadhuram(VayomadhuramDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var addData = context.Vayomadhurams.FirstOrDefault(x => x.Id == dataDto.Id);

                    addData.Name = dataDto.Name;
                    addData.DOB = dataDto.DOB;
                    addData.Age = dataDto.Age;
                    addData.PermanentAddress = dataDto.PermanentAddress;
                    addData.PresentAddress = dataDto.PresentAddress;
                    addData.MobileNo = dataDto.MobileNo;
                    addData.AadharNo = dataDto.AadharNo;
                    addData.RationCardNo = dataDto.RationCardNo;
                    addData.RationPriority = dataDto.RationPriority;
                    addData.IsSelfAttested = dataDto.IsSelfAttested;
                    addData.IsDiabetic = dataDto.IsDiabetic;
                    addData.IsGlucoseMeterUser = dataDto.IsGlucoseMeterUser;
                    addData.HospitalName = dataDto.HospitalName;
                    addData.DiabeticPeriod = dataDto.DiabeticPeriod;
                    addData.DocName = dataDto.DocName;
                    addData.IdMark = dataDto.IdMark;
                    addData.TreatmentDuration = dataDto.TreatmentDuration;
                    addData.Designation = dataDto.Designation;
                    addData.RegNo = dataDto.RegNo;
                    addData.Place = dataDto.Place;

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

                    Vayomadhuram addData = new Vayomadhuram();

                    addData.Date = DateTime.Now;

                    addData.Name = dataDto.Name;
                    addData.DOB = dataDto.DOB;
                    addData.Age = dataDto.Age;
                    addData.PermanentAddress = dataDto.PermanentAddress;
                    addData.PresentAddress = dataDto.PresentAddress;
                    addData.MobileNo = dataDto.MobileNo;
                    addData.AadharNo = dataDto.AadharNo;
                    addData.RationCardNo = dataDto.RationCardNo;
                    addData.RationPriority = dataDto.RationPriority;
                    addData.IsSelfAttested = dataDto.IsSelfAttested;
                    addData.IsDiabetic = dataDto.IsDiabetic;
                    addData.IsGlucoseMeterUser = dataDto.IsGlucoseMeterUser;
                    addData.HospitalName = dataDto.HospitalName;
                    addData.DiabeticPeriod = dataDto.DiabeticPeriod;
                    addData.DocName = dataDto.DocName;
                    addData.IdMark = dataDto.IdMark;
                    addData.TreatmentDuration = dataDto.TreatmentDuration;
                    addData.Designation = dataDto.Designation;
                    addData.RegNo = dataDto.RegNo;
                    addData.Place = dataDto.Place;

                    addData.CustomerId = dataDto.CustomerId;
                    addData.VillageId = dataDto.VillageId;
                    addData.DistrictId = dataDto.DistrictId;
                    addData.StateId = dataDto.StateId;

                    context.Vayomadhurams.Add(addData);
                    context.SaveChanges();


                    return "success";
                }
            }
        }

        [HttpGet]
        [Route("VayomadhuramsById/{id}")]
        public VayomadhuramDto VayomadhuramsById(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Vayomadhurams.Where(x => x.Id == id).Select(x => new VayomadhuramDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    DOB = x.DOB,
                    Age = x.Age,
                    PermanentAddress = x.PermanentAddress,
                    PresentAddress = x.PresentAddress,
                    MobileNo = x.MobileNo,
                    AadharNo = x.AadharNo,
                    RationCardNo = x.RationCardNo,
                    RationPriority = x.RationPriority,
                    IsSelfAttested = x.IsSelfAttested,
                    IsDiabetic = x.IsDiabetic,
                    IsGlucoseMeterUser = x.IsGlucoseMeterUser,
                    HospitalName = x.HospitalName,
                    DiabeticPeriod = x.DiabeticPeriod,
                    DocName = x.DocName,
                    IdMark = x.IdMark,
                    TreatmentDuration = x.TreatmentDuration,
                    Designation = x.Designation,
                    RegNo = x.RegNo,
                    Place = x.Place,

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
        [Route("GetAllVayomadhurams")]
        public List<VayomadhuramDto> GetAllVayomadhurams()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Vayomadhurams.Select(x => new VayomadhuramDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    DOB = x.DOB,
                    Age = x.Age,
                    PermanentAddress = x.PermanentAddress,
                    PresentAddress = x.PresentAddress,
                    MobileNo = x.MobileNo,
                    AadharNo = x.AadharNo,
                    RationCardNo = x.RationCardNo,
                    RationPriority = x.RationPriority,
                    IsSelfAttested = x.IsSelfAttested,
                    IsDiabetic = x.IsDiabetic,
                    IsGlucoseMeterUser = x.IsGlucoseMeterUser,
                    HospitalName = x.HospitalName,
                    DiabeticPeriod = x.DiabeticPeriod,
                    DocName = x.DocName,
                    IdMark = x.IdMark,
                    TreatmentDuration = x.TreatmentDuration,
                    Designation = x.Designation,
                    RegNo = x.RegNo,
                    Place = x.Place,

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
        [Route("VayomadhuramsByCustomerId/{id}")]
        public List<VayomadhuramDto> VayomadhuramsByCustomerId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Vayomadhurams.Where(x => x.CustomerId == id).Select(x => new VayomadhuramDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    DOB = x.DOB,
                    Age = x.Age,
                    PermanentAddress = x.PermanentAddress,
                    PresentAddress = x.PresentAddress,
                    MobileNo = x.MobileNo,
                    AadharNo = x.AadharNo,
                    RationCardNo = x.RationCardNo,
                    RationPriority = x.RationPriority,
                    IsSelfAttested = x.IsSelfAttested,
                    IsDiabetic = x.IsDiabetic,
                    IsGlucoseMeterUser = x.IsGlucoseMeterUser,
                    HospitalName = x.HospitalName,
                    DiabeticPeriod = x.DiabeticPeriod,
                    DocName = x.DocName,
                    IdMark = x.IdMark,
                    TreatmentDuration = x.TreatmentDuration,
                    Designation = x.Designation,
                    RegNo = x.RegNo,
                    Place = x.Place,

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
        [Route("NewVayomadhuramsByVillageId/{id}")]
        public List<VayomadhuramDto> NewVayomadhuramsByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Vayomadhurams.Where(x => x.VillageId == id && x.IssueById == null).Select(x => new VayomadhuramDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    DOB = x.DOB,
                    Age = x.Age,
                    PermanentAddress = x.PermanentAddress,
                    PresentAddress = x.PresentAddress,
                    MobileNo = x.MobileNo,
                    AadharNo = x.AadharNo,
                    RationCardNo = x.RationCardNo,
                    RationPriority = x.RationPriority,
                    IsSelfAttested = x.IsSelfAttested,
                    IsDiabetic = x.IsDiabetic,
                    IsGlucoseMeterUser = x.IsGlucoseMeterUser,
                    HospitalName = x.HospitalName,
                    DiabeticPeriod = x.DiabeticPeriod,
                    DocName = x.DocName,
                    IdMark = x.IdMark,
                    TreatmentDuration = x.TreatmentDuration,
                    Designation = x.Designation,
                    RegNo = x.RegNo,
                    Place = x.Place,

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
        [Route("VayomadhuramsForApprovalByVillageId/{id}")]
        public List<VayomadhuramDto> VayomadhuramsForApprovalByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Vayomadhurams.Where(x => x.VillageId == id && x.ApproveById == null && x.IssueById != null).Select(x => new VayomadhuramDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    DOB = x.DOB,
                    Age = x.Age,
                    PermanentAddress = x.PermanentAddress,
                    PresentAddress = x.PresentAddress,
                    MobileNo = x.MobileNo,
                    AadharNo = x.AadharNo,
                    RationCardNo = x.RationCardNo,
                    RationPriority = x.RationPriority,
                    IsSelfAttested = x.IsSelfAttested,
                    IsDiabetic = x.IsDiabetic,
                    IsGlucoseMeterUser = x.IsGlucoseMeterUser,
                    HospitalName = x.HospitalName,
                    DiabeticPeriod = x.DiabeticPeriod,
                    DocName = x.DocName,
                    IdMark = x.IdMark,
                    TreatmentDuration = x.TreatmentDuration,
                    Designation = x.Designation,
                    RegNo = x.RegNo,
                    Place = x.Place,

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
        [Route("ApprovedVayomadhuramsByVillageId/{id}")]
        public List<VayomadhuramDto> ApprovedVayomadhuramsByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {
                var dataList = context.Vayomadhurams.Where(x => x.VillageId == id && x.ApproveById != null ).Select(x => new VayomadhuramDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    DOB = x.DOB,
                    Age = x.Age,
                    PermanentAddress = x.PermanentAddress,
                    PresentAddress = x.PresentAddress,
                    MobileNo = x.MobileNo,
                    AadharNo = x.AadharNo,
                    RationCardNo = x.RationCardNo,
                    RationPriority = x.RationPriority,
                    IsSelfAttested = x.IsSelfAttested,
                    IsDiabetic = x.IsDiabetic,
                    IsGlucoseMeterUser = x.IsGlucoseMeterUser,
                    HospitalName = x.HospitalName,
                    DiabeticPeriod = x.DiabeticPeriod,
                    DocName = x.DocName,
                    IdMark = x.IdMark,
                    TreatmentDuration = x.TreatmentDuration,
                    Designation = x.Designation,
                    RegNo = x.RegNo,
                    Place = x.Place,

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
        [Route("DeleteVayomaduram/{id}")]
        public string DeleteVayomaduram(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.Vayomadhurams.FirstOrDefault(x => x.Id == id);

                if (deleteData.IssueById != null)
                {
                    return "Request Under Process Cannot Delete Application.";
                }

                context.Vayomadhurams.Remove(deleteData);
                context.SaveChanges();
            }

            return "Success";
        }

    }
}
