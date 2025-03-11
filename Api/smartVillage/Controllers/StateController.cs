﻿using smartVillage.Dtos;
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
    public class StateController : ApiController
    {
        [HttpPost]
        [Route("SaveState")]
        public bool SaveState(StateDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var editData = context.States.FirstOrDefault(x => x.Id == dataDto.Id);

                    editData.Name = dataDto.Name;

                    context.Entry(editData).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    State addData = new State();

                    addData.Name = dataDto.Name;
                    addData.IsActive = true;

                    context.States.Add(addData);
                    context.SaveChanges();
                    return true;
                }

            }

        }


        [HttpGet]
        [Route("GetStates")]
        public List<StateDto> GetStates()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.States.Where(x => x.IsActive == true).Select(x => new StateDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive,
                }).ToList();

                return dataList;

            }
        }

        [HttpGet]
        [Route("DeleteState/{id}")]
        public bool DeleteState(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.States.FirstOrDefault(x => x.Id == id);
                deleteData.IsActive = false;

                context.Entry(deleteData).Property(x => x.IsActive).IsModified = true;
                context.SaveChanges();
            }

            return true;
        }
    }
}
