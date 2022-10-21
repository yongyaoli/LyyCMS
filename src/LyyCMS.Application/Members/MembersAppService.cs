using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using LyyCMS.Members.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace LyyCMS.Members
{
    public class MembersAppService :
        AsyncCrudAppService<Member, MemberDto, int, PagedMemberResultRequestDto, CreateMemberDto, MemberDto>,
        IMembersAppService
    {
        private readonly IRepository<Member> _resposotory;


        public MembersAppService(IRepository<Member> repository) : base(repository)
        {
            _resposotory = repository;
        }

        public async Task CreateOrUpdateMemberAsync(CreateOrUpdateMemberDtoInput input)
        {
            if (input.edit.Id.HasValue)
            {
                await UpdateMemberAsync(input.edit);
            }
            else
            {
                await CreateMemberAsync(input.edit);
            }


            throw new NotImplementedException();
        }

        public async Task DeleteMemberAsync(EntityDto input)
        {
            var p = await _resposotory.GetAsync(input.Id);
            if (p == null)
            {
                throw new UserFriendlyException("数据不存在");
            }
            await _resposotory.DeleteAsync(input.Id);
        }

        public async Task<MemberListDto> GetMemberByIdAsync(NullableIdDto input)
        {
            var category = await _resposotory.GetAsync(input.Id.Value);
            return ObjectMapper.Map<MemberListDto>(category);
        }

        public async Task<PagedResultDto<MemberListDto>> GetPagedMemberAsync(GetMemberInput input)
        {
            var query = _resposotory.GetAll();
            var personcount = await query.CountAsync();

            var members = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = ObjectMapper.Map<List<MemberListDto>>(members);
            var pagedReulstMember = new PagedResultDto<MemberListDto>(personcount, dtos);

            return pagedReulstMember;
        }

        protected async Task UpdateMemberAsync(MemberEditDto input)
        {
            var p = await _resposotory.GetAsync(input.Id.Value);
            Member member = ObjectMapper.Map(input, p);
            await _resposotory.UpdateAsync(member);

        }

        protected async Task CreateMemberAsync(MemberEditDto input)
        {
            await _resposotory.InsertAsync(ObjectMapper.Map<Member>(input));
        }

        public async Task RegisterMember(CreateOrUpdateMemberDtoInput input)
        {
            var member = input;
            member.edit.LoginPass = "123456";
            var entity = ObjectMapper.Map<Member>(member.edit);

            await _resposotory.InsertAsync(entity);

        }
    }
}
