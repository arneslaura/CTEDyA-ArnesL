using System;
using System.Collections;
using System.Collections.Generic;

namespace TPF
{
	public class Cola<T>
	{
		//atributos
		private List<T> datos = new List<T>();
		
		//constructor
		public Cola()
		{
		}
		
		//metodos
		public void encolar(T elem) //encola elementos
		{
			this.datos.Add(elem);
		}
		
		public T desencolar() //desencola elementos
		{
			T temp = this.datos[0];
			this.datos.RemoveAt(0);
			return temp;
		}
		
		public T tope() //devuelve el primer elemento
		{
			return this.datos[0];
		}
		
		public bool esVacia() //indica si la cola esta vacia
		{
			return this.datos.Count == 0;
		}
		
		public int cantidadElementos() //retorna la cantidad de elementos
		{
			return this.datos.Count;
		}
	}
}
