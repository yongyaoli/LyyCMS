using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using LyyCMS.Members.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace LyyCMS.Members
{
    public class MembersAppService : IMembersAppService
    {
        private readonly IRepository<Member> _resposotory;

        public MembersAppService(IRepository<Member> repository)
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

        public Task<MemberListDto> GetMemberByIdAsync(NullableIdDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<MemberListDto>> GetPagedMemeberAsync(GetMemberInput input)
        {
            var query = _resposotory.GetAll();
            var personcount = await query.CountAsync();

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            var dtos = persons.MapTo<List<MemberListDto>>();
            var pagedReulstMember = new PagedResultDto<MemberListDto>(personcount, dtos);

            return pagedReulstMember;
        }

        protected async Task UpdateMemberAsync(MemberEditDto input)
        {
            var p = await _resposotory.GetAsync(input.Id.Value);
            await _resposotory.UpdateAsync(input.MapTo(p));

        }

        protected async Task CreateMemberAsync(MemberEditDto input)
        {
            await _resposotory.InsertAsync(input.MapTo<Member>());
        }
    }
}
