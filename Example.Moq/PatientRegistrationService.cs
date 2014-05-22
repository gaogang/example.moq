using System.Collections;
using System.Collections.Generic;
using Example.Moq.Model;
using Example.Moq.Repository;

namespace Example.Moq
{
    public class PatientRegistrationService : IPatientRegistrationService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientRegistrationService(IPatientRepository repository)
        {
            _patientRepository = repository;
        }

        public long RegisterPatient(string patientName)
        {
            return _patientRepository.SavePatient(new Patient { PatientName = patientName });
        }

        public string GetPatient()
        {
            throw new System.NotImplementedException();
        }

        public void RegisterPatients(IEnumerable<string> patients)
        {
            foreach (var patient in patients)
            {
                _patientRepository.SavePatient(new Patient {PatientName = patient});
            }
        }
    }
}
