using Domain;

namespace Services.Abstract
{
    public interface IPatientsService
    {
        void AddOrUpdatePatient(Patient patient);
        Patient GetPatient(string id);
        bool DeletePatient(string id);
    }
}
