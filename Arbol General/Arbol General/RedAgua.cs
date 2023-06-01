
using System;
using System.Collections;

namespace Arbol_General
{
	/// <summary>
	/// Description of RedAgua.
	/// </summary>
	public class RedAgua //nueva clase no generica 
	{
		//propiedades
		ArbolGeneral <int> red; //arbol que va a llegar por parametro no se instancia
		
		//constructor
		public RedAgua(ArbolGeneral<int> arbol) //se pasa un arbol ya hecho para modelizar
		{
			this.red=arbol;
		}
		
		//metodo
		public int minCaudal(int caudal){ //se pasa el caudal por parametro
			Cola<ArbolGeneral<int>> c=new Cola<ArbolGeneral<int>>(); //cola de arboles generales
			ArbolGeneral<int> arbAux; //arbol auxiliar
			int mincau=caudal; //donde se calcula el min caudal
			red.setDatoRaiz(caudal); //la raiz del arbol pasa a ser el caudal
			c.encolar(red); //se encola el arbol
			while(! c.esVacia()){ //mientras no este vacia la cola
				arbAux= c.desencolar(); //desencolo 
				if(!arbAux.esHoja()){ //si no es hoja, sino divide por cero error
					int caudalHijos=arbAux.getDatoRaiz()/arbAux.getHijos().Count; //voy calculando el valor de cada caudal
					if(caudalHijos<mincau){
						mincau=caudalHijos; //si el caudal de un hijo pasa a ser menor que un caudal minimo lpo reemplaza
					}
					foreach(var hijo in arbAux.getHijos()){//recorro los hijos del arbol auxiliar
						hijo.setDatoRaiz(caudalHijos);
						c.encolar(hijo);
					}
				}
			}
			return mincau;
		}
	}
}
