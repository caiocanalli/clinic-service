using System;
using System.Threading.Tasks;
using AutoMapper;
using Clinic.Application.Common;
using Clinic.Application.Exams.Requests;
using Clinic.Application.Exams.Responses;
using Clinic.Domain.Common;
using Clinic.Domain.Exams;
using Clinic.Domain.Labs;

namespace Clinic.Application.Exams
{
    public class ExamAppService : IExamAppService
    {
        readonly IMapper _mapper;
        private readonly ILabRepository _labRepository;
        readonly IExamRepository _examRepository;
        readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ExamAppService(
            IMapper mapper,
            ILabRepository labRepository,
            IExamRepository examRepository,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            _mapper = mapper;
            _labRepository = labRepository;
            _examRepository = examRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Result> Register(RegisterRequest request)
        {
            using var unitOfWork = _unitOfWorkFactory.StartUnitOfWork();

            try
            {
                var labs = await _labRepository.Get(request.LabIds);

                if (labs.Count != request.LabIds.Count)
                    return Result.Fail(Errors.Default.NotFound());

                var exam = new Exam(request.Name, request.Type, labs);
                await _examRepository.Add(exam);
                unitOfWork.Save();

                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail(Errors.Default.UnprocessableEntity());
            }
        }

        public async Task<Result<RecoverByIdResponse>> RecoverById(int id)
        {
            var exam = await _examRepository.GetByIdWithLabs(id);

            if (exam == null)
                return Result.Fail<RecoverByIdResponse>(Errors.Default.NotFound());

            var response = _mapper.Map<RecoverByIdResponse>(exam);
            return Result.Ok(response);
        }

        public async Task<Result<FilterResponse>> Filter(FilterRequest request)
        {
            var result = await _examRepository.Filter(
                request.Page,
                request.PageSize,
                request.Id,
                request.Name,
                request.Type,
                request.Status);
            var response = _mapper.Map<FilterResponse>(result);
            return Result.Ok(response);
        }

        public async Task<Result> Activate(int id)
        {
            using var unitOfWork = _unitOfWorkFactory.StartUnitOfWork();

            var exam = await _examRepository.GetById(id);

            if (exam == null)
                return Result.Fail(Errors.Default.NotFound());

            exam.Activate();
            await _examRepository.Update(exam);
            unitOfWork.Save();

            return Result.Ok();
        }

        public async Task<Result> Inactivate(int id)
        {
            using var unitOfWork = _unitOfWorkFactory.StartUnitOfWork();

            var exam = await _examRepository.GetById(id);

            if (exam == null)
                return Result.Fail(Errors.Default.NotFound());

            exam.Inactivate();
            await _examRepository.Update(exam);
            unitOfWork.Save();

            return Result.Ok();
        }

        public async Task<Result> Update(UpdateRequest request)
        {
            using var unitOfWork = _unitOfWorkFactory.StartUnitOfWork();

            try
            {
                var exam = await _examRepository.GetByIdWithLabs(request.Id);

                if (exam == null)
                    return Result.Fail(Errors.Default.NotFound());

                var labs = await _labRepository.Get(request.LabIds);

                if (labs.Count != request.LabIds.Count)
                    return Result.Fail(Errors.Default.NotFound());

                exam.UpdateInfos(request.Name, request.Type, labs);

                await _examRepository.Update(exam);
                unitOfWork.Save();

                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail(Errors.Default.UnprocessableEntity());
            }
        }
    }
}