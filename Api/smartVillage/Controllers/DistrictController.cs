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
    public class DistrictController : ApiController
    {

        [HttpPost]
        [Route("SaveDistrict")]
        public bool SaveDistrict(DistrictDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var editData = context.Districts.FirstOrDefault(x => x.Id == dataDto.Id);

                    editData.Name = dataDto.Name;
                    editData.StateId = dataDto.StateId;



                    context.Entry(editData).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    District addData = new District();

                    addData.Name = dataDto.Name;
                    addData.StateId = dataDto.StateId;


                    addData.IsActive = true;

                    context.Districts.Add(addData);
                    context.SaveChanges();
                    return true;
                }

            }

        }


        [HttpGet]
        [Route("GetDistricts")]
        public List<DistrictDto> GetDistricts()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Districts.Where(x => x.IsActive == true).Select(x => new DistrictDto
                {
                    Id = x.Id,
                    Name = x.Name,

                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },

                    IsActive = x.IsActive,
                }).ToList();

                return dataList;

            }
        }
        

        [HttpGet]
        [Route("GetDistrictsByState/{id}")]
        public List<DistrictDto> GetDistrictsByState(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Districts.Where(x => x.IsActive == true && x.StateId == id).Select(x => new DistrictDto
                {
                    Id = x.Id,
                    Name = x.Name,

                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },

                    IsActive = x.IsActive,
                }).ToList();

                return dataList;

            }
        }

        [HttpGet]
        [Route("DeleteDistrict/{id}")]
        public bool DeleteDistrict(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.Districts.FirstOrDefault(x => x.Id == id);
                deleteData.IsActive = false;

                context.Entry(deleteData).Property(x => x.IsActive).IsModified = true;
                context.SaveChanges();
            }

            return true;
        }
    }
}
