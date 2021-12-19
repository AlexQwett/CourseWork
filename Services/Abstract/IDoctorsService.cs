using Domain;

namespace Services.Abstract
{
    public interface IDoctorsService
    {
        void AddOrUpdateDoctor(Doctor doctor);
        Doctor GetDoctor(string id);
        bool DeleteDoctor(string id);
    }
}
