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
    public class StatusController : ApiController
    {

        [HttpPost]
        [Route("SaveStatus")]
        public bool SaveStatus(StatusDto dataDto)
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
                    Status addData = new Status();


                    addData.Name = dataDto.Name;


                    addData.IsActive = true;

                    context.Status.Add(addData);
                    context.SaveChanges();
                    return true;
                }

            }

        }


        [HttpGet]
        [Route("GetStatus")]
        public List<StatusDto> GetStatus()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Status.Where(x => x.IsActive == true).Select(x => new StatusDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive,
                }).ToList();

                return dataList;

            }
        }


        [HttpGet]
        [Route("DeleteStatus/{id}")]
        public bool DeleteStatus(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.Status.FirstOrDefault(x => x.Id == id);
                deleteData.IsActive = false;

                context.Entry(deleteData).Property(x => x.IsActive).IsModified = true;
                context.SaveChanges();
            }

            return true;
        }


    }
}