using AutoMapper;
using Hospital.DAL;



namespace Hospital.BL;

public class AutoMapperProfile :Profile
{
	public AutoMapperProfile()
	{
		CreateMap<Doctor, DoctorReadDTO>(); /*(Source,target)*/
		CreateMap<DoctorWriteDTO, Doctor>();

		CreateMap<Patient, PatientReadDTO>();
		CreateMap<Issue, IssueChildReadDTO>();
	}
}
