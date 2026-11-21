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

        // metodos de serializacion de participantes
        public static void SerializarParticipantesXML(string rutaArchivo, List<_824_ecParticipante> participantes)
        {
            _824_ecSerializadorXml<List<_824_ecParticipante>>.Serializar_824_ec(rutaArchivo, participantes);
        }

        public static List<_824_ecParticipante> DeserializarParticipantesXML(string rutaArchivo)
        {
            List<_824_ecParticipante> participantes = _824_ecSerializadorXml<List<_824_ecParticipante>>.Deserializar_824_ec(rutaArchivo);

            if (participantes == null)
            {
                throw new Exception("El archivo XML deserializado no contiene datos");
            }
            foreach (var part in participantes)
            {
                if (string.IsNullOrWhiteSpace(part.Nombre_824_ec) || string.IsNullOrWhiteSpace(part.Apellido_824_ec))
                {
                    throw new Exception("El archivo XML contiene registros de participantes con estructura inválida (faltan campos obligatorios como nombre o apellido)");
                }
            }
            return participantes;
        }

        // metodos de serializacion de solicitantes
        public static void SerializarSolicitantesXML(string rutaArchivo, List<_824_ecSolicitante> solicitantes)
        {
            _824_ecSerializadorXml<List<_824_ecSolicitante>>.Serializar_824_ec(rutaArchivo, solicitantes);
        }

        public static List<_824_ecSolicitante> DeserializarSolicitantesXML(string rutaArchivo)
        {
            List<_824_ecSolicitante> solicitantes = _824_ecSerializadorXml<List<_824_ecSolicitante>>.Deserializar_824_ec(rutaArchivo);

            if (solicitantes == null)
            {
                throw new Exception("El archivo XML deserializado no contiene datos");
            }
            foreach (var sol in solicitantes)
            {
                if (string.IsNullOrWhiteSpace(sol.Nombre_824_ec) || string.IsNullOrWhiteSpace(sol.Apellido_824_ec))
                {
                    throw new Exception("El archivo XML contiene registros de solicitantes con estructura inválida (faltan campos obligatorios como nombre o apellido)");
                }
            }
            return solicitantes;
        }
    }
}
