using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente : Persona
    {
        private string diagnostico;
        public string Diagnostico { get; set; }
        internal override string FichaExtra()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Recide en :{barrioResidencia}");
            sb.AppendLine($"{Diagnostico}");

            return sb.ToString();
        }
        public Paciente(string nombre, string apellido, DateTime nacimiento,string barrioResidencia) : 
            base(nombre, apellido, nacimiento,barrioResidencia)
        {

        }
    }
}
