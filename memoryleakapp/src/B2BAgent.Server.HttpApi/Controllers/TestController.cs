//using Microsoft.AspNetCore.Mvc;
//using B2BAgent.Server.Models.Test;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace B2BAgent.Server.Controllers
//{
//    /// <summary>
//    /// 测试
//    /// </summary>
//    [Route("api/test")]
//    public class TestController : ServerController
//    {
//        public TestController()
//        {
            
//        }
//        /// <summary>
//        /// 测试方法
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        [Route("")]
//        public List<TestModel> GetAsync()
//        {
//            return new List<TestModel>
//            {
//                new TestModel {Name = "John", BirthDate = new DateTime(1942, 11, 18)},
//                new TestModel {Name = "Adams", BirthDate = new DateTime(1997, 05, 24)}
//            };
//        }
//    }
//}
