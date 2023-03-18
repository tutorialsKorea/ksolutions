using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using QueryApi.Models;
using QueryApi.Models.Users;
using QueryApi.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using Org.BouncyCastle.Utilities.Net;
using Newtonsoft.Json;
using BizManager;
using BizExecute;

namespace QueryApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        public UsersController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        
        [AllowAnonymous]
        [HttpPost("QueryApi")]
        public IActionResult Query([FromBody] BizRule rule)
        {
            try
            {
                //사용하는 유저 아이디를 항시 새로 받아야한다(기존 구조를 최대한 건드리지 않기 위해)
                ConnInfo.UserID = rule.USER_ID;

                System.IO.StringReader sr = new System.IO.StringReader(rule.DATA.ToString());

				DataSet paramSet = new DataSet();
                paramSet.ReadXml(sr,XmlReadMode.Auto);

                BizManager.QBiz.emExecuteType executeType = (QBiz.emExecuteType)Enum.Parse(typeof(QBiz.emExecuteType),rule.EXECUTE_TYPE,true);

                DataSet resultSet = BizRun.QBizRun.ApiService( this, executeType, rule.CLASS_NAME, rule.RULE_NAME, paramSet);

                if (resultSet == null) return Ok(null);

                System.IO.StringWriter sw = new System.IO.StringWriter();
                resultSet.WriteXml(sw,XmlWriteMode.WriteSchema);

                return Ok(sw.ToString());
            }
            catch(Exception ex)
            {
                return BadRequest(new { result = 0, message = ex.Message });
            }
        }
    }
}