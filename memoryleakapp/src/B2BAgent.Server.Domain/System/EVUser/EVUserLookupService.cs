//using System;
//using System.Collections.Generic;
//using System.Text;
//using Volo.Abp.Uow;
//using Volo.Abp.Users;

//namespace EV.Domain.System
//{
//    public class EVUserLookupService : UserLookupService<EVUser, IEVUserRepository>, IEVUserLookupService
//    {
//        public EVUserLookupService(
//            IEVUserRepository userRepository,
//            IUnitOfWorkManager unitOfWorkManager)
//            : base(
//                userRepository,
//                unitOfWorkManager)
//        {
//        }

//        protected override EVUser CreateUser(IUserData externalUser)
//        {
//            return new EVUser(externalUser);
//        }
//    }


//}

