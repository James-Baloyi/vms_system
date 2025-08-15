using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using sheshapromaxx.vms.Common.Services.Farmers.Dto;
using sheshapromaxx.vms.Domain.Domain.Applications;
using sheshapromaxx.vms.Domain.Domain.Enums;
using sheshapromaxx.vms.Domain.Domain.Programs;
using sheshapromaxx.vms.Domain.Domain.Vouchers;
using sheshapromaxx.vms.Domain.Farmers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramBridge = sheshapromaxx.vms.Domain.Domain.Programs.ProgramBridge;
using DomainApplication = sheshapromaxx.vms.Domain.Domain.Applications.Application;


namespace sheshapromaxx.vms.Common.Services
{
    public class FarmerAppService : SheshaAppServiceBase
    {
        private readonly IRepository<Farmer, Guid> _farmerRepository;
        private readonly IRepository<Voucher, Guid> _voucherRepository;
        private readonly IRepository<Program, Guid> _programRepository;



        public FarmerAppService(IRepository<Farmer, Guid> farmerRepository,
            IRepository<Voucher, Guid> voucherRepository,
            IRepository<Program, Guid> programRepository)
        {
            _farmerRepository = farmerRepository;
            _voucherRepository = voucherRepository;
            _programRepository = programRepository;


        }


        [HttpGet("farmer/getLoggedInFarmerDetailsAsync")]
        public async Task<FarmerDetailsDto> GetLoggedInFarmerDetailsAsync()
        {
            // Get current user ID from session
            var currentUserId = AbpSession.UserId;

            if (!currentUserId.HasValue)
            {
                throw new Abp.Authorization.AbpAuthorizationException("User not logged in");
            }

            // Find farmer by user ID (assuming Farmer entity has a UserId property)
            var farmer = await _farmerRepository.FirstOrDefaultAsync(x => x.User.Id == currentUserId);
            if (farmer == null)
            {
                throw new Abp.UI.UserFriendlyException("Farmer profile not found for current user");
            }

            // Get active vouchers count
            var activeVouchers = await _voucherRepository.GetAllListAsync(
                v => v.Application.Farmer.Id == farmer.Id && v.Status == RefListVoucherStatus.Active
            );
            var activeVouchersCount = activeVouchers.Count;

            // Get enrolled programs count using Program repository
            var allPrograms = await _programRepository.GetAllListAsync();
            var enrolledProgramsCount = allPrograms
                .Where(p => p.Applications.Any(app => app.Farmer.Id == farmer.Id))
                .Count();

            return new FarmerDetailsDto
            {
                FarmerId = farmer.Id,
                FarmSize = farmer.FarmInformation?.FarmSize,
                ProductionSize = farmer.FarmInformation?.ProductionSize,
                NumberOfActiveVouchers = activeVouchersCount,
                NumberOfEnrolledPrograms = enrolledProgramsCount
            };



        }


    }

}
