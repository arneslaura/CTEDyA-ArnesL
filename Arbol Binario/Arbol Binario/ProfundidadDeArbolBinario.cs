
using System;
using System.Collections;
using System.Collections.Generic;

namespace Arbol_Binario
{
	/// <summary>
	/// Description of ProfundidadDeArbolBinario.
	/// </summary>
	public class ProfundidadDeArbolBinario
	{
		//atributos
		ArbolBinario <int> ab; //arbol que va a llegar por parametro no se instancia
		
		//constructor
		public ProfundidadDeArbolBinario(ArbolBinario <int> arbolb)
		{
			this.ab=arbolb;
		}
		
		//metodo
		
		public int sumaElementosProfundidad(int n) {
			Cola<ArbolBinario<int>> C=new Cola<ArbolBinario<int>>(); //cola de arboles binarios
			ArbolBinario <int> arbaux; //arbol auxiliar
			int nivel=0; //contador de nivel
			int sumador=0; //suma el dato de los nodos que esten en el nivel pasado por parametro
			C.encolar(ab); //encolo arbol raiz
			C.encolar(null); //encolo separador
			while(!C.esVacia()){ //mientras la cola este vacia
				arbaux=C.desencolar();
				if(arbaux!=null){ //si lo que desencole no es null
					if(nivel==n){ //si estoy entre los niveles pedidos
						sumador=sumador+arbaux.getDatoRaiz(); //imprime dato
					}
					if(nivel>n){
						break; //si ya paso por el nivel pedido
					}
					if(arbaux.getHijoIzquierdo()!=null){
						C.encolar(arbaux.getHijoIzquierdo()); //si tiene hijo izquierdo lo encola
					}
					if(arbaux.getHijoDerecho()!=null){
						C.encolar(arbaux.getHijoDerecho()); //si tiene hijo derecho lo encola
				}
				}
				else{
					nivel++; //si desencolo un null suma el nivel y desencola otro null
					if(!C.esVacia()){
						C.encolar(null);
					}
				}
			}
			return sumador;
		}
	}
}
