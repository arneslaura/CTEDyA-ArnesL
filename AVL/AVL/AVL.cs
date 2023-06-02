using System;
using System.Collections;
using System.Collections.Generic;

namespace AVL
{

	public class AVL{
		
		//atributos
		private IComparable dato;
		private AVL hijoIzquierdo;
		private AVL hijoDerecho;
		private int altura;
		
		//constructor
		public AVL(IComparable dato){
			this.dato = dato;
		}
		
		//propiedades
		public IComparable getDatoRaiz(){
			return this.dato;
		}
		
		public AVL getHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public AVL getHijoDerecho(){
			return this.hijoDerecho;
		}
		
		//metodos
		public void agregarHijoIzquierdo(AVL hijo){
			this.hijoIzquierdo=hijo;
		}

		public void agregarHijoDerecho(AVL hijo){
			this.hijoDerecho=hijo;
		}
		
		public void eliminarHijoIzquierdo(){
			this.hijoIzquierdo=null;
		}
		
		public void eliminarHijoDerecho(){
			this.hijoDerecho=null;
		}
		
		public AVL agregar(IComparable elem) {
			if(elem.CompareTo(this.getDatoRaiz()) >0){//si el elemento es mayor a la raiz voy hacia la derecha
				if(this.getHijoDerecho()==null){ //si esta vacio se agrega como hijo derecho
					this.agregarHijoDerecho(new AVL(elem));
				}
				else{
					this.agregarHijoDerecho(this.getHijoDerecho().agregar(elem));
					}
			}
			else{//si el elemeno es menor o igual a lo que hay en la raiz voy hacia la izquierda
				if(this.getHijoIzquierdo()==null){
					this.agregarHijoIzquierdo(new AVL(elem)); //si esta vacio se agrega como hijo izquierdo
				}
				else{
					this.agregarHijoIzquierdo(this.getHijoIzquierdo().agregar(elem));
					}
			}
			this.actualizarAltura(); //se actualiza la altura del nodo despues de la insercion
			AVL nuevaRaiz=this; //auxiliar avl de nueva raiz empieza en this, si nop hay rotacion queda en this
			int balance=this.calcularDesbalance();//calcula si el arbol quedo desbalanceado
			if(balance>1){//si esta desbalanceado del lado derecho
				if(elem.CompareTo(this.getHijoDerecho().getDatoRaiz()) >0){ //el elem es mayor al hijo derecho caso rotacion simple derecha
					nuevaRaiz= this.rotacionSimpleDerecha(); //cambio de raiz
				   }
				else{//el elem es menor o igual al hijo izquierdo caso rotacion doble derecha
					nuevaRaiz=this.rotacionDobleDerecha();
				}
			}
			if(balance<-1){//si esta desbalanceado del lado izquierdo
				if(elem.CompareTo(this.getHijoIzquierdo().getDatoRaiz()) <=0){ //el elem es menor o igual al hijo izquierdo caso rotacion simple izquierda
					nuevaRaiz= this.rotacionSimpleIzquierda(); //cambio de raiz
				   }
				else{//el elem es mayor al hijo derecho caso rotacion doble izquierda
					nuevaRaiz=this.rotacionDobleIzquierda(); //cambio de raiz
				}
			}
			return nuevaRaiz;
		}
		
		private int calcularDesbalance(){
			int alturahizq=-1, alturahder=-1;//inicializan por defecto con -1(como si no tuvieran hijos)
			if(this.getHijoIzquierdo()!=null){ //si tiene hijo izquierdo se actuliza la altura
				alturahizq=this.getHijoIzquierdo().altura;
			}
			if(this.getHijoDerecho()!=null){ //si tiene hijo derecho se actuliza la altura
				alturahder=this.getHijoDerecho().altura;
			}
			return alturahder - alturahizq; //si es mas de 2 negativo o positivo esta desbalanceado
		}
		
		private void actualizarAltura(){
			int alturahizq=-1, alturahder=-1;//inicializan por defecto con -1(como si no tuvieran hijos)
			if(this.getHijoIzquierdo()!=null){ //si tiene hijo izquierdo se actuliza la altura
				alturahizq=this.getHijoIzquierdo().altura;
			}
			if(this.getHijoDerecho()!=null){ //si tiene hijo derecho se actuliza la altura
				alturahder=this.getHijoDerecho().altura;
			}
			if(alturahder>alturahizq){ //si el hijo derecho es el mas alto la altura se actualiza a la de este + 1
				this.altura=alturahder+1;
			}
			else{
				this.altura=alturahizq+1; //si el hijo izquierdo es el mas alto o sin iguales la altura se actualiza a la de este + 1
			}
		}
		
		
		public AVL rotacionSimpleDerecha() { //con derecho
			AVL nuevaRaiz=this.getHijoDerecho();//auxiliar nueva raiz despues de rotacion
			this.agregarHijoDerecho(nuevaRaiz.getHijoIzquierdo());//cambio de hijo derecho a la raiz actual
			nuevaRaiz.agregarHijoIzquierdo(this);//recupero auxiliar le pongo hijo izquierdo a la nueva raiz
			this.actualizarAltura(); //se actualiza la altura de los nodos que cambiaron
			nuevaRaiz.actualizarAltura();
			return nuevaRaiz; //retorna nueva raiz para poder hacer el cambio
		}
		
