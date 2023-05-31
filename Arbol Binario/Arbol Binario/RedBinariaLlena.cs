
using System;
using System.Collections;
using System.Collections.Generic;

namespace Arbol_Binario
{
	/// <summary>
	/// Description of RedBinariaLlena.
	/// </summary>
	public class RedBinariaLlena <T>
	{
		//atributos mismos que un arbol binario
		private int dato; //raiz
		private RedBinariaLlena<int> hijoIzquierdo;
		private RedBinariaLlena<int> hijoDerecho;
	
		//constructor
		public RedBinariaLlena(int dato) {
			this.dato = dato;
		}
		
		//propiedades
		public int getDatRaiz() { //get de los 3 atributos
			return this.dato;
		}
	
		public RedBinariaLlena<int> getHijoIzq() {
			return this.hijoIzquierdo;
		}
	
		public RedBinariaLlena<int> getHijoDer() {
			return this.hijoDerecho;
		}
		
		//metodos
		public void agregarHijoIzq(RedBinariaLlena<int> hijo) {
			this.hijoIzquierdo=hijo;
		}
	
		public void agregarHijoDer(RedBinariaLlena<int> hijo) {
			this.hijoDerecho=hijo;
		}
		
		public int retardoReenvio(){
			int retardoMaximo=0; //calcula el retardo maximo comienza en 0
			if(this.hijoIzquierdo!=null){ 
				if(this.hijoIzquierdo.retardoReenvio()>retardoMaximo){ //si tiene hijo izq hace recursion
					retardoMaximo=this.hijoIzquierdo.retardoReenvio(); //si el retardo es mayor al retardo actual lo remplaza
				}
			}
			if(this.hijoDerecho!=null){
				if(this.hijoDerecho.retardoReenvio()>retardoMaximo){ //si tiene hijo der hace recursion
					retardoMaximo=this.hijoDerecho.retardoReenvio();//si el retardo es mayor al retardo actual lo remplaza
				}
			}
			return retardoMaximo+this.dato; //devuelve el retardo mayor de los hijos + el de la raiz
		}
		

	}
}
