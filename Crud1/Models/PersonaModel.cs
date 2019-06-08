using Crud1.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud1.Models
{
	public class PersonaModel
	{
		public int Id { get; set; }

		[Display(Name = "Nombre completo")]
			[StringLength(maximumLength: 50, MinimumLength = 1)]
			public string Nombre { get; set; }
			[Display(Name = "Cédula")]
			

			public int Cedula { get; set; }
			[Display(Name = "Teléfono")]
			
			public int Telefono { get; set; }
			[Display(Name = "Dirección")]
			public string Direccion { get; set; }

			public List<PersonaModel> lista { get; set; }

			public void GuardarPersona()
			{
				PersonaDao perdao = new PersonaDao();
				perdao.Crear(this);
			}
			public List<PersonaModel> ObtenerPersonas()
			{			
				PersonaDao perdao = new PersonaDao();
				return perdao.Consultar();
			}

			public void EliminarPersona(int id)
			{
				PersonaDao edao = new PersonaDao();
				edao.Eliminar(id);
			}
			public PersonaModel Consultar(int id)
			{
				PersonaDao cdao = new PersonaDao();
				return cdao.ConsultarPersona(id);
			}
			public void Actualizar()
			{
				PersonaDao adao = new PersonaDao();
				adao.ActualizarPersona(this);
			}
	}
}