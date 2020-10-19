//using B2BAgent.Server.Biz;
//using B2BAgent.Server.Domains;
//using B2BAgent.Server.EntityFrameworkCore;
//using B2BAgent.Server.IRepository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Volo.Abp;
//using Volo.Abp.Domain.Repositories;
//using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
//using Volo.Abp.EntityFrameworkCore;

//namespace B2BAgent.Server
//{
//    public class ClientRepository : EfCoreRepository<ServerDbContext, Client, Guid>, IClientRepository
//    {
//        public ClientRepository(IDbContextProvider<ServerDbContext> dbContextProvider)
//            : base(dbContextProvider)
//        {
//        }

//        public void UpdateLastUpdateTime(Guid id, DateTime lastUpdateTime)
//        {
//            try
//            {
//                var r = DbSet
//                return r;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw new Exception($"未找到或找到多个标准结构：tid={tenantId} biztypecode={bizTypeCode} durationTypeCode={durationTypeCode}");
//            }

//        }


//    }
//}
