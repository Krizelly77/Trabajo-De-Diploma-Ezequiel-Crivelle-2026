using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Aplicación_BLL_
{
    public class _824_ecSerializadorBLL
    {

        //metodos de serializacion de usuarios
        public static void SerializarUsuariosXML(string rutaArchivo, List<Usuario> usuarios)
        {
            _824_ecSerializadorXml<List<Usuario>>.Serializar_824_ec(rutaArchivo, usuarios);
        }

        public static List<Usuario> DeserializarUsuariosXML(string rutaArchivo)
        {
            List<Usuario> usuarios = _824_ecSerializadorXml<List<Usuario>>.Deserializar_824_ec(rutaArchivo);

            if (usuarios == null)
            {
                throw new Exception("El archivo XML deserializado no contiene datos");
            }
            foreach (var usu in usuarios)
            {
                if (string.IsNullOrWhiteSpace(usu.NombreUsuario))
                {
                    throw new Exception("El archivo XML contiene registros de usuarios con estructura inválida (faltan campos requeridos)");
                }
            }
            return usuarios;
        }
    }
}
