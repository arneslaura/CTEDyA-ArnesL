using System;
using System.Collections;
using System.Collections.Generic;

namespace Grafo
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo<T>
	{
		//vertice
		private List<Vertice<T>>vertices = new List<Vertice<T>>();
		
		//constructor
		public Grafo()
		{
		}
		
		//propiedades
		public List<Vertice<T>> getVertices() {
			return vertices;
		}
	
		//metodos
		public void agregarVertice(Vertice<T> v) {
			v.setPosicion(vertices.Count + 1);
			vertices.Add(v);
		}

		public void eliminarVertice(Vertice<T> v) {
			vertices.Remove(v);
		}

		public void conectar(Vertice<T> origen, Vertice<T> destino, int peso) {
			origen.getAdyacentes().Add(new Arista<T>(destino,peso));
		}

		public void desConectar(Vertice<T> origen, Vertice<T> destino) {
			Arista<T> arista = origen.getAdyacentes().Find(a => a.getDestino().Equals(destino));
			origen.getAdyacentes().Remove(arista);
		}
	
		public Vertice<T> vertice(int posicion) {
			return this.vertices[posicion];
		}
	

		public void DFS(Vertice<T> origen) {//metodo al que llama el usuario
			bool [] visitados=new bool[this.vertices.Count];//arreglo de visitados arranca por defecto con todos en falso
			this._DFS(origen,visitados);//llamada al metodo privado
		}
		
		private void _DFS(Vertice<T> origen, bool[] visitados){//metodo que realmente hace el recorrido (ahorra al usuario pasar la lista
			Console.Write(origen.getDato()+ " ");//primero se imprime el origen
			visitados[origen.getPosicion()-1]=true;//se marca el origen como visitado
			foreach(var adyacente in origen.getAdyacentes()){//recorro la lista de adyacentes del nodo
				if(visitados[adyacente.getDestino().getPosicion()-1]==false){//si el adyacente no fue visitado
					this._DFS(adyacente.getDestino(),visitados);//llamada recursiva
				}
			}
		}
		
		public void BFS(Vertice<T> origen) {
			bool [] visitados=new bool[this.vertices.Count];//arreglo de visitados arranca por defecto con todos en falso
			Cola <Vertice<T>> c=new Cola<Vertice<T>>(); //cola de vertices
			Vertice<T> auxiliar; //vertice auxiliar
			c.encolar(origen);//encolo origen
			visitados[origen.getPosicion()-1]=true;//se marca el origen como visitado
			while(!c.esVacia()){//mientras la cola no este vacia
				auxiliar=c.desencolar();//desencolo vertices
				Console.Write(auxiliar.getDato()+ " "); //imprimo dato
				foreach(var adyacente in auxiliar.getAdyacentes()){//recorro la lista de adyacentes del nodo
				if(visitados[adyacente.getDestino().getPosicion()-1]==false){//si el adyacente no fue visitado
						c.encolar(adyacente.getDestino());//encolo adyacente
						visitados[adyacente.getDestino().getPosicion()-1]=true;//lo marco como visitado
				}
			}
			}
		}
		
		
	}
}
