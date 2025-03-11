
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
        public class CasteController : ApiController
        {
            [HttpPost]
            [Route("SaveCaste")]
            public bool SaveCaste(CasteDto dataDto)
            {
                using (smartVillageDB context = new smartVillageDB())
                {
                    if (dataDto.Id > 0)
                    {
                        var editData = context.Castes.FirstOrDefault(x => x.Id == dataDto.Id);

                        editData.Name = dataDto.Name;
                        editData.IsActive = dataDto.IsActive;

                        context.Entry(editData).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        Caste addData = new Caste
                        {
                            Name = dataDto.Name,
                            IsActive = true
                        };

                        context.Castes.Add(addData);
                        context.SaveChanges();
                        return true;
                    }
                }
            }

            [HttpGet]
            [Route("GetCastes")]
            public List<CasteDto> GetCastes()
            {
                using (smartVillageDB context = new smartVillageDB())
                {
                    var dataList = context.Castes.Where(x => x.IsActive == true)
                        .Select(x => new CasteDto
                        {
                            Id = x.Id,
                            Name = x.Name,
                            IsActive = x.IsActive
                        }).ToList();

                    return dataList;
                }
            }

            [HttpGet]
            [Route("DeleteCaste/{id}")]
            public bool DeleteCaste(long id)
            {
                using (smartVillageDB context = new smartVillageDB())
                {
                    var deleteData = context.Castes.FirstOrDefault(x => x.Id == id);
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
