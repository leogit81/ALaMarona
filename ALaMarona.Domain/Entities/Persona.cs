﻿using Eg.Core;
using System;

namespace ALaMarona.Domain.Entities
{
    public class Persona : Entity<long>
    {
        public virtual Nombre Nombre { get; set; }
        public virtual Direccion Domicilio { get; set; }
        public virtual string Telefono { get; set; }
        public virtual Documento Documento { get; set; }
        public virtual DateTime? FechaNacimiento { get; set; }
        public virtual Direccion LugarNacimiento { get; set; }
        protected string estadocivil;
        public virtual string EstadoCivil
        {
            get
            {
                return estadocivil;
            }
            set
            {
                if (Entities.EstadoCivil.IsValid(value))
                {
                    estadocivil = value;
                }
            }
        }
    }
}
