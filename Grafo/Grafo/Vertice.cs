using System;
using System.Collections;
using System.Collections.Generic;

namespace Grafo
{
	/// <summary>
	/// Description of Vertice.
	/// </summary>
	public class Vertice<T>
	{
		//atributos		
		private List<Arista<T>> adyacentes; 
		private T dato;
		private int posicion;
		
		//constructores
		public Vertice()
		{
		}
	
	    public Vertice(T d){
			dato = d;
			adyacentes = new List<Arista<T>>();
			
		}
		
		//propiedades
		public T getDato() {
			return dato;
		}

		public void setDato(T unDato) {
			dato = unDato;
		}

		
		public int getPosicion() {
			return posicion;
		}
	
		public List<Arista<T>> getAdyacentes(){
			return adyacentes;
		}
	
		public void setPosicion(int pos){
			posicion = pos; 
		}
		
	}
}
