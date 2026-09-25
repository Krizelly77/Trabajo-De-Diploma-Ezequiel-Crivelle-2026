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
        public static bool ValidacionHabilitada { get; set; } = true; // Para desabilitar DV de forma ordenada
        public string ValidarIntegridadDelSistema()
        {   //Escanea las tablas críticas del sistema antes de habilitar el Login

            if (!ValidacionHabilitada) return "ok";

            // 1. Validar Usuario
            string resUsuario = ValidarTabla<Usuario>("Usuario", "Usuario_DVH", () => UsuarioDAL.Listar().Cast<IVerificable>().ToList());
            if (resUsuario != "ok") return resUsuario;

            // 2. Validar Categoria
            string resCategoria = ValidarTabla<_824_ecCategoria>("Categoria", "Categoria_DVH", () => _824_ecCategoriaDAL.Listar_824_ec().Cast<IVerificable>().ToList());
            if (resCategoria != "ok") return resCategoria;

            // 3. Validar Actividad
            string resActividad = ValidarTabla<_824_ecActividad>("Actividad", "Actividad_DVH", () => _824_ecActividadDAL.ListarTodas_824_ec().Cast<IVerificable>().ToList());
            if (resActividad != "ok") return resActividad;

            // 4. Validar Postulacion
            string resPostulacion = ValidarTabla<_824_ecPostulacion>("Postulacion", "Postulacion_DVH", () => _824_ecPostulacionDAL.ListarTodas_824_ec().Cast<IVerificable>().ToList());
            if (resPostulacion != "ok") return resPostulacion;

            return "ok";
        }

        private string ValidarTabla<T>(string nombreTabla, string campoDVH, Func<List<IVerificable>> obtenerLista) where T : IVerificable
        {
            List<IVerificable> lista = obtenerLista();

            if (lista == null || lista.Count == 0)
            {
                string dvvGuardadoVacio = DigitoVerificadorDAL.ObtenerDVVPorTabla(nombreTabla);
                CryptoManager cm = new CryptoManager();
                if (dvvGuardadoVacio != cm.Hash("TABLA_VACIA"))
                    return $"FALLO DE INTEGRIDAD: La tabla {nombreTabla} fue vaciada externamente";

                return "ok";
            }

            // Validar DVH
            List<string> hashesDVH = new List<string>();
            foreach (var entidad in lista)
            {
                string dvhCalculado = validador.CalcularDVH(entidad);
                string dvhGuardado = GetDVHFromEntidad(entidad);

                if (dvhGuardado != dvhCalculado)
                    return $"FALLO DE INTEGRIDAD HORIZONTAL: Registro alterado en la tabla {nombreTabla}";

                hashesDVH.Add(dvhCalculado);
            }

            // Validar DVV
            string dvvCalculado = validador.CalcularDVV(hashesDVH);
            string dvvGuardado = DigitoVerificadorDAL.ObtenerDVVPorTabla(nombreTabla);

            if (dvvGuardado != dvvCalculado)
                return $"FALLO DE INTEGRIDAD VERTICAL: Modificación de estructura o eliminación en la tabla {nombreTabla}";

            return "ok";
        }

        public void RecalcularIntegridadTabla<T>(string nombreTabla, string campoId, Func<List<T>> obtenerLista, Func<T, int> obtenerId, Action<T, string> asignarDVH) where T : IVerificable
        {
            List<T> lista = obtenerLista();
            List<string> hashesDVH = new List<string>();

            if (lista != null && lista.Count > 0)
            {
                foreach (var entidad in lista)
                {
                    string nuevoDVH = validador.CalcularDVH(entidad);
                    asignarDVH(entidad, nuevoDVH);
                    hashesDVH.Add(nuevoDVH);

                    DigitoVerificadorDAL.ActualizarDVHTabla_824_ec(nombreTabla, campoId, obtenerId(entidad), nuevoDVH);
                }

                string nuevoDVV = validador.CalcularDVV(hashesDVH);
                DigitoVerificadorDAL.GuardarDVV(nombreTabla, nuevoDVV);
            }
            else
            {
                CryptoManager cm = new CryptoManager();
                DigitoVerificadorDAL.GuardarDVV(nombreTabla, cm.Hash("TABLA_VACIA"));
            }
        }

        public void RecalcularIntegridadGlobal()
        {
            // Recalcular todas las tablas del sistema
            RecalcularIntegridadTabla("Usuario", "Usuario_Id", UsuarioDAL.Listar, u => u.Id, (u, dvh) => u.DVH = dvh);
            RecalcularIntegridadTabla("Categoria", "Categoria_Id", _824_ecCategoriaDAL.Listar_824_ec, c => c.Id_824_ec, (c, dvh) => c.DVH_824_ec = dvh);
            RecalcularIntegridadTabla("Actividad", "Actividad_Id", _824_ecActividadDAL.ListarTodas_824_ec, a => a.Id_824_ec, (a, dvh) => a.DVH_824_ec = dvh);
            RecalcularIntegridadTabla("Postulacion", "Postulacion_Id", _824_ecPostulacionDAL.ListarTodas_824_ec, p => p.Id_824_ec, (p, dvh) => p.DVH_824_ec = dvh);
        }

        private string GetDVHFromEntidad(IVerificable entidad)
        {
            if (entidad is Usuario u) return u.DVH;
            if (entidad is _824_ecCategoria c) return c.DVH_824_ec;
            if (entidad is _824_ecActividad a) return a.DVH_824_ec;
            if (entidad is _824_ecPostulacion p) return p.DVH_824_ec;
            return null;
        }

        public int BloquearUsuariosPorFallaIntegridad()
        {
            return UsuarioDAL.BloquearUsuariosPorFalla();
        }
    }
}
