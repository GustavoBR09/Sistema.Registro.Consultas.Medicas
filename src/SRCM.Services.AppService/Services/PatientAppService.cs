using AutoMapper;
using MediatR;
using SRCM.Domain.Entities;
using SRCM.Domain.Interfaces;
using SRCM.Domain.Shared.Transaction;
using SRCM.Services.AppService.Interfaces;
using SRCM.Domain.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SRCM.Domain.Shared.Models;

namespace SRCM.Services.AppService.Services
{
    public class PatientAppService : BaseService, IPatientAppServices
    {
        protected readonly IPatientRepository _patientRepository;
        protected readonly IMapper _mapper;
        public PatientAppService(IPatientRepository patientRepository,
            IMapper mapper,
            IUnitOfWork uoW, 
            IMediator bus) : base(uoW, bus)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public PatientViewModel Add(PatientViewModel viewModel)
        {
            Patient patient = _mapper.Map<Patient>(viewModel);
            patient = _patientRepository.Add(patient);
            Commit();
            PatientViewModel patientViewModel = _mapper.Map<PatientViewModel>(patient);
            return patientViewModel;
        }

        public PatientViewModel GetById(Guid id)
        {
            Patient patient = _patientRepository.GetById(id);
            PatientViewModel patientViewModel = _mapper.Map<PatientViewModel>(patient);
            return patientViewModel;
        }

        public PatientModel GetModelById(Guid id)
        {
            Patient patient = _patientRepository.GetById(id);
            PatientModel patientModel = _mapper.Map<PatientModel>(patient);
            return patientModel;
        }
        public void Remove(Guid id)
        {
            _patientRepository.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<Patient, bool>> expression)
        {
            _patientRepository.Remove(expression);
            Commit();
        }

        public IEnumerable<PatientModel> Search(Expression<Func<Patient, bool>> expression)
        {
            var patients = _patientRepository.Search(expression);
            var patientModel = _mapper.Map<IEnumerable<PatientModel>>(patients);
            return patientModel;
        }

        public IEnumerable<PatientModel> Search(Expression<Func<Patient, bool>> expression, int pageNumber, int pageSize)
        {
            var patients = _patientRepository.Search(expression, pageNumber, pageSize);
            var patientsModel = _mapper.Map<IEnumerable<PatientModel>>(patients);
            return patientsModel;
        }

        public PatientViewModel Update(PatientViewModel viewModel)
        {
            var patient = _mapper.Map<Patient>(viewModel);
            patient = _patientRepository.Update(patient);
            Commit();
            var patientViewModel = _mapper.Map<PatientViewModel>(patient);
            return patientViewModel;
        }
    }
}
