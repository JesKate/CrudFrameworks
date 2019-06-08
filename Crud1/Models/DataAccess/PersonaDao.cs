using Crud1.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud1.Models.DataAccess
{
	public class PersonaDao
	{
		public void Crear(PersonaModel p)
		{
			using (var contexto = new PersonasEntities())
			{
				Persona per = new Persona();
				per.Nombre = p.Nombre;
				per.Cedula = p.Cedula;
				per.Telefono = p.Telefono;
				per.Direccion = p.Direccion;

				contexto.Persona.Add(per);
				contexto.SaveChanges();
			}
		}
		public List<PersonaModel> Consultar()
		{
			List<PersonaModel> resultado = new List<PersonaModel>();
			using (var contexto = new PersonasEntities())
			{
				var consulta = (from d in contexto.Persona select d).ToList();
				foreach (var item in consulta)
				{
					PersonaModel x = new PersonaModel();
					x.Nombre = item.Nombre;
					x.Cedula = item.Cedula;
					x.Telefono = item.Telefono;
					x.Direccion = item.Direccion;

					resultado.Add(x);
				}
			}
			return resultado;
		}

		public void Eliminar(int id)
		{
			using (var contexto = new PersonasEntities())
			{
				var registro = (from y in contexto.Persona select y).
					Where(z => z.Id.Equals(id)).FirstOrDefault();
				contexto.Persona.Remove(registro);
				contexto.SaveChanges();
			}
		}

		public PersonaModel ConsultarPersona(int id)
		{
			PersonaModel resultado = new PersonaModel();
			using (var contexto = new PersonasEntities())
			{
				var registro = (from c in contexto.Persona select c).
					Where(m => m.Id.Equals(id)).FirstOrDefault();
				resultado.Nombre = registro.Nombre;
				resultado.Cedula = registro.Cedula;
				resultado.Telefono = registro.Telefono;
				resultado.Direccion = registro.Direccion;
			}
			return resultado;
		}
		public void ActualizarPersona(PersonaModel per)
		{
			using (var contexto = new PersonasEntities())
			{
				var registro = (from x in contexto.Persona select x).
				Where(z => z.Id.Equals(per.Id)).FirstOrDefault();

				//3 cambiar
				registro.Nombre = per.Nombre;
				registro.Cedula = per.Cedula;
				registro.Telefono = per.Telefono;
				registro.Direccion = per.Direccion;
				contexto.SaveChanges();
			}
		}
	}
}