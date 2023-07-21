using System;
using System.Collections.Generic;
using System.Text;

namespace Pets
{
    public class Mascota
    {

        public Mascota(
            string nombre_mascota ,
            string especie        ,
            string edad           ,
            string foto_perfil     )
        {
             nombre_mascota =   nombre_mascota;
             especie        =   especie       ;
             edad           =   edad          ;
             foto_perfil    =   foto_perfil   ;
             
        }         

        public string nombre_mascota  { get; set; }
        public string especie         { get; set; }
        public int edad            { get; set; }
        public string foto_perfil     { get; set; }

        //public string setFoto(string foto_perfil ){
        //    return Convert.ToInt32(foto_perfil, 2);
        //}
    }
}
