using AutoMapper;
using B2BAgent.Server.Biz;
using B2BAgent.Server.Domains;
using B2BAgent.Server.Biz.Dtos;
using EV.Domain.System;
using B2BAgent.Server.System.Dtos;

namespace B2BAgent.Server
{
    public class ServerApplicationAutoMapperProfile : Profile
    {
        public ServerApplicationAutoMapperProfile()
        {

            this.CreateMap<ERPBrand, ERPBrandDto>().ReverseMap();
            

            this.CreateMap<SysDictCreateOrUpdateDto, SysDict>();

            
            this.CreateMap<SysDictItemCreateOrUpdateDto, SysDictItem>();
            
        }
    }
}
