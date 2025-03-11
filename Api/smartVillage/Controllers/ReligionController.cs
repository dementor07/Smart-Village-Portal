
using smartVillage.Dtos;
using smartVillage.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace smartVillage.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReligionController : ApiController
    {
        [HttpPost]
        [Route("SaveReligion")]
        public bool SaveReligion(ReligionDto dataDto)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                if (dataDto.Id > 0)
                {
                    var editData = context.Religions.FirstOrDefault(x => x.Id == dataDto.Id);

                    editData.Name = dataDto.Name;
                    editData.IsActive = dataDto.IsActive;

                    context.Entry(editData).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    Religion addData = new Religion();

                    addData.Name = dataDto.Name;
                    addData.IsActive = true;

                    context.Religions.Add(addData);
                    context.SaveChanges();
                    return true;
                }
            }
        }

        [HttpGet]
        [Route("GetReligions")]
        public List<ReligionDto> GetReligions()
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var dataList = context.Religions.Where(x => x.IsActive == true)
                    .Select(x => new ReligionDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        IsActive = x.IsActive
                    }).ToList();

                return dataList;
            }
        }

        [HttpGet]
        [Route("DeleteReligion/{id}")]
        public bool DeleteReligion(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.Religions.FirstOrDefault(x => x.Id == id);
                if (deleteData != null)
                {
                    deleteData.IsActive = false;

                    context.Entry(deleteData).Property(x => x.IsActive).IsModified = true;
                    context.SaveChanges();
                }
                return true;
            }
        }
    }
}
