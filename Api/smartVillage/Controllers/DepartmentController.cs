using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using smartVillage.Dtos;
using smartVillage.Model;

namespace smartVillage.Controllers
{
    public class DepartmentController : ApiController
    {

        [HttpPost]
        [Route("SaveDepartment")]
        public bool SaveDepartment(DepartmentDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var editData = context.Departments.FirstOrDefault(x => x.Id == dataDto.Id);


                    editData.Name = dataDto.Name;



                    context.Entry(editData).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    Department addData = new Department();


                    addData.Name = dataDto.Name;


                    addData.IsActive = true;

                    context.Departments.Add(addData);
                    context.SaveChanges();
                    return true;
                }

            }

        }


        [HttpGet]
        [Route("GetDepartment")]
        public List<DepartmentDto> GetDepartment()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Departments.Where(x => x.IsActive == true).Select(x => new DepartmentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive,
                }).ToList();

                return dataList;

            }
        }


        [HttpGet]
        [Route("DeleteDepartment/{id}")]
        public bool DeleteDepartment(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.Departments.FirstOrDefault(x => x.Id == id);
                deleteData.IsActive = false;

                context.Entry(deleteData).Property(x => x.IsActive).IsModified = true;
                context.SaveChanges();
            }

            return true;
        }


    }
}