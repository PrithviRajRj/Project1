using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New_Curd_Operation.Model.Data_Model;
using New_Curd_Operation.Model.Request_Model;
using New_Curd_Operation.Model.Responce_Model;
using System;
using System.IO;
using System.Linq;
using System.Globalization;

namespace New_Curd_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DataBaseContext context;

        public AuthController(DataBaseContext _context)
        {
            this.context = _context;
        }

      

        [HttpPost]
        [Route("register")]
        public IActionResult register([FromBody] RegisterUser userinfo)
        {
            Responce userresponse = new Responce();
            var usereregister = context.Userr.FirstOrDefault(x => true);
            try
            {
                var createUser = new User()
                {
                   CollegeId = userinfo.CollegeId,
                   Name= userinfo.Name,
                   phone=userinfo.phone,
                   Address = userinfo.Address,
                   Email= userinfo.Email,
                   City= userinfo.City,
                   State= userinfo.State,
                   Department= userinfo.Department,
                };
                context.Userr.Add(createUser);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                userresponse.status = "fail";
                userresponse.message = ex.Message;
                return StatusCode(500, userresponse);
            }
            return Ok(userresponse);
        }

        [HttpGet]
        [Route("GetAlldata")]
        public IActionResult GetAlldata() 
        {
            Responce userresponse = new Responce();
            var getData = context.Userr.Where(x=>true).ToList();
            userresponse.status = "success";
            userresponse.data = getData;
            return Ok(userresponse);
        }

        [HttpDelete]
        [Route("DeleteData/CollegeId")]
        public IActionResult DeleteData(string CollegeId)
        {
            Responce userresponse = new Responce();
            var getdata = context.Userr.FirstOrDefault(x=>x.CollegeId == CollegeId);
            if(getdata != null)
            {
                try
                {
                    context.Userr.Remove(getdata);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    userresponse.status = "fail";
                    userresponse.message = ex.Message;
                    return StatusCode(500, userresponse);
                }
                
            }
            return Ok(userresponse);
        }

        [HttpPut]
        [Route("getregister")]
        public IActionResult getregister([FromBody] RegisterUser userinfo)
        {
            Responce userresponse = new Responce();
            var usereregister = context.Userr.FirstOrDefault(x => true);
            try
            {
                var createUser = new User()
                {
                    CollegeId = userinfo.CollegeId,
                    Name = userinfo.Name,
                    phone = userinfo.phone,
                    Address = userinfo.Address,
                    Email = userinfo.Email,
                    City = userinfo.City,
                    State = userinfo.State,
                    Department = userinfo.Department,
                };
                context.Userr.Add(createUser);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                userresponse.status = "fail";
                userresponse.message = ex.Message;
                return StatusCode(500, userresponse);
            }
            return Ok(userresponse);
        }

    }
}
