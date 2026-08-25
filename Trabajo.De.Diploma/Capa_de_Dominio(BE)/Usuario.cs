using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Dominio_BE_
{
    public class Usuario: IVerificable
    {
        public Usuario(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }
        public int NivelPermisos {  get; set; }
        public bool BloqueoDV { get; set; }
        public string DVH { get; set; }

        public List<ComponentePermiso> Permisos { get; set; } = new List<ComponentePermiso>();

        public bool TienePermiso(string nombreInterno)
        {
            //verificar si el usuario tiene un permiso especifico
            foreach (ComponentePermiso componente in Permisos)
            {
                if (EvaluarPermisoRecursivo(componente, nombreInterno))
                    return true;
            }
            return false;
        }

        private bool EvaluarPermisoRecursivo(ComponentePermiso nodo, string nombreInternoBuscado)
        {
            if (nodo is PermisoSimple && nodo.NombreInterno == nombreInternoBuscado)
                return true;

            foreach (var hijo in nodo.Hijos)
            {
                if (EvaluarPermisoRecursivo(hijo, nombreInternoBuscado))
                    return true;
            }
            return false;
        }

        public List<string> ObtenerCamposParaDV()
        {
            string permisosConcatenados = "";
            foreach (var p in Permisos) permisosConcatenados += p.Id.ToString() + "-";

            return new List<string>
            {
                this.Id.ToString(),
                this.NombreUsuario,
                this.Contraseña,
                this.Activo.ToString(),
                permisosConcatenados, 
                this.BloqueoDV.ToString()
            };
        }
    }
}
