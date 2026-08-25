using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Dominio_BE_
{
    public abstract class ComponentePermiso
    {  // componente del composite
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreInterno { get; set; } // Ej: "Menu_Usuarios", "Permiso_Alta"

        // Lista abstracta de hijos 
        public abstract List<ComponentePermiso> Hijos { get; }
        public abstract void AgregarHijo(ComponentePermiso componente);
        public abstract void QuitarHijo(ComponentePermiso componente);
        public override string ToString(){ return Nombre; }
    }

    public class PermisoSimple : ComponentePermiso
    { // hoja de permiso simple
        private List<ComponentePermiso> nada = new List<ComponentePermiso>();
        public override List<ComponentePermiso> Hijos => nada; // Las hojas no tienen hijos

        public override void AgregarHijo(ComponentePermiso componente)
        {
            throw new Exception("No se pueden agregar permisos a una patente simple.");
        }

        public override void QuitarHijo(ComponentePermiso componente)
        {
            throw new Exception("No se pueden quitar permisos de una patente simple.");
        }
    }

    public class Rol : ComponentePermiso
    { // contenedor de permisos
        private List<ComponentePermiso> hijos = new List<ComponentePermiso>();
        public override List<ComponentePermiso> Hijos => hijos;

        public override void AgregarHijo(ComponentePermiso componente)
        {
            hijos.Add(componente);
        }

        public override void QuitarHijo(ComponentePermiso componente)
        {
            hijos.Remove(componente);
        }
    }
}
