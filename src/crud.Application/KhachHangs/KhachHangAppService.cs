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

        public void Delete(string userName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KhachHang> GetAllList()
        {
            throw new NotImplementedException();
        }

        public KhachHang GetKhachHangByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public void Update(KhachHang kh)
        {
            throw new NotImplementedException();
        }
    }
}
