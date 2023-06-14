using System;
using System.Collections;
using System.Collections.Generic;

namespace TPF
{

	[Serializable]
	public class DatoDistancia
	{
		//atributos
		private int distancia;
		private string texto;
		private string descripcion;
		
		//constructor
		public DatoDistancia(int distancia, string texto, string descripcion)
		{
			this.distancia = distancia;
			this.texto = texto;
			this.descripcion = descripcion;
		}
		//propiedades
		public int Distancia{
			set{distancia=value;}
			get{return distancia;}
		}
		
		public string Texto{
			set{texto=value;}
			get{return texto;}
		}
		
		public string Descripcion{
			set{descripcion=value;}
			get{return descripcion;}
		}
		
		//metodos
		public override string ToString() //retorna la distancia y el contenido del dato
		{
			if (texto != null)
			{

				return "(" + distancia + ") " + texto;

			}
			else
			{

				return "";
			}
		}

	}
}