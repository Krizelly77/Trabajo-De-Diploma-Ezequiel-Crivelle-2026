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
    public class UsuarioBLL
    {
        private CryptoManager crypton = new CryptoManager();
        private DigitoVerificadorBLL DVbll = new DigitoVerificadorBLL();
        private GestorDeAuditoria auditor = new GestorDeAuditoria();
        public int Guardar(Usuario usa)
        {
            usa.NombreUsuario = usa.NombreUsuario.Trim();

            if (usa.Id == 0)
            {
                usa.Contraseña = usa.Contraseña.Trim();
                ValidarCredenciales(usa.NombreUsuario, usa.Contraseña);
                usa.Contraseña = crypton.Hash(usa.Contraseña);

                // 1. INSERT inicial para que SQL Server le asigne su Id
                UsuarioDAL.Guardar(usa);

                // 2. Sincronizar DVH del usuario y DVV de la tabla Usuario
                RecalcularIntegridadUsuario();

                auditor.RegistrarAlta(usa);
                return 1;
            }
            Usuario antes = UsuarioDAL.ObtenerPorId(usa.Id);
            // 1. Update de los datos del usuario
            int resultado = UsuarioDAL.Guardar(usa);

            // 2. Sincronizar DVH del usuario y DVV de la tabla Usuario
            if (resultado > 0)
            {
                RecalcularIntegridadUsuario();
                auditor.RegistrarCambios(antes, usa);
            }

            return resultado;
        }

        public int Eliminar(Usuario usa)
        {
            auditor.RegistrarBaja(usa);
            int resultado = UsuarioDAL.Eliminar(usa);

            // Re-calcular el DVV vertical de la tabla tras la eliminación
            if (resultado > 0)
                RecalcularIntegridadUsuario(true);
            return resultado;
        }

        private void RecalcularIntegridadUsuario(bool post = false)
        {
            DVbll.RecalcularIntegridadTabla("Usuario","Usuario_Id",UsuarioDAL.Listar,
                u => u.Id,(u, dvh) => u.DVH = dvh
            );
            if (post)
            {
                DVbll.RecalcularIntegridadTabla("Postulacion", "Postulacion_Id", _824_ecPostulacionDAL.ListarTodas_824_ec,
                    p => p.Id_824_ec, (p, dvh) => p.DVH_824_ec = dvh);
            }
        }

        // metodos de solo lectura 
        public static Usuario ObtenerPorId(int pid)
        {
            return UsuarioDAL.ObtenerPorId(pid);
        }
        public static List<Usuario> Listar()
        {
            return UsuarioDAL.Listar();
        }
        public string Login(string usa, string pas)
        {
            string username = usa.Trim();
            string password = pas.Trim();
            ValidarCredenciales(username, password);
            Usuario usuario = UsuarioDAL.ObtenerPorNombre(username);

            if (usuario == null || !usuario.Activo) // si no se encuentra usuario o esta inactivo
                return "El usuario no tiene una cuenta activa";

            if (usuario.BloqueoDV && !usuario.TienePermiso("Bitacorizador")) // si no se encuentra usuario o esta inactivo
                return "El usuario esta bloqueado debido a una falla de integridad en el sistema";

            if (crypton.Compare(password, usuario.Contraseña))
            {
                SessionManager.TraerInstancia().Login(usuario);
                return "Exito";
            }
            return "Contraseña invalida";
        }
        //metodos de soporte
        public void ValidarCredenciales(string usuario, string password)
        {
            //quiza esto tendriamos que acalararlo en la documentacion 
            if (string.IsNullOrWhiteSpace(usuario))
                throw new Exception("Usuario invalido");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Contraseña invalida");

            if (usuario.Length > 50)
                throw new Exception("Usuario demasiado largo");

            if (password.Length > 100)
                throw new Exception("Contraseña demasiado larga");
        }
        public static void CargarHistorialParticipaciones(Usuario usuario)
        {
            if (usuario == null)
                throw new Exception("El usuario provisto es nulo");

            UsuarioDAL.CargarHistorialParticipaciones(usuario);
        }
    }
}
