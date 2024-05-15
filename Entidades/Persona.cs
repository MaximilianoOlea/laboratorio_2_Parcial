using System.Text;

namespace Entidades
{
    public abstract class Persona
    {
        protected string apellido;
        protected string barrioResidencia;
        protected DateTime nacimiento;
        protected string nombre;

        public int Edad
        {
            get
            {
                return DateTime.Today.AddTicks(-this.nacimiento.Ticks).Year - 1;
            }
        }

        public string NombreCompleto
        {
            get
            {
                StringBuilder sb = new();
                sb.AppendLine($"{apellido} {nombre}");

                return sb.ToString();   
            }
        }
        internal abstract string FichaExtra();
        public string FichaPersonal(Persona p)
        {
            StringBuilder sb = new();
            sb.AppendLine($"{NombreCompleto}");
            sb.AppendLine($"Edad: {Edad}");
            sb.AppendLine(p.FichaExtra());

            return sb.ToString();
        }
        public Persona(string nombre, string apellido, DateTime nacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacimiento = nacimiento;
        }

        public Persona(string nombre, string apellido, DateTime nacimiento,string barrioResidencia):
            this(nombre,apellido,nacimiento)

        {
            this.barrioResidencia = barrioResidencia;
        }

        public override string ToString()
        {
            return NombreCompleto;
        }

    }
}