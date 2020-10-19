using B2BAgent.Server.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using IdentityRole = Volo.Abp.Identity.IdentityRole;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace B2BAgent.Server
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(AbpUserClaimsPrincipalFactory))] // 替换旧的AbpUserClaimsPrincipalFactory
    public class MyUserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory, IScopedDependency
    {
        IRepository<AppUser> appUserRepo;
        IHttpContextAccessor httpContext;
        public MyUserClaimsPrincipalFactory(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options,IRepository<AppUser> appUserRepo,IHttpContextAccessor httpContext) :
            base(userManager, roleManager, options)
        {
            this.appUserRepo = appUserRepo;
            this.httpContext = httpContext;
        }

        public override async Task<ClaimsPrincipal> CreateAsync(IdentityUser user)
        {
            var principal = await base.CreateAsync(user);
            var identityPrincipal = principal.Identities.First();
            // add custom claim
            var u = appUserRepo.Single(t => t.Id == user.Id);

            //identityPrincipal.AddClaim(new Claim("merchant_id", u.MerchantId.ToString()));

            return principal;
        }
    }
}
