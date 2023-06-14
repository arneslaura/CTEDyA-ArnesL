using System;
using System.Collections;
using System.Collections.Generic;

namespace Grafo
{
	/// <summary>
	/// Description of Arista.
	/// </summary>
	public class Arista<T>
	{
		//atributos
		private Vertice<T> destino;
		private int peso;
	
		//constructor
		public Arista(Vertice<T> dest, int p){
				destino = dest;
				peso = p;
		}
		
		//propiedades
		public Vertice<T> getDestino() {
			return destino;
		}
		
		public int getPeso() {
			return peso;
		}
		
		public void setDestino(Vertice<T> destino) {
			this.destino= destino;
		}
		
		public void setPeso(int peso) {
			this.peso = peso;
		}
	
	}
}
