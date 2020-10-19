using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using B2BAgent.Server.Domains;
using LogDashboard.Repository;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using B2BAgent.Server.Biz.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace B2BAgent.Server.Controllers
{
    /// <summary>
    /// 页面服务
    /// </summary>
    [Authorize]
    public class HomeController : AbpController
    {
        
    }
}
