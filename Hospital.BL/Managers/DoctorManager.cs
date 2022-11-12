using Hospital.DAL;
using AutoMapper;

namespace Hospital.BL
{
    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepo doctorsRepo;
        private readonly IMapper mapper;

        public DoctorManager(IDoctorRepo doctorsRepo,IMapper  _mapper)
        {
            this.doctorsRepo = doctorsRepo;
            this.mapper = _mapper;
        }
        public DoctorReadDTO AddDoctor(DoctorWriteDTO dctr)
        {
           var docWriteDTO = mapper.Map<Doctor>(dctr);
            docWriteDTO.Id = Guid.NewGuid();//adds random ID manually 
            doctorsRepo.Add(docWriteDTO);
            doctorsRepo.SaveChanges();

            return mapper.Map<DoctorReadDTO>(docWriteDTO);
        }

        public void DeleteDoctor(Guid id)
        {
            var doc = doctorsRepo.GetbyID(id);
            if(doc is null)
            {
                return;
            }
            doctorsRepo.Delete(doc);
            doctorsRepo.SaveChanges();

        }

        //Edit
        public Boolean EditDoctor(DoctorWriteDTO dctr)
        {
            var dbdoctor = doctorsRepo.GetbyID(dctr.Id);
            if (dbdoctor == null)
            {
                return false; 
            }
            //dbdoctor.Name=dctr.Name;
            //dbdoctor.Salary = dctr.Salary;
            //dbdoctor.Specialization = dctr.Specialization;
            mapper.Map(dctr,dbdoctor);
            doctorsRepo.Update(dbdoctor);
            doctorsRepo.SaveChanges();
            return true;
        }

        public List<DoctorReadDTO> GetAllDoctors()
        {
            //return doctorsRepo.GetAll();=>Error as the return type is to be DTO

            // mnaual mapping====>(alternative=>>mapper Service)
            //return doctorsRepo.GetAll().Select(d =>
            //new DoctorReadDTO
            //{
            //  Id=d.Id,
            //  Name=d.Name,
            //  Specialization=d.Specialization,
            //  PerformanceRate=d.PerformanceRate 
            //}).ToList();

            var dbdoctors = doctorsRepo.GetAll();

            var newdoc= mapper.Map<List<DoctorReadDTO>>(dbdoctors); //target(source) 
            return newdoc;
        }

        public DoctorReadDTO? GetDoctor(Guid id)
        {
            var doc=doctorsRepo.GetbyID(id);
            if(doc is null)
            {
                return null;
            }
            return mapper.Map<DoctorReadDTO>(doc);

            //return new DoctorReadDTO
            //{
            //    Id = doc.Id,
            //    Name = doc.Name,
            //    Specialization = doc.Specialization,
            //    PerformanceRate = doc.PerformanceRate
            //};
        }
    }
}
