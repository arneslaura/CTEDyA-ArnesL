
using System;
using System.Collections;
using System.Collections.Generic;

namespace TPF
{

	public class Estrategia
	{
		//metodos
		private int CalcularDistancia(string str1, string str2) //calcula la distancia de Levenshtein entre dos strings
		{
			String[] strlist1 = str1.ToLower().Split(' ');
			String[] strlist2 = str2.ToLower().Split(' ');
			int distance = 1000;
			foreach (String s1 in strlist1)
			{
				foreach (String s2 in strlist2)
				{
					distance = Math.Min(distance, Utils.calculateLevenshteinDistance(s1, s2));
				}
			}

			return distance;
		}

		public String Consulta1(ArbolGeneral<DatoDistancia> arbol) //retorna todas las hojas del arbol
		{
            string hojas = ""; //donde agrupar las hojas
            Cola<ArbolGeneral<DatoDistancia>> c = new Cola<ArbolGeneral<DatoDistancia>>(); //creacion de la cola para recorrer el arbol general por nivles
            ArbolGeneral<DatoDistancia> arbaux; // creacion arbol auxiliar para usar de puntero
            c.encolar(arbol); //encolo el arbol
            if(arbol.esHoja()){ //si la raiz es hoja
            	hojas=arbol.getDatoRaiz().Texto; //agrga la raiz a las hojas
            }
            while (!c.esVacia()) //mientras la cola no este vacia
            {
            	arbaux = c.desencolar(); // desencolo en el arbol auxiliar
                foreach (var hijo in arbaux.getHijos()) //recorro la lista de hijos
                {
                	if (hijo.esHoja()) //si ese hijo es hoja
                	{
                		hojas += " " + hijo.getDatoRaiz().Texto; //se agrega a las hojas
                	}
                	c.encolar(hijo);//encola el hijo 
                }
            }
            return hojas; //retorna las hojas concatenadas en una oracion
		}
		

        public String Consulta2(ArbolGeneral<DatoDistancia> arbol)
        {
            string resultado = ""; //donde ir agregando los caminos
            ArrayList caminos = new ArrayList(); //creacion de arraylist donde se guardaran los caminos
            ArrayList nodos = new ArrayList(); //creacion de arraylist donde se guardaran los nodos de un camino
            _Consulta2(arbol, caminos, nodos); //llamado al metodo interno que buscara los caminos
            foreach (ArrayList a in caminos) //recorre la lista de caminos
            {
                resultado+= "C: [ ";
                foreach (string s in a)//recorre cada camino
                {

                    resultado+= s + " - ";//agrega cada nodo del camino
                }
                resultado+= "] ";
            }
            return resultado; //retorna el resultado
        }
        
        private void _Consulta2 (ArbolGeneral<DatoDistancia> arbol, ArrayList caminos, ArrayList nodos)
        {
        	ArrayList aux = new ArrayList(); //crea arraylist auxiliar
            if (arbol.esHoja())//si es hoja
            {
                nodos.Add(arbol.getDatoRaiz().Texto);//agrega al camino
                foreach (string ele in nodos)//recorre el camino
                {
                    aux.Add(ele);//crea un camino
                }
                caminos.Add(aux);//agrega el camino a la lista de caminos
            }
            else //si no es hoja
            {
                nodos.Add(arbol.getDatoRaiz().Texto);//agrega al camino
                foreach (ArbolGeneral<DatoDistancia> hijo in arbol.getHijos())//recorre los hijos
                {
                    _Consulta2(hijo, caminos, nodos);//llamada recursiva
                    nodos.RemoveAt(nodos.Count - 1);//elimina al nodo
                }
            }
        }
		

		public String Consulta3(ArbolGeneral<DatoDistancia> arbol) //retorna todos los datos diferenciados por nivel 
		{
			string resultado = "";//donde se van sumando los datos
			int nivel=0; //contador de nivel
			Cola<ArbolGeneral<DatoDistancia>> c = new Cola<ArbolGeneral<DatoDistancia>>();  //creacion de cola de arboles generales
			ArbolGeneral<DatoDistancia> arbaux; //creacion de arbol auxiliar
			c.encolar(arbol);//encolo arbol
			c.encolar(null);//encolo separador
			resultado+= "Nivel " + nivel + ": "; //sumo al resultado
			while(!c.esVacia()){//mientras la cola no este vacia
				arbaux=c.desencolar(); //desencolo en el arbol auxiliar
				if(arbaux==null){//si no desencole un separador
					nivel++; //aumento el nivel
					if(!c.esVacia()){ //si la cola no esta vacia encolo un separador
						resultado+= "Nivel " + nivel + ": "; //sumo al resultado
						c.encolar(null);//encolo separador
					}
				}
				else{ //si no desencole un separador
					resultado+= arbaux.getDatoRaiz().ToString()+"  "; //sumo dato al resultado
					foreach( var hijo in arbaux.getHijos()){ //recorro lista de hijos
						c.encolar(hijo); //encolo los hijos
					}
				}
			}
			return resultado;
		}

		public void AgregarDato(ArbolGeneral<DatoDistancia> arbol, DatoDistancia dato) //agrega un dato al arbol BK
		{
			int dis= CalcularDistancia(arbol.getDatoRaiz().Texto, dato.Texto);//calculo la distancia entre la raiz del arbol y el dato
			DatoDistancia da= new DatoDistancia(dis, dato.Texto, dato.Descripcion); //creo nuevo dato distancia con la distancia modificada
			arbol.agregarHijo(new ArbolGeneral<DatoDistancia>(da)); //agrego el dato distancia como hijo
		}

		public void Buscar(ArbolGeneral<DatoDistancia> arbol, string elementoABuscar) //busca una string en el arbol con cierto grado de tolerancia
		{
			bool esta=false;
			Cola<ArbolGeneral<DatoDistancia>> c = new Cola<ArbolGeneral<DatoDistancia>>();  //creacion de cola de arboles generales
			ArbolGeneral<DatoDistancia> arbaux; //creacion de arbol auxiliar
			c.encolar(arbol);//encolo arbol
			while(!c.esVacia()){//mientras la cola no este vacia
				arbaux=c.desencolar(); //desencolo en el arbol auxiliar
				if(arbaux.getDatoRaiz().Texto==elementoABuscar){//si no desencole un separador
					esta=true;
				}
				else{
					foreach( var hijo in arbaux.getHijos()){ //recorro lista de hijos
						c.encolar(hijo); //encolo los hijos
					}
				}
			}
			if(esta){
				Console.WriteLine(elementoABuscar + " esta en el arbol");
			}
			else{
				Console.WriteLine(elementoABuscar + " no esta en el arbol");
			}
        }
		
    }
}