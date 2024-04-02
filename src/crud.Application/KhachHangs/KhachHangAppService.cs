using Abp.Application.Services;
using AutoMapper;
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

namespace crud.KhachHangs
{
    [AbpAuthorize(PermissionNames.Pages_KhachHang)]
    public class KhachHangAppService : crudAppServiceBase, IKhachHangAppService
    {
        private readonly IRepository<KhachHang> _khachHangRepository;
        private readonly IMapper _mapper;
        public KhachHangAppService(IMapper mapper, IRepository<KhachHang> khachHangRepository)
        {
            _mapper = mapper;
            _khachHangRepository = khachHangRepository;

        }
        public async Task<KhachHang> Create(CreateKhachHangInput input)
        {
            KhachHang kh = _mapper.Map<CreateKhachHangInput, KhachHang>(input);
            var isExist = await _khachHangRepository.FirstOrDefaultAsync(o => o.UserName == kh.UserName);
            if (isExist != null) throw new UserFriendlyException("Already exist UserName");
            else
            {
                try
                {
                    return await _khachHangRepository.InsertAsync(kh);
                }catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            
        }
        public async void Delete(DeleteKhachHangInput input)
        {
            var khachHang = await _khachHangRepository.FirstOrDefaultAsync(o => o.UserName == input.UserName);
            if (khachHang == null) throw new UserFriendlyException("UserName is not exist, can't delete");
            else await _khachHangRepository.DeleteAsync(khachHang);
        }

        public async Task<IEnumerable<GetKhachHangOutput>> GetAllList()
        {
            var getAll = await _khachHangRepository.GetAllListAsync();
            List<GetKhachHangOutput> output = _mapper.Map<List<KhachHang>, List<GetKhachHangOutput>>(getAll);
            return output;
        }   

        public async Task<GetKhachHangOutput> GetKhachHangByUserName(GetKhachHangInput input)
        {
            var isExist = await _khachHangRepository.FirstOrDefaultAsync(o => o.UserName == input.UserName);
            if (isExist == null) throw new UserFriendlyException("Can't find UserName");
            GetKhachHangOutput khachHang = _mapper.Map<KhachHang, GetKhachHangOutput>(isExist);
            return khachHang;
        }

        public async void Update(UpdateKhachHangInput input)
        {
            KhachHang output = _mapper.Map<UpdateKhachHangInput, KhachHang>(input);
            await _khachHangRepository.UpdateAsync(output);
        }


    }
}
