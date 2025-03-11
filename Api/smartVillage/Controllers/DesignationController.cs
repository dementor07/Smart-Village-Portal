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
    public class DesignationController : ApiController
    {

        [HttpPost]
        [Route("SaveDesignation")]
        public bool SaveDesignation(DesignationDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var editData = context.Designations.FirstOrDefault(x => x.Id == dataDto.Id);


                    editData.Name = dataDto.Name;



                    context.Entry(editData).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    Designation addData = new Designation();


                    addData.Name = dataDto.Name;


                    addData.IsActive = true;

                    context.Designations.Add(addData);
                    context.SaveChanges();
                    return true;
                }

            }

        }


        [HttpGet]
        [Route("GetDesignations")]
        public List<DesignationDto> GetDesignations()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Designations.Where(x => x.IsActive == true).Select(x => new DesignationDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive,
                }).ToList();

                return dataList;

            }
        }


        [HttpGet]
        [Route("DeleteDesignation/{id}")]
        public bool DeleteDesignation(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.Designations.FirstOrDefault(x => x.Id == id);
                deleteData.IsActive = false;

                context.Entry(deleteData).Property(x => x.IsActive).IsModified = true;
                context.SaveChanges();
            }

            return true;
        }


    }
}