		public AVL rotacionSimpleIzquierda() {//con izquierdo
			AVL nuevaRaiz=this.getHijoIzquierdo();//auxiliar nueva raiz despues de rotacion
			this.agregarHijoIzquierdo(nuevaRaiz.getHijoDerecho());//cambio de hijo izquiero a la raiz actual
			nuevaRaiz.agregarHijoDerecho(this);//recupero auxiliar le pongo hijo derecho a la nueva raiz
			this.actualizarAltura(); //se actualiza la altura de los nodos que cambiaron
			nuevaRaiz.actualizarAltura();
			return nuevaRaiz; //retorna nueva raiz para poder hacer el cambio
		}
		
		public AVL rotacionDobleDerecha() { //con derecho
			AVL nuevoHijoDer=this.getHijoDerecho().rotacionSimpleIzquierda();//nuevo hijo derecho obtenido con la primer rotacion
			this.agregarHijoDerecho(nuevoHijoDer); //se le otorga el nuevo hijo desp de la primer rotacion
			return this.rotacionSimpleDerecha(); //nueva raiz con la segunda rotacion
		}
		
		public AVL rotacionDobleIzquierda() { //con izquierdo
			AVL nuevoHijoIzq=this.getHijoIzquierdo().rotacionSimpleDerecha();//nuevo hijo derecho obtenido con la primer rotacion
			this.agregarHijoIzquierdo(nuevoHijoIzq); //se le otorga el nuevo hijo desp de la primer rotacion
			return this.rotacionSimpleIzquierda(); //nueva raiz con la segunda rotacion
		}
				
		
		public bool incluye(IComparable elem) {
			if(elem.CompareTo(this.getDatoRaiz())==0){ //caso base
				return true;
			}
			else{
				if(elem.CompareTo(this.getDatoRaiz())>0){//si el elemento es mayor a la raiz lo busca en el subarbol derecho
					if(this.getHijoDerecho()!=null){
						if(this.getHijoDerecho().incluye(elem)){ //caso recursivo
							return true;
						}
					}
				}
				else{
					if(this.getHijoIzquierdo()!=null){//si el elemento es menor a la raiz lo busca en el subarbol derecho
							if(this.getHijoIzquierdo().incluye(elem)){ //caso recursivo
								return true;
						}
					}
				}
			}
			return false;
		}


		public void preorden() {
			Console.Write(this.dato+" "); //raiz
			if(this.hijoIzquierdo!=null){
				this.hijoIzquierdo.preorden();//hijo izq si tiene
			}
			if(this.hijoDerecho!=null){ //hijo derecho si tiene
				this.hijoDerecho.preorden();
			}
		}
		
		public void inorden() {
			if(this.hijoIzquierdo!=null){
				this.hijoIzquierdo.inorden();//hijo izq si tiene
			}
			Console.Write(this.dato+" "); //raiz
			if(this.hijoDerecho!=null){ //hijo derecho si tiene
				this.hijoDerecho.inorden();
			}
		}
		
		public void postorden() {
			if(this.hijoIzquierdo!=null){
				this.hijoIzquierdo.postorden();//hijo izq si tiene
			}
			if(this.hijoDerecho!=null){ //hijo derecho si tiene
				this.hijoDerecho.postorden();
			}
			Console.Write(this.dato+" "); //raiz
		}
		
		public void recorridoPorNiveles() {
			Cola<AVL> C=new Cola<AVL>(); //cola de arboles binarios
			AVL arbaux; //arbol auxiliar
			C.encolar(this); //encolo arbol raiz
			while(!C.esVacia()){ //,iemtras la cola no este vacia
				arbaux=C.desencolar(); //desencolo en el auxiliar
				Console.Write(arbaux.dato+" "); //escrino el dato
				if(arbaux.hijoIzquierdo!=null){ 
					C.encolar(arbaux.hijoIzquierdo); //si tiene hijo izquierdo lo encola
				}
				if(arbaux.hijoDerecho!=null){
					C.encolar(arbaux.hijoDerecho); //si tiene hijo derecho lo encola
				}
			}
		}
		
		
	}
}