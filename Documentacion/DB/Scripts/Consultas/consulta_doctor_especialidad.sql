Select Doctors.Apellido, Especialidads.Nombre
from Doctors, EspecialidadDoctors, Especialidads
where
    Doctors.DoctorID = EspecialidadDoctors.Doctor_DoctorID AND
EspecialidadDoctors.Especialidad_EspecilidadID = Especialidads.EspecilidadID