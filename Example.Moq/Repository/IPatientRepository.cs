using Example.Moq.Model;

namespace Example.Moq.Repository
{
    public interface IPatientRepository
    {
        long SavePatient(Patient patient);
    }
}
