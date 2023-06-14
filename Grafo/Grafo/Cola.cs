
using System;
using System.Collections;
using System.Collections.Generic;

namespace Grafo
{
	/// <summary>
	/// Description of Cola.
	/// </summary>
	public class Cola <T>//calse de tipo generica
	{
		//atributos
		private List <T> datos =new List<T>(); //crea e instacia una lista de datos genericos
		
		//constructor
		public Cola()
		{
		}
		
		//metodos
		public void encolar(T elem){
			this.datos.Add(elem); //agrega el nuevo elemento en la ultima posc
		}
		
		public T desencolar(){
			T temp=this.datos[0]; //variable para colocar temporalmente el dato que se desencola
			this.datos.RemoveAt(0); //se borra el primer dsto de la cola
			return temp; //retorna el dato que se desencola que ya se borro de la cola
		}
		
		public T tope(){
			return this.datos[0]; //retorna el elemento que esta primero en la cola
		}
		
		public bool esVacia(){
			return this.datos.Count==0; //retorna true si la cola esta vacia o false si tiene elementos
		}
	}
}
