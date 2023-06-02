
using System;
using System.Collections;

namespace Tabla_de_Hash
{
	/// <summary>
	/// Description of Clave.
	/// </summary>
	public class Clave
	{
		//atributos
		ArrayList [] arr=new ArrayList[23]; //lista que va a contener las arraylist
		
		//constructor
		public Clave()
		{
			for (int i=0; i<23; i ++){
				this.arr[i]=new ArrayList();
			}
		}
		
		//propiedades
		private long getHashEntry(string user, string passwd){
			long hash = 5381;
			foreach (char c in user){
				hash = (hash * 7) + (int) c;
			}
			foreach (char c in passwd){
				hash = (hash * 7) + (int) c;
			}
			return hash % 23;
		}
		
		//metodos
		public void guardarClave(string n, string p){
			long h=getHashEntry(n,p);
			arr[h].Add(n);
		}
		
		public bool verificarClave(string u, string p){
			long ha=getHashEntry(u,p);
			if(arr[ha].Contains(u)){
				return true;
			}
			return false;
		}
	}
}
