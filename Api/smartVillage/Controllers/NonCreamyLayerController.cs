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
    public class NonCreamyLayerCertificateController : ApiController
    {
        [HttpPost]
        [Route("SaveNonCreamyLayerCertificate")]
        public string SaveNonCreamyLayerCertificate(NonCreamyLayerCertificateDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var editData = context.NonCreamyLayerCertificates.FirstOrDefault(x => x.Id == dataDto.Id);

                    editData.CustomerId = dataDto.CustomerId;
                    editData.Name = dataDto.Name;
                    editData.Gender = dataDto.Gender;
                    editData.Age = dataDto.Age;
                    editData.FatherName = dataDto.FatherName;
                    editData.Address = dataDto.Address;
                    editData.ReligionId = dataDto.ReligionId;
                    editData.CasteId = dataDto.CasteId;
                    editData.PostOffice = dataDto.PostOffice;
                    editData.Pincode = dataDto.Pincode;
                    editData.VillageId = dataDto.VillageId;
                    editData.Taluk = dataDto.Taluk;
                    editData.DistrictId = dataDto.DistrictId;
                    editData.IssueDate = dataDto.IssueDate;


                    context.Entry(editData).State = EntityState.Modified;
                    context.SaveChanges();
                    return "success";
                }
                else
                {

                    NonCreamyLayerCertificate addData = new NonCreamyLayerCertificate();

                    addData.Date = DateTime.Now;
                    addData.CustomerId = dataDto.CustomerId;
                    addData.Name = dataDto.Name;
                    addData.Gender = dataDto.Gender;
                    addData.Age = dataDto.Age;
                    addData.FatherName = dataDto.FatherName;
                    addData.Address = dataDto.Address;
                    addData.ReligionId = dataDto.ReligionId;
                    addData.CasteId = dataDto.CasteId;
                    addData.PostOffice = dataDto.PostOffice;
                    addData.Pincode = dataDto.Pincode;
                    addData.VillageId = dataDto.VillageId;
                    addData.Taluk = dataDto.Taluk;
                    addData.DistrictId = dataDto.DistrictId;
                    addData.StateId = dataDto.StateId;

                    context.NonCreamyLayerCertificates.Add(addData);
                    context.SaveChanges();


                    return "success";
                }
            }
        }

        [HttpGet]
        [Route("NonCreamyLayerCertificatesById/{id}")]
        public NonCreamyLayerCertificateDto NonCreamyLayerCertificatesById(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.NonCreamyLayerCertificates.Where(x => x.Id == id).Select(x => new NonCreamyLayerCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    ReligionId = x.ReligionId,
                    CasteId = x.CasteId,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    Taluk = x.Taluk,

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
        [Route("GetAllNonCreamyLayerCertificates")]
        public List<NonCreamyLayerCertificateDto> GetAllNonCreamyLayerCertificates()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.NonCreamyLayerCertificates.Select(x => new NonCreamyLayerCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    ReligionId = x.ReligionId,
                    CasteId = x.CasteId,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    Taluk = x.Taluk,
                    Religion = new ReligionDto
                    {
                        Id = x.Religion.Id,
                        Name = x.Religion.Name,
                    },
                    Caste = new CasteDto
                    {
                        Id = x.Caste.Id,
                        Name = x.Caste.Name,
                    },

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
        [Route("NonCreamyLayerCertificatesByCustomerId/{id}")]
        public List<NonCreamyLayerCertificateDto> NonCreamyLayerCertificatesByCustomerId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.NonCreamyLayerCertificates.Where(x => x.CustomerId == id).Select(x => new NonCreamyLayerCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    ReligionId = x.ReligionId,
                    CasteId = x.CasteId,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    Taluk = x.Taluk,


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
        [Route("NewNonCreamyLayerCertificatesByVillageId/{id}")]
        public List<NonCreamyLayerCertificateDto> NewNonCreamyLayerCertificatesByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.NonCreamyLayerCertificates.Where(x => x.VillageId == id && x.IssueById == null).Select(x => new NonCreamyLayerCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    ReligionId = x.ReligionId,
                    CasteId = x.CasteId,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    Taluk = x.Taluk,


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
        [Route("NonCreamyLayerCertificatesForApprovalByVillageId/{id}")]
        public List<NonCreamyLayerCertificateDto> NonCreamyLayerCertificatesForApprovalByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.NonCreamyLayerCertificates.Where(x => x.VillageId == id && x.ApproveById == null && x.IssueById != null).Select(x => new NonCreamyLayerCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    ReligionId = x.ReligionId,
                    CasteId = x.CasteId,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    Taluk = x.Taluk,


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
        [Route("ApprovedNonCreamyLayerCertificatesByVillageId/{id}")]
        public List<NonCreamyLayerCertificateDto> ApprovedNonCreamyLayerCertificatesByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {
                var dataList = context.NonCreamyLayerCertificates.Where(x => x.VillageId == id && x.ApproveById != null).Select(x => new NonCreamyLayerCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    ReligionId = x.ReligionId,
                    CasteId = x.CasteId,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    Taluk = x.Taluk,


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
        [Route("DeleteNonCreamyLayerCertificate/{id}")]
        public string DeleteNonCreamyLayerCertificate(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.NonCreamyLayerCertificates.FirstOrDefault(x => x.Id == id);

                if (deleteData.IssueById != null)
                {
                    return "Request Under Process Cannot Delete Application.";
                }

                context.NonCreamyLayerCertificates.Remove(deleteData);
                context.SaveChanges();
            }

            return "Success";
        }

    }

}