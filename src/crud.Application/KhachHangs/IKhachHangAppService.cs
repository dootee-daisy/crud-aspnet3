using Abp.Application.Services;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace crud.KhachHangs
{
    public interface IKhachHangAppService : IDomainService
    {
        IEnumerable<KhachHang> GetAllList();
        KhachHang GetKhachHangByUserName(string userName);
        Task<KhachHang> Create(KhachHang kh);
        void Update(KhachHang kh);
        void Delete(string  userName);
    }
}
