using Core.Entities;

namespace Core.Interfaces;
public interface IUnitOfWork
{
    ICitasAPIEntity<Acudiente,int> Acudientes{get;}
    ICitasAPIEntity<Cita,int> Citas{get;}
    ICitasAPIEntity<Consultorio,int> Consultorios{get;}
    ICitasAPIEntity<Especialidad,int> Especialidades{get;}
    ICitasAPIEntity<Estado,int> Estados{get;}
    ICitasAPIEntity<Genero,int> Generos{get;}
    ICitasAPIEntity<Medico,int> Medicos{get;}
    ICitasAPIEntity<TipoDocumento,int> TipoDocumentos{get;}
    ICitasAPIEntity<Usuario,int> Usuarios{get;}
    
    Task<int> SaveAsync();
}