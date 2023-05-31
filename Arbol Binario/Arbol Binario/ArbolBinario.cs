using System;
using System.Collections;
using System.Collections.Generic;

namespace Arbol_Binario
{
	public class ArbolBinario<T> //clase del tipo generica
	{
		//atributos
		private T dato; //raiz
		private ArbolBinario<T> hijoIzquierdo;
		private ArbolBinario<T> hijoDerecho;
	
		//constructor
		public ArbolBinario(T dato) {
			this.dato = dato;
		}
		
		//propiedades
		public T getDatoRaiz() { //get de los 3 atributos
			return this.dato;
		}
	
		public ArbolBinario<T> getHijoIzquierdo() {
			return this.hijoIzquierdo;
		}
	
		public ArbolBinario<T> getHijoDerecho() {
			return this.hijoDerecho;
		}
		
		//metodos
		public void agregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.hijoIzquierdo=hijo;
		}
	
		public void agregarHijoDerecho(ArbolBinario<T> hijo) {
			this.hijoDerecho=hijo;
		}
	
		public void eliminarHijoIzquierdo() {
			this.hijoIzquierdo=null;
		}
	
		public void eliminarHijoDerecho() {
			this.hijoDerecho=null;
		}
	
		public bool esHoja() {
			return this.hijoIzquierdo==null && this.hijoDerecho==null;
		}
		
		public void inorden() {//hijo izq - raiz - hijo der
			if(this.hijoIzquierdo!=null){
				this.hijoIzquierdo.inorden();//hijo izq si tiene
			}
			Console.Write(this.dato+" "); //raiz
			if(this.hijoDerecho!=null){ //hijo derecho si tiene
				this.hijoDerecho.inorden();
			}
		}
		
		public void preorden() { //raiz-hijo izq - hijo der
			Console.Write(this.dato+" "); //raiz
			if(this.hijoIzquierdo!=null){
				this.hijoIzquierdo.preorden();//hijo izq si tiene
			}
			if(this.hijoDerecho!=null){ //hijo derecho si tiene
				this.hijoDerecho.preorden();
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
			Cola<ArbolBinario<T>> C=new Cola<ArbolBinario<T>>(); //cola de arboles binarios
			ArbolBinario <T> arbaux; //arbol auxiliar
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
		
		public bool incluye(T elem){ //con recorrido por niveles
			Cola<ArbolBinario<T>> C=new Cola<ArbolBinario<T>>(); //cola de arboles binarios
			ArbolBinario <T> arbaux; //arbol auxiliar
			C.encolar(this); //encolo arbol raiz
			while(!C.esVacia()){ //mientras la cola no este vacia
				arbaux=C.desencolar(); //desencolo en el auxiliar
				if(arbaux.dato.Equals(elem)){ //si el dato del arb aux e igual al elemento pasado por parametro retorna true
				return true;
			   }
				if(arbaux.hijoIzquierdo!=null){ 
					C.encolar(arbaux.hijoIzquierdo); //si tiene hijo izquierdo lo encola
				}
				if(arbaux.hijoDerecho!=null){
					C.encolar(arbaux.hijoDerecho); //si tiene hijo derecho lo encola
				}
			}
			return false; //si termino todo el recorrido y no lo encontro retorna falso
		}
		
		public bool incluye2 (T elem){//con recursividad forma 1
			if(this.dato.Equals(elem)){//caso base si dato=raiz true
				return true;
			   }
			if(this.hijoIzquierdo!=null){//hijo izq si tiene
				if(this.hijoIzquierdo.incluye2(elem)){//caso recursivo
					return true;
				}
			}
			if(this.hijoDerecho!=null){ //hijo derecho si tiene
				if(this.hijoDerecho.incluye2(elem)){//caso recursivo
					return true;
				}
			}
			return false;//si paso por todo el arbol y no lo encontrp
		}
		
		public bool incluye3 (T elem){//con recursividad forma 2
			bool est1=false, est2=false;//declaracion variables falsas
			if(this.dato.Equals(elem)){//caso base
				return true;
			   }
			else{
				if(this.hijoIzquierdo!=null){
					est1=this.hijoIzquierdo.incluye3(elem);//llamada recursiva si tiene hijo izq
				}
				if(this.hijoDerecho!=null){
					est2=this.hijoDerecho.incluye3(elem);//llamada recursiva si tiene hijo der
				}
				return est1 || est2;//si alguno de los 2 es true = true, sino false
			}
		}
		
	
		public int contarHojas() { //metodo contar hojas con recorrido por niveles
			Cola<ArbolBinario<T>> C=new Cola<ArbolBinario<T>>(); //cola de arboles binarios
			ArbolBinario <T> arbaux; //arbol auxiliar
			int contador=0; //va contando las hojas
			C.encolar(this); //encolo arbol raiz
			while(!C.esVacia()){ //,iemtras la cola no este vacia
				arbaux=C.desencolar(); //desencolo en el auxiliar
				if(arbaux.hijoIzquierdo==null && arbaux.hijoDerecho==null){ //si el arb aux no tiene hijos
				contador++;//se suman hojas al contador
			   }
				if(arbaux.hijoIzquierdo!=null){ 
					C.encolar(arbaux.hijoIzquierdo); //si tiene hijo izquierdo lo encola
				}
				if(arbaux.hijoDerecho!=null){
					C.encolar(arbaux.hijoDerecho); //si tiene hijo derecho lo encola
				}
			}
			return contador;
		}
		
		public int contarHojas2 (){//metodo contar hojas con recursividad
			int conta=0;//contador inicia en 0
			if(hijoIzquierdo==null && hijoDerecho==null){
				conta++;//si es hoja suma el contador
			}
			if(this.hijoIzquierdo!=null){//hijo izq si tiene
				conta=conta+this.hijoIzquierdo.contarHojas2();//llamada recursiva contador+funcion
			}
			if(this.hijoDerecho!=null){ //hijo derecho si tiene
				conta=conta+this.hijoDerecho.contarHojas2();//llamada recursiva contador+funcion
			}
			return conta;//retorna cantidad de hojas
		}

		
		public void recorridoEntreNiveles(int n,int m) {
			Cola<ArbolBinario<T>> C=new Cola<ArbolBinario<T>>(); //cola de arboles binarios
			ArbolBinario <T> arbaux; //arbol auxiliar
			int nivel=0; //contador de nivel
			C.encolar(this); //encolo arbol raiz
			C.encolar(null); //encolo separador
			while(!C.esVacia()){ //mientras la cola este vacia
				arbaux=C.desencolar();
				if(arbaux!=null){ //si lo que desencole no es null
					if(nivel>=n && nivel<=m){ //si estoy entre los niveles pedidos
						Console.Write(arbaux.dato+" "); //imprime dato
					}
					if(arbaux.hijoIzquierdo!=null){ 
						C.encolar(arbaux.hijoIzquierdo); //si tiene hijo izquierdo lo encola
					}
					if(arbaux.hijoDerecho!=null){
						C.encolar(arbaux.hijoDerecho); //si tiene hijo derecho lo encola
				}
				}
				else{
					nivel++; //si desencolo un null suma el nivel y desencola otro null
					if(!C.esVacia()){
						C.encolar(null);
					}
				}
			}
		}
		

	}
}
