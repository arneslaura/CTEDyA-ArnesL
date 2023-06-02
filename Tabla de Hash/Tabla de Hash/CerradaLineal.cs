
using System;

namespace Tabla_de_Hash
{
	/// <summary>
	/// Description of CerradaLineal.
	/// </summary>
	public class CerradaLineal
	{
		//atributos
		int [] arr;
		
		//constructor
		public CerradaLineal()
		{
			arr=new int[11]{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}; //-1 significa celda vacia
		}
		
		//metodos
		private int gethash(int n){
			return n%11;
		}
		
		public void agregar(int n){
			bool hecho=false; //se vuelve true cuando el elemento fue agregado
			int hash=gethash(n);
			while(hecho==false){
				if(arr[hash]==-1){//si la celda esta vacia
					arr[hash]=n;
					hecho=true;
				}
				else{
					hash=(hash+1)%11;
				}
			}
		}
		
		public void imprimir(){
			foreach(int b in arr){
				Console.Write("[ ");
				if(b!=-1){
					Console.Write(b + " ");
				}
				Console.Write("]");
			}
		}
		
	}
}
