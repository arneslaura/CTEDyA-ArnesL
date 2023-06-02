
using System;
using System.Collections;
using System.Collections.Generic;

namespace Tabla_de_Hash
{
	/// <summary>
	/// Description of DispersionAbierta.
	/// </summary>
	public class DispersionAbierta
	{
		//atributos
		ArrayList [] arr; //lista que va a contener las arraylist
		int tamaño;
		
		//constructor
		public DispersionAbierta(int tam)
		{
			this.tamaño=tam;
			arr=new ArrayList[tam];
			for (int i=0; i<tamaño; i ++){
				this.arr[i]=new ArrayList();
			}
		}
		
		//propiedades
		private int getHash (int n){
			return n%tamaño;
		}
		
		//metodos
		public void agregar(int numero){
			int hash= getHash(numero);
			arr[hash].Add(numero);
		}
		
		public void imprimir(){ //imprime los elems que haya en la lista
			int m=0;
			foreach (ArrayList a in arr){
				Console.Write("[ ");
				m++;
				foreach (int p in a){
					Console.Write(p+" ");
				}
				Console.Write("]");
			}
		}
	}
}
