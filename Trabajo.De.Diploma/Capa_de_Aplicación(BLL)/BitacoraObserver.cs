using Capa_de_Servicios_SL_;

namespace Capa_de_Aplicación_BLL_
{
    public class BitacoraObserver : ISessionObserver
    {
        public void Actualizar(string usuario, string actividad)
        {
            BitacoraBLL.Registrar(usuario, actividad);
        }
    }
}
