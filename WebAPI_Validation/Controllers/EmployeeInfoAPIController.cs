using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_Validation.Models;
using System.Web.Http.Cors;

namespace WebAPI_Validation.Controllers
{
    [EnableCors("*","*","*")]
    public class EmployeeInfoAPIController : ApiController
    {
        ApplicationEntities ctx;
        public EmployeeInfoAPIController()
        {
            ctx = new ApplicationEntities(); 
        }
        public IEnumerable<EmployeeInfo> Get()
        {
            return ctx.EmployeeInfoes.ToList();
        }

        [ResponseType(typeof(EmployeeInfo))]
        public IHttpActionResult Get(int id)
        {
            var Emp = ctx.EmployeeInfoes.Find(id);

            if (Emp != null)
            {
                return Ok(Emp);
            }
            else
            {
                return NotFound();
            }
        }

        [ResponseType(typeof(EmployeeInfo))]
        public IHttpActionResult Post(EmployeeInfo Emp)
        {
            
            //if (!ModelState.IsValid)
            //{

            //    var errors = ModelState.Where(e => e.Value.Errors.Count > 0)
            //            .Select(e => new {
            //                                Name = e.Key,
            //                                Message = e.Value.Errors.First().ErrorMessage
            //                              }).ToList();
            //    //return  new ResponseMessageResult(
            //    //Request.CreateErrorResponse(
            //    //    HttpStatusCode.Forbidden,
            //    //    new HttpError("Model Validation Failed, please review the posted values")
            //    //));

            //    return new ResponseMessageResult(
            //    Request.CreateErrorResponse(
            //        HttpStatusCode.Forbidden,
            //        new HttpError(ModelState,true)
            //    ));
            //}
            //else 
            {
                ctx.EmployeeInfoes.Add(Emp);
                ctx.SaveChanges();
                return Ok(Emp);
            }
        }
    }
}
