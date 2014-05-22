
namespace Example.Moq
{
    public interface IPatientRegistrationService
    {
        long RegisterPatient(string patientName);

        string GetPatient();
    }
}
