using Lms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lms.Controllers
{
    public class SignupController : ApiController
    {
        [HttpPost]
        [Route("AddSignupRecord")]
        public string AddSignupRecord([FromBody] SignupModel SignupModel)
        {
            return SignupModel.AddSignupRecord();
        }

        [HttpPost]
        [Route("UpdateUserDetails")]
        public string UpdateUserDetails([FromBody] SignupModel SignupModel)
        {
            return SignupModel.UpdateUserDetails();
        }

        [HttpPost]
        [Route("DeleteUserDetails")]
        public string DeleteUserDetails([FromBody] SignupModel SignupModel)
        {
            return SignupModel.DeleteUserDetails();
        }
      

        [HttpPost]
        [Route("GetQualificationList")]
        public List<SignupModel> GetQualificationList()
        {
            SignupModel SignupModel = new SignupModel();
            return SignupModel.GetQualificationList();
        }

        [HttpPost]
        [Route("GetTrainingModeList")]
        public List<SignupModel> GetTrainingModeList()
        {
            SignupModel SignupModel = new SignupModel();
            return SignupModel.GetTrainingModeList();
        }

        [HttpPost]

        [Route("GetDesignationList")]
        public List<SignupModel> GetDesignationList()
        {
            SignupModel SignupModel = new SignupModel();
            return SignupModel.GetDesignationList();
        }

        [HttpPost]

        [Route("GetUserList")]
        public List<SignupModel> GetUserList()
        {
            SignupModel SignupModel = new SignupModel();
            return SignupModel.GetUserList();
        }

        [HttpPost]
        [Route("GetSignupDetails")]
        public SignupModel GetEmployeeDetails([FromBody] SignupModel SignupModel)
        {
            return SignupModel.GetSignupDetails();
        }

    }
}


