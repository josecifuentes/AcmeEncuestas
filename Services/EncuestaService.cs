using System;
using WebApiAcmeEncuestasV1.Models;
using WebApiAcmeEncuestasV1.ViewModels;

namespace WebApiAcmeEncuestasV1.Services
{
    public class EncuestaService
    {
        private AplicationDbContext _context;

        public EncuestaService(AplicationDbContext context)
        {
            _context = context;
        }
        public void AddEncuesta(Encuesta encuesta)
        {
            var _encuesta = new Encuesta()
            {
                nombreEncuesta = encuesta.nombreEncuesta,
                descripcionEncuesta = encuesta.descripcionEncuesta,
                Campos = encuesta.Campos
            };
            _context.Encuesta.Add(_encuesta);
            _context.SaveChanges();
        }
        public List<Encuesta> GetAllEncuestas() => _context.Encuesta.ToList();

        public EncuestaWithCamposVM GetEncuestaById(int encuestaId)
        {
            var _encuestaCampos = _context.Encuesta.Where(n=>n.Id==encuestaId).Select(encuesta => new EncuestaWithCamposVM()
            {
                nombreEncuesta = encuesta.nombreEncuesta,
                descripcionEncuesta = encuesta.descripcionEncuesta,
                Campos = encuesta.Campos.Select(n => n.nombreCampo).ToList()
            }).FirstOrDefault();
            return _encuestaCampos;
        }

        public Encuesta UpdateEncuestaById(int encuestaId,Encuesta encuesta)
        {
            var _encuesta = _context.Encuesta.FirstOrDefault(n => n.Id == encuestaId);
            if(_encuesta!=null)
            {
                _encuesta.nombreEncuesta = encuesta.nombreEncuesta;
                _encuesta.descripcionEncuesta = encuesta.descripcionEncuesta;
                _encuesta.Campos = encuesta.Campos;
                _context.SaveChanges();
            }
            return _encuesta;
        }
        public void DeleteEncuestaById(int encuestaId)
        {
            var _encuesta = _context.Encuesta.FirstOrDefault(n => n.Id == encuestaId);
            if(_encuesta!=null)
            {
                _context.Encuesta.Remove(_encuesta);
                _context.SaveChanges();
            }
        }

        public void LlenarEncuesta(LlenarEncuesta llenado)
        {
            var _encuesta = new LlenarEncuesta()
            {
               NoLlenado = llenado.NoLlenado,
               IdCampo = llenado.IdCampo,
                Datos = llenado.Datos
            };
            _context.Llenarencuesta.Add(_encuesta);
            _context.SaveChanges();
        }
        public LlenarEncuesta GetLlenadoById(int llenadoId) => _context.Llenarencuesta.FirstOrDefault(n => n.id == llenadoId);
       
    }
}
