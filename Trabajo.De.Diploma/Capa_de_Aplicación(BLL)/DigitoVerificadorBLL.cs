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
    public class DigitoVerificadorBLL
    {
        private ValidadorDeIntegridad validador = new ValidadorDeIntegridad();

        public string ValidarIntegridadDelSistema()
        {   //Escanea las tablas críticas del sistema antes de habilitar el Login

            // traemos a los usuarios de BD con sus DVHs respectivos
            List<Usuario> listaUsuarios = UsuarioDAL.Listar();

            // Primero nos fijamos si la tabla esta vacia
            if (listaUsuarios == null || listaUsuarios.Count == 0)
            {
                string dvvGuardadoVacio = DigitoVerificadorDAL.ObtenerDVVPorTabla("Usuario");
                CryptoManager cm = new CryptoManager();
                if (dvvGuardadoVacio != cm.Hash("TABLA_VACIA"))
                {
                    return "FALLO DE INTEGRIDAD: La tabla Usuario fue vaciada externamente";
                }
                return "ok"; 
            }

            // Ahora hacemos la validacion horizontal de cada usuario
            foreach (Usuario usu in listaUsuarios)
            {
                string dvhCalculado = validador.CalcularDVH(usu);
                if (usu.DVH != dvhCalculado)
                {
                    return $"FALLO DE INTEGRIDAD HORIZONTAL: El usuario con ID {usu.Id} ({usu.NombreUsuario}) fue modificado fuera de la aplicación";
                }
            }
            // ahora hacemos la validacion vertical
            List<string> listaDVH = listaUsuarios.Select(u => u.DVH).ToList(); // Dejamos solo los DVH de cada usuario
            string dvvCalculado = validador.CalcularDVV(listaDVH); // Calculamos el DVV 
            string dvvGuardado = DigitoVerificadorDAL.ObtenerDVVPorTabla("Usuario"); // Buscamos el DVV guardado en BD
            if (dvvGuardado != dvvCalculado)
            {
                return "FALLO DE INTEGRIDAD VERTICAL: Se detectó la eliminación de registros completos o alteración del orden estructural en la tabla Usuario";
            }

            return "ok"; // devuelve true si todo esta integro
        }
        public void RecalcularUsuariosDVV()
        {   //recalcula en nuevo DVV y lo guarda
            List<Usuario> usuariosActuales = UsuarioDAL.Listar();
            if (usuariosActuales != null && usuariosActuales.Count > 0)
            {
                List<string> listaHashes = usuariosActuales.Select(u => u.DVH).ToList(); // dvh de cada usuario
                string nuevoDVV = validador.CalcularDVV(listaHashes);
                DigitoVerificadorDAL.GuardarDVV("Usuario", nuevoDVV); //persistir en la bd el nuevo dvv
            }
            else
            {
                CryptoManager cm = new CryptoManager();
                DigitoVerificadorDAL.GuardarDVV("Usuario", cm.Hash("TABLA_VACIA")); //si la tabla quedo vacia
            }
        }
        public int BloquearUsuariosPorFallaIntegridad()
        { // llama a dal para bloquear a los usuarios
            return UsuarioDAL.BloquearUsuariosPorFalla();
        }
    }
}
