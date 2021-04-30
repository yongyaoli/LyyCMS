
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;


namespace LyyCMS.Members.DomainService
{
    public interface IVerificationCodeManager : IDomainService
    {


		/// <summary>
		/// 返回表达式数的实体信息即IQueryable类型
		/// </summary>
		/// <returns></returns>
		IQueryable<VerificationCode> QueryVerificationCodes();

		/// <summary>
		/// 返回性能更好的IQueryable类型，但不包含EF Core跟踪标记
		/// </summary>
		/// <returns></returns>

		IQueryable<VerificationCode> QueryVerificationCodesAsNoTracking();

		/// <summary>
		/// 根据Id查询实体信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<VerificationCode> FindByIdAsync(int id);
	
		/// <summary>
		/// 检查实体是否存在
		/// </summary>
		/// <returns></returns>
		Task<bool> IsExistAsync(int id);


		/// <summary>
		/// 添加验证码
		/// </summary>
		/// <param name="entity">验证码实体</param>
		/// <returns></returns>
		Task<VerificationCode> CreateAsync(VerificationCode entity);

		/// <summary>
		/// 修改验证码
		/// </summary>
		/// <param name="entity">验证码实体</param>
		/// <returns></returns>
		Task UpdateAsync(VerificationCode entity);

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(int id);
		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="input">Id的集合</param>
		/// <returns></returns>
		Task BatchDelete(List<int> input);


		
							//// custom codes
									
							

							//// custom codes end

		 
      
         

    }
}
