using ClubDeportivo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class RegistrarSocio
    {
        private E_Usuario usuario;
        private E_Socio socio;
        private E_NoSocio noSocio;


        public RegistrarSocio(E_Usuario usuario, bool asociar)
        {
            this.usuario = usuario;

            if (socio is E_Socio)
            {
                
            }
            else
            {
                this.noSocio = new E_NoSocio();
            }

        }

    }
}