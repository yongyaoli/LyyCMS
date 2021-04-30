

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LyyCMS.Members.DomainService
{
    /// <summary>
    /// 验证码领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class VerificationCodeManager :LyyCMSDomainServiceBase, IVerificationCodeManager
    {
		
		private readonly IRepository<VerificationCode,int> _verificationCodeRepository;

		/// <summary>
		/// VerificationCode的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	public VerificationCodeManager(IRepository<VerificationCode, int> verificationCodeRepository)	{
			_verificationCodeRepository =  verificationCodeRepository;
		}

		 #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<VerificationCode> QueryVerificationCodes()
        {
            return _verificationCodeRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<VerificationCode> QueryVerificationCodesAsNoTracking()
        {
            return _verificationCodeRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<VerificationCode> FindByIdAsync(int id)
        {
            var entity = await _verificationCodeRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(int id)
        {
            var result = await _verificationCodeRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion

		 
		 
        public async Task<VerificationCode> CreateAsync(VerificationCode entity)
        {
            entity.Id = await _verificationCodeRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(VerificationCode entity)
        {
            await _verificationCodeRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _verificationCodeRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _verificationCodeRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	 
			
							//// custom codes
									
							

							//// custom codes end



		 
		  
		 

	}
}
