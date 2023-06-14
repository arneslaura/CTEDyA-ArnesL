/*
 * Creado por SharpDevelop.
 * Usuario: Chichitos
 * Fecha: 2/6/2023
 * Hora: 04:22
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Grafo
{
	/// <summary>
	/// Description of Caminos.
	/// </summary>
	public class Caminos<T>
	{
		//constructor
		public Caminos()
		{
		}
		
		//metodos
		public void caminosimpleconDFS(Grafo<T> grafo, Vertice<T> origen, Vertice<T> destino){
			List<Vertice<T>> camino= new List<Vertice<T>>();//creo lista donde guardar camino
			bool b=_caminosimpleconDFS(grafo, origen,destino,camino);//llamo al metodo que hace el trabajo
		}
		
		private bool _caminosimpleconDFS(Grafo<T> grafo, Vertice<T> origen, Vertice<T> destino,List<Vertice<T>>camino){
			bool[] visitados = new bool[grafo.getVertices().Count];//creo lista de visitados
			camino.Add(origen);//agrego el origen en el camino
			visitados[origen.getPosicion() - 1] = true;//marco origen como visitado
			if(origen == destino)//si el origen es igual al destino
			{
				foreach (var element in camino) 
					Console.Write(element.getDato() + " ");//imprime y termina
				return true;	
			}
			else
			{
				foreach (var adyacente in origen.getAdyacentes()) {
					if(!visitados[adyacente.getDestino().getPosicion() - 1])//si los adyacentes no fueron visitados
					{
						bool ok = _caminosimpleconDFS(grafo,adyacente.getDestino(), destino, camino);//llamada recursiva
						if(ok)//si la llamada da true
							return true;//termina
						camino.RemoveAt(camino.Count-1);//saca ultimo vertice adyacente sirve para volver atras		
					}
				}
			}
			return false;	
		}
		
		public void verticesADistanciaConBFS(Grafo<T> grafo, Vertice<T> origen, int nroDeAristas){
			bool [] visitados=new bool[grafo.getVertices().Count];//arreglo de visitados arranca por defecto con todos en falso
			Cola <Vertice<T>> c=new Cola<Vertice<T>>(); //cola de vertices
			Vertice<T> auxiliar; //vertice auxiliar
			int aristas=0;
			c.encolar(origen);//encolo origen
			c.encolar(null); //encolo separador
			visitados[origen.getPosicion()-1]=true;//se marca el origen como visitado
			while(!c.esVacia()){//mientras la cola no este vacia
				auxiliar=c.desencolar();//desencolo vertices
				if(auxiliar!=null){
					if(aristas==nroDeAristas){
						Console.Write(auxiliar.getDato()+ " "); //imprimo dato
					}
					foreach(var adyacente in auxiliar.getAdyacentes()){//recorro la lista de adyacentes del nodo
						if(visitados[adyacente.getDestino().getPosicion()-1]==false){//si el adyacente no fue visitado
							c.encolar(adyacente.getDestino());//encolo adyacente
							visitados[adyacente.getDestino().getPosicion()-1]=true;//lo marco como visitado
				}	
				}
			}
				else{
					aristas++;
					if(!c.esVacia()){
						c.encolar(null);
					}
				}
			}
			
		}
		
	}
}
