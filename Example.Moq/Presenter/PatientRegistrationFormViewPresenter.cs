using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Moq.View;

namespace Example.Moq.Presenter
{
    public class PatientRegistrationFormViewPresenter
    {
        private readonly IPatientRegistrationFormView _view;
        private readonly IPatientRegistrationService _patientRegistrationService;

        public PatientRegistrationFormViewPresenter(IPatientRegistrationFormView view,
            IPatientRegistrationService patientRegistrationService)
        {
            _view = view;
            _patientRegistrationService = patientRegistrationService;
        }

        public void Save()
        {
            _patientRegistrationService.RegisterPatient(_view.PatientName);
        }

        public void Load()
        {
            _view.PatientName = _patientRegistrationService.GetPatient();
        }
    }
}
