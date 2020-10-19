using B2BAgent.Server.Domains;
using EV.Domain.System;
using EV.JwtToken;
using EV.System.EVUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace EV.Identity
{


    public class JwtTokenApplicationService : ApplicationService, IJwtTokenApplicationService
    {
        IOptions<JwtTokenOptions> _jwtTokenOptions;
        IdentityUserManager _identityUserManager;
        IdentityRoleManager _identityRoleManager;
        IMemoryCache _memoryCache;
        IRepository<BusinessTenant, Guid> _businessTenantRepo;
        public JwtTokenApplicationService(IOptions<JwtTokenOptions> jwtTokenOptions,IdentityUserManager identityUserManager,
            IdentityRoleManager identityRoleManager, IRepository<BusinessTenant, Guid> businessTenantRepo,
            IMemoryCache memoryCache)
        {
            _jwtTokenOptions = jwtTokenOptions;
            _identityUserManager = identityUserManager;
            _identityRoleManager = identityRoleManager;
            _memoryCache = memoryCache;
            _businessTenantRepo = businessTenantRepo;
        }

        /// <summary>
        /// 通过用户名密码获取Token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<GenerateTokenResult> GenerateByAccount(GenerateByAccountInputDto data)
        {
            try
            {
                GenerateTokenResult r = new GenerateTokenResult();
                var identityUser = await _identityUserManager.FindByNameAsync(data.UserName);
                var checkUserResult = await _identityUserManager.CheckPasswordAsync(identityUser, data.Password);

                IList<string> roleNames = await _identityUserManager.GetRolesAsync(identityUser);
                

                if (checkUserResult)
                {
                    r.Result = true;
                    r.Account = data.UserName;

                    r.AccessToken = Generate(data.UserName,
                        identityUser.Id.ToString(),
                        null,
                        null,
                        null,
                        roleNames.JoinAsString(","));
                }
                else
                {
                    UserFriendlyException e = new UserFriendlyException("用户校验失败", null, "请检查您输入的用户名密码是否正确");
                    throw (e);
                }
                return r;
            }
            catch(Exception ex)
            {
                UserFriendlyException e = new UserFriendlyException("用户校验失败", null, "请检查您输入的用户名密码是否正确",ex);
                throw (e);
            }

        }


        [AllowAnonymous]
        public async Task<GenerateTokenResult> GenerateByTenantAccount(GenerateByAccountInputDto data)
        {
            try
            {
                GenerateTokenResult r = new GenerateTokenResult();

                var tenant = _businessTenantRepo.SingleOrDefault(t => t.UserName == data.UserName && t.Password == data.Password);

                if (tenant!=null)
                {
                    r.Result = true;
                    r.Account = data.UserName;

                    r.AccessToken = Generate(data.UserName,
                        tenant.Id.ToString(),
                        null,
                        null,
                        null,
                        "user");
                }
                else
                {
                    UserFriendlyException e = new UserFriendlyException("用户校验失败", null, "请检查您输入的用户名密码是否正确");
                    throw (e);
                }
                return r;
            }
            catch (Exception ex)
            {
                UserFriendlyException e = new UserFriendlyException("用户校验失败", null, "请检查您输入的用户名密码是否正确", ex);
                throw (e);
            }

        }

        public class GenerateTestUserDto
        {
            public string Sid { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
        }
        [AllowAnonymous]
        public string GenerateTestUser(GenerateTestUserDto data)
        {
            var claims = new Claim[]{
                new Claim(ClaimTypes.Sid, data.Sid),
                new Claim(ClaimTypes.Name, data.Name),
                new Claim(ClaimTypes.Role, data.Role)
            };

            /////////////////////////////////////////////////////////////////////////////////
            //var keyByteArray = Encoding.ASCII.GetBytes("Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA==");
            //var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(keyByteArray);
            //_jwtTokenOptions = new JwtTokenOptions()
            //{
            //    Issuer = "Catcher Wong",
            //    Audience = "http://catcher1994.cnblogs.com/",
            //    SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            //};


            //创建令牌
            var token = new JwtSecurityToken(
                issuer: _jwtTokenOptions.Value.Issuer,
                audience: _jwtTokenOptions.Value.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: _jwtTokenOptions.Value.SigningCredentials
                );
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }

        private string Generate(string userName,string sid,string departmentIds ,string comapnyId,string companyType,string roleName = "user")
        {
            //创建用户身份标识
            Claim[] claims = null;
            claims = new Claim[]
            {
                    new Claim(ClaimTypes.Sid, sid),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.NameIdentifier,sid),
                    new Claim(ClaimTypes.Role, roleName)
            };

            //if (userName.ToLower()=="admin")
            //{
            //    claims = new Claim[]
            //    {
            //        new Claim(ClaimTypes.Sid, sid),
            //        new Claim(ClaimTypes.Name, userName),
            //        new Claim(ClaimTypes.NameIdentifier,sid),
            //        new Claim(ClaimTypes.Role, roleName)
            //    };
            //}
            //else
            //{

            //}


            //创建令牌
            var token = new JwtSecurityToken(
                issuer: _jwtTokenOptions.Value.Issuer,
                audience: _jwtTokenOptions.Value.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: _jwtTokenOptions.Value.SigningCredentials
                );
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
        
    }
}
