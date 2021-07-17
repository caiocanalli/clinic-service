using System;
using System.Threading.Tasks;
using AutoMapper;
using Clinic.Application.Common;
using Clinic.Application.Labs.Requests;
using Clinic.Application.Labs.Responses;
using Clinic.Domain.Common;
using Clinic.Domain.Labs;

namespace Clinic.Application.Labs
{
    public class LabAppService : ILabAppService
    {
        private readonly IMapper _mapper;
        readonly ILabRepository _labRepository;
        readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public LabAppService(
            IMapper mapper,
            ILabRepository labRepository,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            _mapper = mapper;
            _labRepository = labRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Result> Register(RegisterRequest request)
        {
            using var unitOfWork = _unitOfWorkFactory.StartUnitOfWork();

            try
            {
                var lab = new Lab(request.Name, request.Address);
                await _labRepository.Add(lab);
                unitOfWork.Save();

                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(Errors.Default.UnprocessableEntity());
            }
        }

        public async Task<Result<RecoverByIdResponse>> RecoverById(int id)
        {
            var lab = await _labRepository.GetById(id);

            if (lab == null)
                return Result.Fail<RecoverByIdResponse>(Errors.Default.NotFound());

            var response = _mapper.Map<RecoverByIdResponse>(lab);
            return Result.Ok(response);
        }

        public async Task<Result<FilterResponse>> Filter(FilterRequest request)
        {
            var result = await _labRepository.Filter(
                request.Page,
                request.PageSize,
                request.Id,
                request.Name,
                request.Status);
            var response = _mapper.Map<FilterResponse>(result);
            return Result.Ok(response);
        }

        public async Task<Result> Update(UpdateRequest request)
        {
            using var unitOfWork = _unitOfWorkFactory.StartUnitOfWork();
        
            try
            {
                var lab = await _labRepository.GetById(request.Id);

                if (lab == null)
                    return Result.Fail(Errors.Default.NotFound());

                lab.UpdateInfos(request.Name, request.Address);
                await _labRepository.Update(lab);
                unitOfWork.Save();

                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail(Errors.Default.UnprocessableEntity());
            }
        }

        public async Task<Result> Activate(int id)
        {
            using var unitOfWork = _unitOfWorkFactory.StartUnitOfWork();

            var lab = await _labRepository.GetById(id);

            if (lab == null)
                return Result.Fail(Errors.Default.NotFound());

            lab.Activate();
            await _labRepository.Update(lab);
            unitOfWork.Save();

            return Result.Ok();
        }

        public async Task<Result> Inactivate(int id)
        {
            using var unitOfWork = _unitOfWorkFactory.StartUnitOfWork();

            var lab = await _labRepository.GetById(id);

            if (lab == null)
                return Result.Fail(Errors.Default.NotFound());

            lab.Inactivate();
            await _labRepository.Update(lab);
            unitOfWork.Save();

            return Result.Ok();
        }
    }
}