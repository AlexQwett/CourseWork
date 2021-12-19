using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Reposirories.Abstract
{
    interface IDoctorsRepository
    {
        void AddDoctor(DoctorEntity doctor);
        void UpdateDoctor(DoctorEntity doctor);
        List<DoctorEntity> GetDoctors();
        void DeleteDoctor(DoctorEntity doctor);
    }
}
