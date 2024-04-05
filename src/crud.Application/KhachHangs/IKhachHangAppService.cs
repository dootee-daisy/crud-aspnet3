﻿using Abp.Application.Services;
using crud.KhachHangs.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace crud.KhachHangs
{
    public interface IKhachHangAppService : IApplicationService
    {
        Task <KhachHangDto> GetKhachHangByUserName(GetKhachHangInput input);
        Task<IEnumerable<KhachHangDto>> GetAllList();
        Task<KhachHang> Create(CreateKhachHangInput input);
        Task Update(UpdateKhachHangInput input);
        Task Delete(DeleteKhachHangInput input);

    }
}
