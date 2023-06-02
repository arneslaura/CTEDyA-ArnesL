
using System;

namespace Tabla_de_Hash
{
	/// <summary>
	/// Description of CerradaCuadratica.
	/// </summary>
	public class CerradaCuadratica
	{
		//atributos
		int [] arr;
		
		//constructor
		public CerradaCuadratica()
		{
			arr=new int[11]{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}; //-1 significa celda vacia
		}
		
		//metodos
		private int gethash(int n){
			return n%11;
		}
		
		public void agregar(int n){
			bool hecho=false; //se vuelve true cuando el elemento fue agregado
			int hash=gethash(n),colisiones=0;
			while(hecho==false){
				if(arr[hash]==-1){//si la celda esta vacia
					arr[hash]=n;
					hecho=true;
				}
				else{
					colisiones++;
					hash=(hash + (int)Math.Pow(colisiones,2))%11;
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
