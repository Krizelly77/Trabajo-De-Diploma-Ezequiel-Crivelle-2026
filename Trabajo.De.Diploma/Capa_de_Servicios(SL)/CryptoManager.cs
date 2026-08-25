using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Capa_de_Servicios_SL_
{
    public class CryptoManager //encriptador para usar desde bll
    {
        public string Hash(string texto)
        {
            using (SHA256 hasheador = SHA256.Create())
            {
                // transforma la contraseña en bytes y la hashea devolviendo un Devuelve un array de bytes binario
                byte[] bytes = hasheador.ComputeHash(Encoding.UTF8.GetBytes(texto)); 
                //builder para covertir bytes a string hexadesimal(por eso el x2 en tostring)
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes) 
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        public bool Compare(string contraIngresada, string contraGuardada) //comparamos la contraseña con el hash guardado
        {
            if(Hash(contraIngresada) == contraGuardada)
                return true;

            return false;
        }
    }
}
