//using System;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using B2BAgent.Server.Domains;
//using LogDashboard.Repository;
//using Volo.Abp.Application.Dtos;
//using Volo.Abp.AspNetCore.Mvc;
//using Volo.Abp.Domain.Repositories;
//using B2BAgent.Server.Biz.Dtos;
//using Microsoft.AspNetCore.Authorization;
//using Volo.Abp.TenantManagement;

//namespace B2BAgent.Server.Controllers
//{
//    [Authorize]
//    public class TestController : AbpController
//    {
//        private ITenantAppService tenantAppService;
//        public TestController(ITenantAppService tenantAppService)
//        {
//            this.tenantAppService = tenantAppService;
//        }
//        [Route("/api/test/run")]
//        [HttpGet]
//        public async Task<ActionResult<bool>> Run()
//        {
//            TenantCreateDto c = new TenantCreateDto();
//            c.AdminEmailAddress = "abc@cc.com";
//            c.AdminPassword = "1q2w3E#";
//            c.Name = "test1";
//            await tenantAppService.CreateAsync(c);
//            return true;

//        }
//    }
//}
