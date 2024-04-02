using Abp.Application.Services;
using AutoMapper;
using crud.KhachHangs.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace crud.KhachHangs
{
    public class KhachHangAppService : crudAppServiceBase, IKhachHangAppService
    {
        private readonly KhachHangManager _khachHangManager;
        private readonly IMapper _mapper;
        public KhachHangAppService(KhachHangManager khachHangManager, IMapper mapper)
        {
            _khachHangManager = khachHangManager;
            _mapper = mapper;

        }
        public async Task Create(CreateKhachHangInput input)
        {
            KhachHang kh = _mapper.Map<CreateKhachHangInput, KhachHang>(input);
            await _khachHangManager.Create(kh);
        }

        public void Delete(DeleteKhachHangInput input)
        {
             _khachHangManager.Delete(input.UserName);
        }

        public async Task<IEnumerable<GetKhachHangOutput>> GetAllList()
        {
            var getAll = (await _khachHangManager.GetAllList()).ToList();
            List<GetKhachHangOutput> output = _mapper.Map<List<KhachHang>, List<GetKhachHangOutput>>(getAll);
            return output;
        }   

        public async Task<GetKhachHangOutput> GetKhachHangByUserName(GetKhachHangInput input)
        {
            var getKhachHang = await _khachHangManager.GetKhachHangByUserName(input.UserName);
            GetKhachHangOutput output = _mapper.Map<KhachHang, GetKhachHangOutput>(getKhachHang);
            return output;
        }

        public void Update(UpdateKhachHangInput input)
        {
            KhachHang output = _mapper.Map<UpdateKhachHangInput, KhachHang>(input);
            _khachHangManager.Update(output);
        }

        
    }
}
