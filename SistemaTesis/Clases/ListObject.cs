using Microsoft.AspNetCore.Identity;
using SistemaTesis.Data;
using SistemaTesis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Clases
{
    public class ListObject
    {
        public List<object[]> data = new List<object[]>();
        public ApplicationDbContext context;
        //public List<Inscripcion> dataInscripcion = new List<Inscripcion>();
        public List<Canton> cantones = new List<Canton>();
        //public List<Curso> misCursos = new List<Curso>();
        public List<IdentityError> errorList = new List<IdentityError>();
    }
}
