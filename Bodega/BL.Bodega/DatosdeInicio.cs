using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bodega
{
   public class DatosdeInicio:CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuarioAdmin = new Seguridad();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";
            contexto.Usuarios.Add(usuarioAdmin);

            base.Seed(contexto);
        }
    }
}
