﻿using AutoMapper;
using MediatR;
using SRCM.Domain.Entities;
using SRCM.Domain.Interfaces;
using SRCM.Domain.Shared.Transaction;
using SRCM.Services.AppService.Interfaces;
using SRCM.Services.AppService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<PatientViewModel> Search(Expression<Func<Patient, bool>> expression)
        {
            var patients = _patientRepository.Search(expression);
            var patientViewModel = _mapper.Map<IEnumerable<PatientViewModel>>(patients);
            return patientViewModel;
        }

        public IEnumerable<PatientViewModel> Search(Expression<Func<Patient, bool>> expression, int pageNumber, int pageSize)
        {
            var patients = _patientRepository.Search(expression, pageNumber, pageSize);
            var patientsViewModel = _mapper.Map<IEnumerable<PatientViewModel>>(patients);
            return patientsViewModel;
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
