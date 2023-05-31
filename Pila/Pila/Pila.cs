
using System;
using System.Collections;
using System.Collections.Generic;

namespace Pila
{
	/// <summary>
	/// Description of Pila.
	/// </summary>
	public class Pila <T> //clase de tipo generica
	{
		//atributos
		private List <T> datos= new List<T> (); //creo e instancio una lista de elementos genericos
		
		//constructor
		public Pila()  //vacio
		{
		}
		
		//metodos
		public void apilar(T elem){
			this.datos.Insert(0,elem); //agrega un elem en primera posicion
		}
		
		public T desapilar(){
			T temp = this.datos[0]; //variable que se coloca temporalmente el dato a desapilar
			this.datos.RemoveAt(0); //se elimina el primer elemento elemento de la pila
			return temp; //se retorna ele elemento que ya se elimino	
		}
		
		public T tope(){
			return this.datos[0]; //retorna el primer elemento de la pila
		}
		
		public bool esVacia(){ //retorna true si esta vacia o false si tiene elementos
			return this.datos.Count==0;
		}
	}
}
