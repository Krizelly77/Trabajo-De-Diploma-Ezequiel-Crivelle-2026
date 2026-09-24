- Este proyecto sigue una arquitectura en 5 capas: 
Ingenieria.De.Software   //la UI,
Capa_de_Aplicación(BLL), 
Capa_de_Acceso_a_Datos(DAL),
Capa_de_Dominio(BE),
Capa_de_Servicios(SL).
- La capa UI nunca debe consumir la capa DAL directamente; siempre debe pasar por BLL.
- Las entidades de negocio residen en la capa BLL.
- Para entender los requisitos funcionales (RF1, RF2), roles (Organizador, Participante) y reglas de negocio del sistema, consulta el archivo `docs/Documentacion-EzequielCrivellé.md`.