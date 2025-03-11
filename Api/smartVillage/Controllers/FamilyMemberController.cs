using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using smartVillage.Dtos;
using smartVillage.Model;
using System.Web.Http.Cors;

namespace smartVillage.Controllers { }

public class FamilyMemberController : ApiController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    
    
        [HttpPost]
        [Route("SaveFamilyMember")]
        public string SaveFamilyMember(FamilyMemberDto dataDto)
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                if (dataDto.Id > 0)
                {
                    var editData = context.FamilyMembers.FirstOrDefault(x => x.Id == dataDto.Id);

                    editData.Name = dataDto.Name;
                    editData.MobileNo = dataDto.MobileNo;
                    editData.Email = dataDto.Email;
                    editData.Address = dataDto.Address;
                    editData.StateId = dataDto.StateId;
                    editData.DistrictId = dataDto.DistrictId;
                    editData.VillageId = dataDto.VillageId;

                    if (dataDto.Photo != null && dataDto.Photo != "" && editData.Photo != dataDto.Photo && !dataDto.Photo.Contains("UploadedFiles"))
                    {
                        Guid id = Guid.NewGuid();
                        var imgData = dataDto.Photo.Substring(dataDto.Photo.IndexOf(",") + 1);
                        byte[] bytes = Convert.FromBase64String(imgData);
                        Image image;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                        }
                        Bitmap b = new Bitmap(image);
                        string filePath = System.Web.HttpContext.Current.Server.MapPath("~") + "UploadedFiles\\" + id + ".jpg";
                        b.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        editData.Photo = string.Concat("UploadedFiles\\" + id + ".jpg");
                    }


                    context.Entry(editData).State = EntityState.Modified;
                    context.SaveChanges();
                    return "success";
                }
                else
                {

                    var old = context.FamilyMembers.FirstOrDefault(x => x.IsActive && x.Email == dataDto.Email);
                    if (old != null)
                    {
                        return "Email Id Already Exist";
                    }

                    FamilyMember addData = new FamilyMember();

                    addData.Name = dataDto.Name;
                    addData.MobileNo = dataDto.MobileNo;
                    addData.Email = dataDto.Email;
                    addData.Date = DateTime.Now;
                    addData.Address = dataDto.Address;
                    addData.StateId = dataDto.StateId;
                    addData.DistrictId = dataDto.DistrictId;
                    addData.VillageId = dataDto.VillageId;

                    if (dataDto.Photo != null && dataDto.Photo != "")
                    {
                        Guid id = Guid.NewGuid();
                        var imgData = dataDto.Photo.Substring(dataDto.Photo.IndexOf(",") + 1);
                        byte[] bytes = Convert.FromBase64String(imgData);
                        Image image;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                        }
                        Bitmap b = new Bitmap(image);
                        string filePath = System.Web.HttpContext.Current.Server.MapPath("~") + "UploadedFiles\\" + id + ".jpg";
                        b.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        addData.Photo = string.Concat("UploadedFiles\\" + id + ".jpg");
                    }

                    addData.IsActive = true;

                    context.FamilyMembers.Add(addData);
                    context.SaveChanges();



                    return "success";
                }

            }

        }



        [HttpGet]
        [Route("GetFamilyMembers")]
        public List<FamilyMemberDto> GetFamilyMembers()
        {

            using (smartVillageDB context = new smartVillageDB())
            {

                var dataList = context.FamilyMembers.Where(x => x.IsActive == true).Select(x => new FamilyMemberDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    Email = x.Email,
                    Address = x.Address,
                    Photo = x.Photo,
                    Date = x.Date,
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

                    VillageId = x.VillageId,
                    Village = new VillageDto
                    {
                        Id = x.Village.Id,
                        Name = x.Village.Name,
                    },


                    IsActive = x.IsActive,
                }).ToList();

                return dataList;

            }
        }
        
        
        [HttpGet]
        [Route("DeleteFamilyMember/{id}")]
        public bool DeleteFamilyMember(long id)
        {
            using (smartVillageDB context = new smartVillageDB())
            {
                var deleteData = context.FamilyMembers.FirstOrDefault(x => x.Id == id);
                deleteData.IsActive = false;

                context.Entry(deleteData).Property(x => x.IsActive).IsModified = true;
                context.SaveChanges();
            }

            return true;
        }
    
    
    
}