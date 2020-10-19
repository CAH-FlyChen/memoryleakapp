using System;
using System.Collections.Generic;
using System.Text;

namespace B2BAgent.Server
{
    public class ResponseResultDto
    {
        public bool IsSuccess { get; set; }

        public ResponseResultDto(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }
    }
}
