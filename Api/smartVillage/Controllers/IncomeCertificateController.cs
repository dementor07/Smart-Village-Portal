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
    public class IncomeCertificateController : ApiController
    {
        [HttpPost]
        [Route("SaveIncomeCertificate")]
        public string SaveIncomeCertificate(IncomeCertificateDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var editData = context.IncomeCertificates.FirstOrDefault(x => x.Id == dataDto.Id);

                    editData.CustomerId = dataDto.CustomerId;
                    editData.Name = dataDto.Name;
                    editData.Gender = dataDto.Gender;
                    editData.Age = dataDto.Age;
                    editData.FatherName = dataDto.FatherName;
                    editData.Address = dataDto.Address;
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

                    IncomeCertificate addData = new IncomeCertificate();

                    addData.Date = DateTime.Now;
                    addData.CustomerId = dataDto.CustomerId;
                    addData.Name = dataDto.Name;
                    addData.Gender = dataDto.Gender;
                    addData.Age = dataDto.Age;
                    addData.FatherName = dataDto.FatherName;
                    addData.Address = dataDto.Address;
                    addData.PostOffice = dataDto.PostOffice;
                    addData.Pincode = dataDto.Pincode;
                    addData.CompanyName = dataDto.CompanyName;
                    addData.CompanySector = dataDto.CompanySector;
                    addData.AnnualIncome = dataDto.AnnualIncome;
                    addData.VillageId = dataDto.VillageId;
                    addData.Taluk = dataDto.Taluk;
                    addData.DistrictId = dataDto.DistrictId;
                    addData.StateId = dataDto.StateId;

                    context.IncomeCertificates.Add(addData);
                    context.SaveChanges();

                    return "success";

                }
            }

        }

        [HttpGet]
        [Route("IncomeCertificatesById/{id}")]
        public IncomeCertificateDto IncomeCertificatesById(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IncomeCertificates.Where(x => x.Id == id).Select(x => new IncomeCertificateDto
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
                    CompanyName = x.CompanyName,
                    CompanySector = x.CompanySector,
                    AnnualIncome = x.AnnualIncome,
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
        [Route("GetAllIncomeCertificates")]
        public List<IncomeCertificateDto> GetAllIncomeCertificates()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IncomeCertificates.Select(x => new IncomeCertificateDto
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
                    CompanyName = x.CompanyName,
                    CompanySector = x.CompanySector,
                    AnnualIncome = x.AnnualIncome,
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
        [Route("IncomeCertificatesByCustomerId/{id}")]
        public List<IncomeCertificateDto> IncomeCertificatesByCustomerId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IncomeCertificates.Where(x => x.CustomerId == id).Select(x => new IncomeCertificateDto
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
                    CompanyName = x.CompanyName,
                    CompanySector = x.CompanySector,
                    AnnualIncome = x.AnnualIncome,
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
        [Route("NewIncomeCertificatesByVillageId/{id}")]
        public List<IncomeCertificateDto> NewIncomeCertificatesByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IncomeCertificates.Where(x => x.VillageId == id && x.IssueById == null).Select(x => new IncomeCertificateDto
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
                    CompanyName = x.CompanyName,
                    CompanySector = x.CompanySector,
                    AnnualIncome = x.AnnualIncome,
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
        [Route("IncomeCertificatesForApprovalByVillageId/{id}")]
        public List<IncomeCertificateDto> IncomeCertificatesForApprovalByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.IncomeCertificates.Where(x => x.VillageId == id && x.ApproveById == null && x.IssueById != null).Select(x => new IncomeCertificateDto
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
                    CompanyName = x.CompanyName,
                    CompanySector = x.CompanySector,
                    AnnualIncome = x.AnnualIncome,
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
        [Route("ApprovedIncomeCertificatesByVillageId/{id}")]
        public List<IncomeCertificateDto> ApprovedIncomeCertificatesByVillageId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {
                var dataList = context.IncomeCertificates.Where(x => x.VillageId == id && x.ApproveById != null).Select(x => new IncomeCertificateDto
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
                    CompanyName = x.CompanyName,
                    CompanySector = x.CompanySector,
                    AnnualIncome = x.AnnualIncome,
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
        [Route("DeleteIncomeCertificate/{id}")]
        public string DeleteIncomeCertificate(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.IncomeCertificates.FirstOrDefault(x => x.Id == id);

                if (deleteData.IssueById != null)
                {
                    return "Request Under Process Cannot Delete Application.";
                }

                context.IncomeCertificates.Remove(deleteData);
                context.SaveChanges();
            }

            return "Success";
        }
    }

}