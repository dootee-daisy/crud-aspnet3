using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace crud.KhachHangs
{
    public class KhachHangAppService : CrudAppService<KhachHang, KhachHangDto, string>, IKhachHangAppService
    {
        public readonly IRepository<KhachHang, string> _repository;
        public KhachHangAppService(IRepository<KhachHang, string> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<KhachHang> Create(KhachHang kh)
        {
            var khachHang = await _repository.FirstOrDefaultAsync(o => o.Id == kh.Id);
            if (khachHang != null) throw new UserFriendlyException("Already exist UserName");
            else
            {
                try
                {
                    return await _repository.InsertAsync(khachHang);
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async void Delete(string userName)
        {
            var khachHang = await _repository.FirstOrDefaultAsync(o => o.Id == userName);
            if (khachHang == null) throw new UserFriendlyException("Can not find UserName");
            _repository.Delete(khachHang);
        }

        public async Task<IEnumerable<KhachHang>> GetAllList()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<KhachHang> GetKhachHangByUserName(string userName)
        {
            return await _repository.GetAsync(userName);
        }

        public void Update(KhachHang kh)
        {
             _repository.UpdateAsync(kh);
        }
    }
}
