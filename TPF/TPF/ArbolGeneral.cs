using System;
using System.Collections;
using System.Collections.Generic;

namespace TPF
{
	[Serializable]
	public class ArbolGeneral<T>
	{
		//atributos
		private T dato;
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();
		
		//constructor
		public ArbolGeneral(T dato)
		{
			this.dato = dato;
		}
		
		//propiedades
		public T getDatoRaiz()
		{
			return this.dato;
		}

		public List<ArbolGeneral<T>> getHijos()
		{
			return hijos;
		}
		
		//metodos
		public void agregarHijo(ArbolGeneral<T> hijo) //agrega un hijo
		{
			this.getHijos().Add(hijo);
		}

		public void eliminarHijo(ArbolGeneral<T> hijo) //elimina un hijo
		{
			this.getHijos().Remove(hijo);
		}


		public bool esHoja() //indica si el arbol es una hoja
		{
			return this.getHijos().Count == 0;
		}

	}
}
