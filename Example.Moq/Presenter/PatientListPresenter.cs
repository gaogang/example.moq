namespace Example.Moq.Presenter
{
    public class PatientListPresenter
    {
        private readonly IPatientRegistrationService _patientRegistrationService;

        public PatientListPresenter(IPatientRegistrationService patientRegistrationService)
        {
            _patientRegistrationService = patientRegistrationService;
        }

        public void AddPatient(string patientName)
        {
            RegisterPatient(patientName);

            UpdatePatientList();
        }

        public void RegisterPatient(string name)
        {
            // Register patient
            _patientRegistrationService.RegisterPatient(name);
        }

        public void UpdatePatientList()
        {
            // Update UI
        }
    }
}
