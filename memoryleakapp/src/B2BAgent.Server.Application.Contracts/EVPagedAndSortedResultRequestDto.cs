using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace B2BAgent.Server.Biz.Dtos
{
    /// <summary>
    /// ev分页参数
    /// </summary>
    public class EVPagedAndSortedResultRequestDto: PagedAndSortedResultRequestDto
    {
        public EVPagedAndSortedResultRequestDto()
        {
            this.MaxResultCount = 50;
        }
    }
}
