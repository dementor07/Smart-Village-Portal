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
    public class VillageController : ApiController
    {

        [HttpPost]
        [Route("SaveVillage")]
        public bool SaveVillage(VillageDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var editData = context.Villages.FirstOrDefault(x => x.Id == dataDto.Id);

                    editData.Name = dataDto.Name;
                    editData.StateId = dataDto.StateId;
                    editData.DistrictId = dataDto.DistrictId;

                    context.Entry(editData).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    Village addData = new Village();

                    addData.Name = dataDto.Name;
                    addData.StateId = dataDto.StateId;
                    addData.DistrictId = dataDto.DistrictId;

                    addData.IsActive = true;

                    context.Villages.Add(addData);
                    context.SaveChanges();
                    return true;
                }

            }

        }


        [HttpGet]
        [Route("GetVillages")]
        public List<VillageDto> GetVillages()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Villages.Where(x => x.IsActive == true).Select(x => new VillageDto
                {
                    Id = x.Id,
                    Name = x.Name,

                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },
                    DistrictId = x.DistrictId,
                    District = new DistrictDto
                    {
                        Id = x.District.Id,
                        Name = x.District.Name,
                    },


                    IsActive = x.IsActive,
                }).ToList();

                return dataList;

            }
        }
        

        [HttpGet]
        [Route("GetVillagesByDistrictId/{id}")]
        public List<VillageDto> GetVillagesByDistrictId(long id)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.Villages.Where(x => x.IsActive == true && x.DistrictId == id).Select(x => new VillageDto
                {
                    Id = x.Id,
                    Name = x.Name,

                    StateId = x.StateId,
                    State = new StateDto
                    {
                        Id = x.State.Id,
                        Name = x.State.Name,
                    },
                    DistrictId = x.DistrictId,
                    District = new DistrictDto
                    {
                        Id = x.District.Id,
                        Name = x.District.Name,
                    },


                    IsActive = x.IsActive,
                }).ToList();

                return dataList;

            }
        }

        [HttpGet]
        [Route("DeleteVillage/{id}")]
        public bool DeleteVillage(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.Villages.FirstOrDefault(x => x.Id == id);
                deleteData.IsActive = false;

                context.Entry(deleteData).Property(x => x.IsActive).IsModified = true;
                context.SaveChanges();
            }

            return true;
        }
    }
}
