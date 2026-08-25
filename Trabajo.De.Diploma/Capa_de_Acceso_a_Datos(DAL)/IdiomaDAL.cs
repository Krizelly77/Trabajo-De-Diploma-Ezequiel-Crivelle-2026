using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Capa_de_Acceso_a_Datos_DAL_
{
    public class IdiomaDAL
    {
        // Devuelve la lista de idiomas disponibles leyendo las columnas de la tabla Etiqueta
        public static List<string> ObtenerIdiomas()
        {
            string comando = @"SELECT COLUMN_NAME
                               FROM INFORMATION_SCHEMA.COLUMNS
                               WHERE TABLE_NAME = 'Etiqueta'
                                 AND COLUMN_NAME <> 'Clave'
                               ORDER BY ORDINAL_POSITION";
            DAO dao = new DAO();
            DataSet ds = dao.ObtenerDataSet(comando);

            List<string> lista = new List<string>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                    lista.Add(fila["COLUMN_NAME"].ToString());
            }
            return lista;
        }

        // Devuelve el diccionario clave -> texto para el idioma pedido
        public static Dictionary<string, string> ObtenerDiccionario(string idioma)
        {
            ValidarNombreIdioma(idioma);

            string comando = $"SELECT Clave, [{idioma}] AS Texto FROM Etiqueta WHERE [{idioma}] IS NOT NULL AND [{idioma}] <> ''";
            DAO dao = new DAO();
            DataSet ds = dao.ObtenerDataSet(comando);

            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                    diccionario[fila["Clave"].ToString()] = fila["Texto"].ToString();
            }
            return diccionario;
        }

        // Trae todas las etiquetas con todas sus traducciones (para la grilla)
        public static DataTable ObtenerTodasLasEtiquetas()
        {
            string comando = "SELECT * FROM Etiqueta ORDER BY Clave";
            DAO dao = new DAO();
            DataSet ds = dao.ObtenerDataSet(comando);
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            return new DataTable();
        }

        // Agrega una nueva columna de idioma a la tabla
        public static void AgregarIdioma(string nombre)
        {
            ValidarNombreIdioma(nombre);
            string comando = $"ALTER TABLE Etiqueta ADD [{nombre}] NVARCHAR(200)";
            DAO dao = new DAO();
            dao.EjecutarNonQuery(comando, new List<SqlParameter>());
        }

        // Actualiza la traduccion de una clave para un idioma especifico
        public static void ActualizarTraduccion(string clave, string idioma, string texto)
        {
            ValidarNombreIdioma(idioma);
            string comando = $"UPDATE Etiqueta SET [{idioma}] = @texto WHERE Clave = @clave";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@texto", string.IsNullOrEmpty(texto) ? (object)DBNull.Value : texto),
                new SqlParameter("@clave", clave)
            };
            DAO dao = new DAO();
            dao.EjecutarNonQuery(comando, parametros);
        }

        // Valida que el nombre del idioma solo tenga letras (evitar inyeccion SQL)
        private static void ValidarNombreIdioma(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre del idioma no puede estar vacío.");
            if (!Regex.IsMatch(nombre, @"^[\p{L}\s]+$"))
                throw new Exception("El nombre del idioma solo puede contener letras.");
        }
    }
}
