using Capa_de_Acceso_a_Datos_DAL_;
using Capa_de_Dominio_BE_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Aplicación_BLL_
{
    public class _824_ecCategoriaBLL
    {
        public static int Guardar_824_ec(_824_ecCategoria categoria_824_ec)
        {
            if (string.IsNullOrWhiteSpace(categoria_824_ec.Nombre_824_ec))
                throw new Exception("El nombre de la categoría es obligatorio.");

            return _824_ecCategoriaDAL.Guardar_824_ec(categoria_824_ec);
        }

        public static List<_824_ecCategoria> Listar_824_ec()
        {
            return _824_ecCategoriaDAL.Listar_824_ec();
        }

        public static _824_ecCategoria ObtenerPorId_824_ec(int id_824_ec)
        {
            return _824_ecCategoriaDAL.ObtenerPorId_824_ec(id_824_ec);
        }
    }
}
