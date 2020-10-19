//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp.DependencyInjection;
//using Volo.Abp.Domain.Entities.Events.Distributed;
//using Volo.Abp.EventBus.Distributed;
//using Volo.Abp.Users;

//namespace EV.Domain.System
//{
//    public class EVUserSynchronizer :
//            IDistributedEventHandler<EntityUpdatedEto<UserEto>>,
//            ITransientDependency
//    {
//        protected IEVUserRepository UserRepository { get; }
//        protected IEVUserLookupService UserLookupService { get; }

//        public EVUserSynchronizer(IEVUserRepository userRepository, IEVUserLookupService userLookupService)
//        {
//            UserRepository = userRepository;
//            UserLookupService = userLookupService;
//        }

//        public async Task HandleEventAsync(EntityUpdatedEto<UserEto> eventData)
//        {
//            var user = await UserRepository.FindAsync(eventData.Entity.Id);
//            if (user == null)
//            {
//                //TODO: Why needed (ask to @ebicoglu)?
//                user = await UserLookupService.FindByIdAsync(eventData.Entity.Id);
//                if (user == null)
//                {
//                    return;
//                }
//            }

//            user.Update(eventData.Entity);
//            await UserRepository.UpdateAsync(user);
//        }
//    }
//}
