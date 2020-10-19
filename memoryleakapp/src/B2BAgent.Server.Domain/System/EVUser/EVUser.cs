//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Text;
//using Volo.Abp.Domain.Entities;
//using Volo.Abp.Domain.Entities.Auditing;
//using Volo.Abp.Users;

//namespace EV.Domain.System
//{
//    public class EVUser : Entity<Guid>, IUser
//    {
//        public string UserName { get; set; }

//        public string Email { get; set; }

//        public string Name { get; set; }

//        public string Surname { get; set; }

//        public bool EmailConfirmed { get; set; }

//        public string PhoneNumber { get; set; }

//        public bool PhoneNumberConfirmed { get; set; }

//        public Guid? TenantId { get; set; }

//        protected EVUser()
//        {

//        }

//        public EVUser(IUserData user)
//           : base(user.Id)
//        {
//            Email = user.Email;
//            Name = user.Name;
//            Surname = user.Surname;
//            EmailConfirmed = user.EmailConfirmed;
//            PhoneNumber = user.PhoneNumber;
//            PhoneNumberConfirmed = user.PhoneNumberConfirmed;
//            UserName = user.UserName;
//            TenantId = user.TenantId;
//        }

//        public void Update(IUserData user)
//        {
//            Email = user.Email;
//            Name = user.Name;
//            Surname = user.Surname;
//            EmailConfirmed = user.EmailConfirmed;
//            PhoneNumber = user.PhoneNumber;
//            PhoneNumberConfirmed = user.PhoneNumberConfirmed;
//            UserName = user.UserName;
//        }
//    }
//}
