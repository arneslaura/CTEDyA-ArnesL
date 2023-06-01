using System;
using System.Collections;
using System.Collections.Generic;

namespace ABB
{

	public class ArbolBinarioBusqueda{
		
		private IComparable dato;
		private ArbolBinarioBusqueda hijoIzquierdo;
		private ArbolBinarioBusqueda hijoDerecho;
		
		
		public ArbolBinarioBusqueda(IComparable dato){
			this.dato = dato;
		}
		
		
		public IComparable getDatoRaiz(){
			return this.dato;
		}
		
		public ArbolBinarioBusqueda getHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public ArbolBinarioBusqueda getHijoDerecho(){
			return this.hijoDerecho;
		}
		
		public void agregarHijoIzquierdo(ArbolBinarioBusqueda hijo){
			this.hijoIzquierdo=hijo;
		}

		public void agregarHijoDerecho(ArbolBinarioBusqueda hijo){
			this.hijoDerecho=hijo;
		}
		
		public void eliminarHijoIzquierdo(){
			this.hijoIzquierdo=null;
		}
		
		public void eliminarHijoDerecho(){
			this.hijoDerecho=null;
		}
		
		public void agregar(IComparable elem) {
			if(getDatoRaiz()==null){ //caso base si la raiz esta vacia el dato va ahi
				this.dato=elem;
			}
			else{
				if(elem.CompareTo(this.getDatoRaiz())>0){//si el elemento es mayor a la raiz
					if(getHijoDerecho()==null){
						this.agregarHijoDerecho(new ArbolBinarioBusqueda(elem));//si no tiene hijo derecho se inserta en esa posicion
					}
					else{
						this.getHijoDerecho().agregar(elem);//llamada recursiva a seguir buscando una posicion donde insertar
					}
				}
				else{
					if(getHijoIzquierdo()==null){
						this.agregarHijoIzquierdo(new ArbolBinarioBusqueda(elem));//si no tiene hijo izquierdo se inserta en esa posicion
					}
					else{
						this.getHijoIzquierdo().agregar(elem);//llamada recursiva a seguir buscando una posicion donde insertar
					}
				}
			}
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
			Cola<ArbolBinarioBusqueda> C=new Cola<ArbolBinarioBusqueda>(); //cola de arboles binarios
			ArbolBinarioBusqueda arbaux; //arbol auxiliar
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