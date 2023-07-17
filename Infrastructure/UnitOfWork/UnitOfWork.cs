using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork,IDisposable
{    
    private readonly CitasCampusContext _context;
    private AcudienteRepository? _acudiente;
    private CitaRepository? _cita;
    private ConsultorioRepository? _consultorio;
    private EspecialidadRepository? _especialidad;
    private EstadoRepository? _estado;
    private GeneroRepository? _genero;
    private MedicoRepository? _medico;
    private TipoDocumentoRepository? _tipoDocumento;
    private UsuarioRepository? _usuario;

    public UnitOfWork(CitasCampusContext context)=>_context = context;

    public ICitasAPIEntity<Acudiente, int> Acudientes
    {
        get{
            if (_acudiente is not null)
            {
                return _acudiente;
            }
            return _acudiente = new AcudienteRepository(_context);
        }
    }

    public ICitasAPIEntity<Cita, int> Citas
    {
        get{
            if (_cita is not null)
            {
                return _cita;
            }
            return _cita = new CitaRepository(_context);
        }
    }

    public ICitasAPIEntity<Consultorio, int> Consultorios
    {
        get{
            if (_consultorio is not null)
            {
                return _consultorio;
            }
            return _consultorio = new ConsultorioRepository(_context);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public ICitasAPIEntity<Especialidad, int> Especialidades
    {
        get{
            if (_especialidad is not null)
            {
                return _especialidad;
            }
            return _especialidad = new EspecialidadRepository(_context);
        }
    }

    public ICitasAPIEntity<Estado, int> Estados
    {
        get{
            if (_estado is not null)
            {
                return _estado;
            }
            return _estado = new EstadoRepository(_context);
        }
    }

    public ICitasAPIEntity<Genero, int> Generos
    {
        get{
            if (_genero is not null)
            {
                return _genero;
            }
            return _genero = new GeneroRepository(_context);
        }
    }

    public ICitasAPIEntity<Medico, int> Medicos
    {
        get{
            if (_medico is not null)
            {
                return _medico;
            }
            return _medico = new MedicoRepository(_context);
        }
    }

    public async Task<int> SaveAsync(){
        return await _context.SaveChangesAsync();
    }

    public ICitasAPIEntity<TipoDocumento, int> TipoDocumentos
    {
        get{
            if (_tipoDocumento is not null)
            {
                return _tipoDocumento;
            }
            return _tipoDocumento = new TipoDocumentoRepository(_context);
        }
    }

    public ICitasAPIEntity<Usuario, int> Usuarios
    {
        get{
            if (_usuario is not null)
            {
                return _usuario;
            }
            return _usuario = new UsuarioRepository(_context);
        }
    }
}