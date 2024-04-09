using Abp.Application.Services;
using crud.KhachHangs.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Authorization;
using crud.Authorization;
using Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore.Internal;

namespace crud.KhachHangs
{
    [AbpAuthorize(PermissionNames.Pages_KhachHang)]
    public class KhachHangAppService : crudAppServiceBase, IKhachHangAppService
    {
        private readonly IRepository<KhachHang> _khachHangRepository;
        public KhachHangAppService(IRepository<KhachHang> khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;

        }
        [AbpAllowAnonymous]
        public async Task<KhachHang> Create(CreateKhachHangInput input)
        {
            var isExist = await _khachHangRepository.FirstOrDefaultAsync(o => o.UserName == input.UserName);
            if (isExist != null) throw new UserFriendlyException("Already exist UserName");
            else
            {
                var kh = new KhachHang
                {
                    UserName = input.UserName,
                    DisplayName = input.DisplayName,
                    NgaySinh = input.NgaySinh,
                };
                try
                {
                    return await _khachHangRepository.InsertAsync(kh);
                }catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            
        }
        [AbpAllowAnonymous]
        public async Task Delete(DeleteKhachHangInput input)
        {
            var khachHang = await _khachHangRepository.FirstOrDefaultAsync(o => o.UserName == input.UserName);
            if (khachHang == null) throw new UserFriendlyException("UserName is not exist, can't delete");
            await _khachHangRepository.DeleteAsync(khachHang);
        }
        [AbpAllowAnonymous]
        public async Task<List<KhachHangDto>> GetAllList(SearchKhachHangInput search = null)
        {
            var getAll =  _khachHangRepository.GetAll();
            if (search != null)
            {
                if (search.keyword != null)
                {
                    getAll = getAll.Where(o => o.UserName.Contains(search.keyword) || o.DisplayName.Contains(search.keyword));
                }
                if (search.startTime != null && search.endTime != null)
                {
                    DateTime startTime = (DateTime)search.startTime;
                    DateTime endTime = (DateTime)search.endTime;
;                   getAll = getAll.Where(o => o.NgaySinh >= startTime && o.NgaySinh <= endTime);
                }
                getAll = getAll.Skip((int)search.skipCount).Take((int)search.maxResultCount);
            }
            List<KhachHangDto> output = await getAll.Select(o => new KhachHangDto
            {
                UserName = o.UserName,
                DisplayName = o.DisplayName,
                NgaySinh = o.NgaySinh,
            }).ToListAsync();
            return output;
        }
        [AbpAllowAnonymous]
        public async Task<KhachHangDto> GetKhachHangByUserName(GetKhachHangInput input)
        {
            var isExist = await _khachHangRepository.FirstOrDefaultAsync(o => o.UserName == input.UserName);
            if (isExist == null) throw new UserFriendlyException("Can't find UserName");
            KhachHangDto khachHang = new KhachHangDto
            {
                UserName = isExist.UserName,
                DisplayName = isExist.DisplayName,
                NgaySinh = isExist.NgaySinh,
            };
            return khachHang;
        }
        [AbpAllowAnonymous]
        public async Task Update(UpdateKhachHangInput input)
        {
            var khachHang = await _khachHangRepository.FirstOrDefaultAsync(o => o.UserName == input.UserName);
            if (khachHang == null)
            {
                throw new UserFriendlyException("User name does'n exist, cant't update!");
            }
            khachHang.DisplayName = input.DisplayName;
            khachHang.NgaySinh = input.NgaySinh;
            await _khachHangRepository.UpdateAsync(khachHang);
        }

    }
}
