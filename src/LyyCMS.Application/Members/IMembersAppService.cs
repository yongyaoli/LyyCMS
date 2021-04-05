using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LyyCMS.Members.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Members
{
    public interface IMembersAppService :
        IAsyncCrudAppService<MemberDto, int, PagedMemberResultRequestDto, CreateMemberDto, MemberDto>
    {
        /// <summary>
        /// 分页获取会员信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<MemberListDto>> GetPagedMemeberAsync(GetMemberInput input);


        Task<MemberListDto> GetMemberByIdAsync(NullableIdDto input);

        Task CreateOrUpdateMemberAsync(CreateOrUpdateMemberDtoInput input);

        Task DeleteMemberAsync(EntityDto input);
    }
}
