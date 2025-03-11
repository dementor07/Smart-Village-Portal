using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace smartVillage.Model
{
    public class Student : IHttpHandler
    {
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(50)]
        public string MobileNo { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(250)]
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }

        public long StateId { get; set; }
        public virtual State State { get; set; }
        public long DistrictId { get; set; }
        public virtual District District { get; set; }
        public long VillageId { get; set; }
        public virtual Village Village { get; set; }
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
        }

        #endregion
    }
}
