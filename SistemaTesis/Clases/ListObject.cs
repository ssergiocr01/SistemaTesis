using Microsoft.AspNetCore.Identity;
using SistemaTesis.Data;
using SistemaTesis.Models;
using System.Collections.Generic;

namespace SistemaTesis.Clases
{
    public class ListObject
    {
        public List<object[]> data = new List<object[]>();
        public ApplicationDbContext context;
        //public List<Inscripcion> dataInscripcion = new List<Inscripcion>();
        public List<Canton> cantones = new List<Canton>();
        public List<Distrito> distritos = new List<Distrito>();
        public List<Asentamiento> asentamientos = new List<Asentamiento>();
        //public List<Curso> misCursos = new List<Curso>();
        public List<IdentityError> errorList = new List<IdentityError>();
    }
}
