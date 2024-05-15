using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PersonalMedico : Persona
    {
        private List<Consulta> consultas;
        private bool esResidente;
        internal override string FichaExtra()
        {
            StringBuilder sb = new();
            string residencia = "NO";
            if (esResidente)
            {
                residencia = "SI";
            }
            sb.AppendLine($"¿Finalizó residencia?{residencia}");
            sb.AppendLine("ATENCIONES:");

            foreach (Consulta c in consultas)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }
        public PersonalMedico(string nombre, string apellido, DateTime nacimiento, bool esResidente) : base(nombre, apellido, nacimiento)
        {
            consultas = new List<Consulta>();
            this.esResidente = esResidente;
        }

        public static Consulta operator +(PersonalMedico doctor, Paciente paciente)
        {
            Consulta c = new Consulta(DateTime.Now, paciente);
            if (doctor is not null && paciente is not null)
            {
                doctor.consultas.Add(c);
            }
            return c;
        }
    }
}
