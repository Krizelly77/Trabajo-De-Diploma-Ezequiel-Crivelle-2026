using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Capa_de_Servicios_SL_
{
    public class _824_ecSerializadorXml<T>
    {
        public static void Serializar_824_ec(string rutaArchivo, T datos)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                serializador.Serialize(writer, datos);
            }
        }

        public static T Deserializar_824_ec(string rutaArchivo)
        {
            try
            {
                XmlSerializer dserializador = new XmlSerializer(typeof(T));
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    return (T)dserializador.Deserialize(reader);
                }
            }
            catch (XmlException ex)
            {
                // XML invalido o corrupto
                throw new Exception($"El archivo seleccionado no es un XML válido o está corrupto: {ex.Message}", ex);
            }
            catch (InvalidOperationException ex)
            {
                // El XML no coincide con la estructura esperada<T>
                throw new Exception("El archivo XML no corresponde a la estructura de datos esperada.", ex);
            }
            catch (Exception ex)
            {
                // Otros errores
                throw new Exception($"Error de lectura al deserializar: {ex.Message}", ex);
            }
        }
    }
}
