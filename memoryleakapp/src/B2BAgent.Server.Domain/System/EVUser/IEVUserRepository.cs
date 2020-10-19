//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Volo.Abp.Domain.Repositories;
//using Volo.Abp.Users;

//namespace EV.Domain.System
//{
//    public interface IEVUserRepository: IBasicRepository<EVUser, Guid>, IUserRepository<EVUser>
//    {
//        Task<List<EVUser>> GetUsersAsync(int maxCount, string filter, CancellationToken cancellationToken = default);
//        Task<EVUser> GetUserByUserName(string userName);
//    }
//}
