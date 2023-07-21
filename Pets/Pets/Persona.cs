using System;
using System.Collections.Generic;
using System.Text;

namespace Pets
{
    public class Persona
    {

        public Persona(
            string per_nombre,
            string per_apellido,
            string per_telefono,
            string per_correo,
            string per_direccion
            ) {


            this.per_nombre = per_nombre;
            this.per_apellido = per_apellido;
            this.per_telefono = per_telefono;
            this.per_correo = per_correo;
            this.per_direccion = per_direccion;
        }
        public string per_nombre { get; set; }
             
        public string per_apellido   { get; set; }
        public string per_telefono   { get; set; }
        public string per_correo { get; set; }
        public string per_direccion { get; set; }

    }
}
