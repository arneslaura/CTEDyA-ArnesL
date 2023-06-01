
using System;
using System.Collections;
using System.Collections.Generic;

namespace Arbol_General
{
	/// <summary>
	/// Description of Arbol_General.
	/// </summary>
	public class ArbolGeneral <T> //clase de tipo generica
	{
		private T dato; //dato generico (acepta cualquier tipo)
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>(); //lista generica de hijos creacion e inicializacion
		
		//constructor
		public ArbolGeneral(T dato)
		{
			this.dato=dato; //constructor con dato
		}
		
		//propiedades (get de ambos atributos
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public List<ArbolGeneral<T>> getHijos() {
			return hijos;
		}
		
		public void setDatoRaiz(T dat){
			this.dato=dat;
		}
		
		//metodos
		public void agregarHijo(ArbolGeneral<T> hijo) { //agregar hijo a un nodo
			this.getHijos().Add(hijo);
		}
	
		public void eliminarHijo(ArbolGeneral<T> hijo) { //eliminar hijo de un nodo
			this.getHijos().Remove(hijo);
		}
		
		public bool esHoja() { //saber si un nodo es hoja (no tiene hijos)
			return this.getHijos().Count == 0;
		}
		
		public void preorden(){ //primero raiz luego hijos
			Console.Write(this.dato + " "); //imprime raiz
			foreach(var hijo in this.hijos){ //imprime hijos de forma recursiva
				hijo.preorden();
			}
		}
		
		public void inorden(){ //primero hijo izq, luego raiz, luego demas hijos
			if(this.hijos.Count !=0){ //si la lista de hijos no esta vacia
				this.hijos[0].inorden(); //imprime hijo izq de forma recusiva
			}
			Console.Write(this.dato + " "); //imprime raiz
			for(int i=1; i<this.hijos.Count; i++){ //recorrido por los demas hijos
				this.hijos[i].inorden(); //imprime resto de los hijos de forma recursiva
			}
		}
		
		public void postorden(){ //primero hijos luego raiz
			foreach(var hijo in this.hijos){ //imprime hijos de forma recursiva
				hijo.postorden();
			}
			Console.Write(this.dato + " "); //imprime raiz	
		}
		
		public void porNiveles(){ //de arriba a abajo izq a der
			Cola <ArbolGeneral<T>> c= new Cola<ArbolGeneral<T>>(); //creo e instancio cola de arbol generales
			ArbolGeneral <T> aux; //creo un arbol general auxiliar
			c.encolar(this); //encolo al arbol al que llame el metodo
			while(!c.esVacia()){ //mientras la cola no este vacia
				aux=c.desencolar(); //el arbol desencolado pasa al arbo auxiliar
				Console.Write(aux.dato + " ");  //imprimo el dato que este en el arbol aux
				foreach(var hijo in aux.hijos){ //para cada hijo del arbol aux
					c.encolar(hijo); //encolo	
				        }
			}
		}
		
		public int altura(){ //metodo para sabes la altura del arbol
			int alturamax=0; //comienza en altura 0
			if(this.esHoja()){
				return 0; //si es hoja la altura es 0
			}
			else{
				foreach(var hijo in hijos){ //si no es hoja analiza la altura de cada hijo
					if(hijo.altura()>alturamax){ //si la altura de un hijo es mayor a la altura maxima
						alturamax=hijo.altura();//la altura del hijo pasa a ser la altura maxima
					}
				}
				return alturamax+1;//a la altura maxima del hijo se le suma 1
			}
		}
		
		public int nivel (T elem){
			int nivel=0; //cuenta la cantidad de nodos por nivel
			Cola <ArbolGeneral<T>> c= new Cola<ArbolGeneral<T>>(); //creo e instancio cola de arbol generales
			ArbolGeneral <T> aux; //creo un arbol general auxiliar
			c.encolar(this); //encolo al arbol al que llame el metodo
			c.encolar(null); //encolo separador
			while(!c.esVacia()){ //mientras la cola no este vacia
				aux=c.desencolar(); //el arbol desencolado pasa al arbo auxiliar
				if(aux==null){//si no desencole un separador
					nivel++;
					if(!c.esVacia()){ //si la cola no esta vacia encolo un separador
						c.encolar(null);
					}
				}
				else{
					if(aux.dato.Equals(elem)){
					   	return nivel;
					   }
					foreach(var hijo in aux.hijos){ //para cada hijo del arbol aux
					c.encolar(hijo); //encolo
					}
				}
			}
			return nivel;		
		}
		
		public int ancho(){
			int ancho=0; //se queda con cont nodos mayor
			int contnodos=0; //cuenta la cantidad de nodos por nivel
			Cola <ArbolGeneral<T>> c= new Cola<ArbolGeneral<T>>(); //creo e instancio cola de arbol generales
			ArbolGeneral <T> aux; //creo un arbol general auxiliar
			c.encolar(this); //encolo al arbol al que llame el metodo
			c.encolar(null); //encolo separador
			while(!c.esVacia()){ //mientras la cola no este vacia
				aux=c.desencolar(); //el arbol desencolado pasa al arbo auxiliar
				if(aux==null){ //si no desencole un separador
					if(contnodos>ancho){ //si el contador es mayor al ancho pasa a ser el ancho
						ancho=contnodos;
					}
					contnodos=0; //resetea el cont de nodos porque empieza un nuevo nivel
					if(!c.esVacia()){ //si la cola no esta vacia encolo un separador
						c.encolar(null);
					}
					}
				else{
					contnodos++; //voy contando los nodos
					foreach(var hijo in aux.hijos){ //para cada hijo del arbol aux
					c.encolar(hijo); //encolo
					}
				}
			}
			return ancho;
		}
		
		public int quadtree (int pixeles){
			int acu=0; // acumulara la cantidad de pixeles de la imagen
			int nivel=0; //cuenta la cantidad de nodos por nivel
			Cola <ArbolGeneral<T>> c= new Cola<ArbolGeneral<T>>(); //creo e instancio cola de arbol generales
			ArbolGeneral <T> aux; //creo un arbol general auxiliar
			c.encolar(this); //encolo al arbol al que llame el metodo
			c.encolar(null); //encolo separador
			while(!c.esVacia()){ //mientras la cola no este vacia
				aux=c.desencolar(); //el arbol desencolado pasa al arbo auxiliar
				if(aux==null){//si no desencole un separador
					nivel++;
					if(!c.esVacia()){ //si la cola no esta vacia encolo un separador
						c.encolar(null);
					}
				}
				else{
					if(aux.dato.Equals(0)){
						acu=acu+(pixeles/(int)Math.Pow(4, nivel));
					   }
					foreach(var hijo in aux.hijos){ //para cada hijo del arbol aux
					c.encolar(hijo); //encolo
					}
				}
			}
			return acu;		
		}
			
		
		
	}
}
