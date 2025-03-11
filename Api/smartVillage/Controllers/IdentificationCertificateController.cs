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
    public class IdentificationCertificateController : ApiController
    {
  
        [HttpPost]
        [Route("SaveIdentificationCertificate")]
        public string SaveIdentificationCertificate(IdentificationCertificateDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var editData = context.IdentificationCertificates.FirstOrDefault(x => x.Id == dataDto.Id);

                    editData.CustomerId = dataDto.CustomerId;
                    editData.Name = dataDto.Name;
                    editData.Gender = dataDto.Gender;
                    editData.Age = dataDto.Age;
                    editData.FatherName = dataDto.FatherName;
                    editData.Address = dataDto.Address;
                    editData.PostOffice = dataDto.PostOffice;
                    editData.Pincode = dataDto.Pincode;
                    editData.IdentificationMark1 = dataDto.IdentificationMark1;
                    editData.IdentificationMark2 = dataDto.IdentificationMark2;
                    editData.IdentificationMark3 = dataDto.IdentificationMark3;
                    editData.VillageId = dataDto.VillageId;
                    editData.Taluk = dataDto.Taluk;
                    editData.DistrictId = dataDto.DistrictId;
                    editData.AliasName = dataDto.AliasName;
                    editData.IssueDate = dataDto.IssueDate;

                    context.Entry(editData).State = EntityState.Modified;
                    context.SaveChanges();
                    return "success";
                }
                else

                {

                    IdentificationCertificate addData = new IdentificationCertificate();

                    addData.Date = DateTime.Now;
                    addData.CustomerId = dataDto.CustomerId;
                    addData.Name = dataDto.Name;
                    addData.Gender = dataDto.Gender;
                    addData.Age = dataDto.Age;
                    addData.FatherName = dataDto.FatherName;
                    addData.Address = dataDto.Address;
                    addData.PostOffice = dataDto.PostOffice;
                    addData.Pincode = dataDto.Pincode;
                    addData.IdentificationMark1 = dataDto.IdentificationMark1;
                    addData.IdentificationMark2 = dataDto.IdentificationMark2;
                    addData.IdentificationMark3 = dataDto.IdentificationMark3;
                    addData.VillageId = dataDto.VillageId;
                    addData.Taluk = dataDto.Taluk;
                    addData.DistrictId = dataDto.DistrictId;
                    addData.StateId = dataDto.StateId;

                    context.IdentificationCertificates.Add(addData);
                    context.SaveChanges();


                    return "success";
                }
            }
        }

        [HttpGet]
        [Route("IdentificationCertificatesById/{id}")]
        public IdentificationCertificateDto IdentificationCertificatesById(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IdentificationCertificates.Where(x => x.Id == id).Select(x => new IdentificationCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    IdentificationMark1 = x.IdentificationMark1,
                    IdentificationMark2 = x.IdentificationMark2,
                    IdentificationMark3 = x.IdentificationMark3,
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
        [Route("GetAllIdentificationCertificates")]
        public List<IdentificationCertificateDto> GetAllIdentificationCertificates()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IdentificationCertificates.Select(x => new IdentificationCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    IdentificationMark1 = x.IdentificationMark1,
                    IdentificationMark2 = x.IdentificationMark2,
                    IdentificationMark3 = x.IdentificationMark3,
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
        [Route("IdentificationCertificatesByCustomerId/{id}")]
        public List<IdentificationCertificateDto> IdentificationCertificatesByCustomerId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IdentificationCertificates.Where(x => x.CustomerId == id).Select(x => new IdentificationCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    IdentificationMark1 = x.IdentificationMark1,
                    IdentificationMark2 = x.IdentificationMark2,
                    IdentificationMark3 = x.IdentificationMark3,
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
        [Route("NewIdentificationCertificatesByVillageId/{id}")]
        public List<IdentificationCertificateDto> NewIdentificationCertificatesByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IdentificationCertificates.Where(x => x.VillageId == id && x.IssueById == null).Select(x => new IdentificationCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    IdentificationMark1 = x.IdentificationMark1,
                    IdentificationMark2 = x.IdentificationMark2,
                    IdentificationMark3 = x.IdentificationMark3,
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
        [Route("IdentificationCertificatesForApprovalByVillageId/{id}")]
        public List<IdentificationCertificateDto> IdentificationCertificatesForApprovalByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IdentificationCertificates.Where(x => x.VillageId == id && x.ApproveById == null && x.IssueById != null).Select(x => new IdentificationCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    IdentificationMark1 = x.IdentificationMark1,
                    IdentificationMark2 = x.IdentificationMark2,
                    IdentificationMark3 = x.IdentificationMark3,
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
        [Route("ApprovedIdentificationCertificatesByVillageId/{id}")]
        public List<IdentificationCertificateDto> ApprovedIdentificationCertificatesByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {
                var dataList = context.IdentificationCertificates.Where(x => x.VillageId == id && x.ApproveById != null).Select(x => new IdentificationCertificateDto
                {
                    Id = x.Id,
                    Date = x.Date,

                    Name = x.Name,
                    Gender = x.Gender,
                    Age = x.Age,
                    FatherName = x.FatherName,
                    Address = x.Address,
                    PostOffice = x.PostOffice,
                    Pincode = x.Pincode,
                    IdentificationMark1 = x.IdentificationMark1,
                    IdentificationMark2 = x.IdentificationMark2,
                    IdentificationMark3 = x.IdentificationMark3,
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
        [Route("DeleteIdentificationCertificate/{id}")]
        public string DeleteIdentificationCertificate(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.IdentificationCertificates.FirstOrDefault(x => x.Id == id);

                if (deleteData.IssueById != null)
                {
                    return "Request Under Process Cannot Delete Application.";
                }

                context.IdentificationCertificates.Remove(deleteData);
                context.SaveChanges();
            }

            return "Success";
        }

    }
}