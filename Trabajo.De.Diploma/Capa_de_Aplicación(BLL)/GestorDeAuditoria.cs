using Capa_de_Acceso_a_Datos_DAL_;
using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Aplicación_BLL_
{
    public class GestorDeAuditoria
    {
        private HistorialCambiosDAL historialDAL = new HistorialCambiosDAL();

        public void RegistrarCambios(Usuario antes, Usuario despues)
        {
            string operador = SessionManager.TraerInstancia().usuarioINS.NombreUsuario;
            List<RegistroCambio> cambios = new List<RegistroCambio>();

            if (antes.NombreUsuario != despues.NombreUsuario)
                cambios.Add(Cambio(despues.Id, "NombreUsuario", antes.NombreUsuario, despues.NombreUsuario, operador));

            if (antes.Activo != despues.Activo)
                cambios.Add(Cambio(despues.Id, "Activo", antes.Activo.ToString(), despues.Activo.ToString(), operador));

            if (antes.NivelPermisos != despues.NivelPermisos)
                cambios.Add(Cambio(despues.Id, "NivelPermisos", antes.NivelPermisos.ToString(), despues.NivelPermisos.ToString(), operador));

            if (cambios.Count > 0)
                historialDAL.GuardarCambios(cambios);
        }

        public void RegistrarAlta(Usuario usuario)
        {
            string operador = SessionManager.TraerInstancia().usuarioINS.NombreUsuario;
            List<RegistroCambio> cambios = new List<RegistroCambio>
            {
                Cambio(usuario.Id, "NombreUsuario", null, usuario.NombreUsuario, operador),
                Cambio(usuario.Id, "Activo",        null, usuario.Activo.ToString(), operador),
                Cambio(usuario.Id, "NivelPermisos", null, usuario.NivelPermisos.ToString(), operador)
            };
            historialDAL.GuardarCambios(cambios);
        }

        public void RegistrarBaja(Usuario usuario)
        {
            string operador = SessionManager.TraerInstancia().usuarioINS.NombreUsuario;
            List<RegistroCambio> cambios = new List<RegistroCambio>
            {
                Cambio(usuario.Id, "NombreUsuario", usuario.NombreUsuario, null, operador),
                Cambio(usuario.Id, "Activo",        usuario.Activo.ToString(), null, operador),
                Cambio(usuario.Id, "NivelPermisos", usuario.NivelPermisos.ToString(), null, operador)
            };
            historialDAL.GuardarCambios(cambios);
        }

        public List<RegistroCambio> ObtenerHistorial(int usuarioId)
        {
            return historialDAL.ObtenerHistorialDeUsuario(usuarioId);
        }

        private RegistroCambio Cambio(int entidadId, string campo, string anterior, string nuevo, string operador)
        {
            return new RegistroCambio
            {
                EntidadNombre = "Usuario",
                EntidadId = entidadId,
                NombreCampo = campo,
                ValorAnterior = anterior,
                ValorNuevo = nuevo,
                Operador = operador,
                FechaHora = DateTime.Now
            };
        }
    }
}
