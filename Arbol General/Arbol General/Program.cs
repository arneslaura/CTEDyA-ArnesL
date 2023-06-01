
using System;
using System.Collections;
using System.Collections.Generic;

namespace Arbol_General
{
	class Program
	{
		public static void Main(string[] args)
		{
			//creacion de arbol general de enteros
			ArbolGeneral <int> arb1 = new ArbolGeneral<int> (1);
			ArbolGeneral <int> arb2 = new ArbolGeneral<int> (2);
			ArbolGeneral <int> arb3 = new ArbolGeneral<int> (4);
			arb1.agregarHijo(arb2);
			arb1.agregarHijo(new ArbolGeneral<int> (3));
			arb1.agregarHijo(arb3);
			ArbolGeneral <int> arb5 = new ArbolGeneral<int> (5);
			arb2.agregarHijo(arb5);
			arb5.agregarHijo(new ArbolGeneral<int> (9));
			arb2.agregarHijo(new ArbolGeneral<int> (6));
			arb3.agregarHijo(new ArbolGeneral<int> (7));
			arb3.agregarHijo(new ArbolGeneral<int> (8));
			
			//creacion arbol para quadtree
			ArbolGeneral <int> a1 = new ArbolGeneral<int> (2); //si dato=2 gris
			ArbolGeneral <int> a2 = new ArbolGeneral<int> (2);
			ArbolGeneral <int> a3 = new ArbolGeneral<int> (2);
			a1.agregarHijo(a2);
			a1.agregarHijo(a3);
			a1.agregarHijo(new ArbolGeneral<int> (0)); //si dato=0 negro
			a1.agregarHijo(new ArbolGeneral<int> (1)); //si dato=1 blanco
			a2.agregarHijo(new ArbolGeneral<int> (1));
			a2.agregarHijo(new ArbolGeneral<int> (1));
			a2.agregarHijo(new ArbolGeneral<int> (1));
			a2.agregarHijo(new ArbolGeneral<int> (0));
			a3.agregarHijo(new ArbolGeneral<int> (0));
			a3.agregarHijo(new ArbolGeneral<int> (0));
			a3.agregarHijo(new ArbolGeneral<int> (1));
			a3.agregarHijo(new ArbolGeneral<int> (1));
			
			
			//llamado a recorridos
			Console.WriteLine("Recorrido Preorden");
			arb1.preorden();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Recorrido Inorden");
			arb1.inorden();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Recorrido Postorden");
			arb1.postorden();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Recorrido por niveles");
			arb1.porNiveles();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("************************************************************");
			
			//altura
			Console.WriteLine( "Altura del arbol: "+ arb1.altura());
			Console.WriteLine("");
			
			//nivel
			Console.WriteLine ("1 se encuentra en el nivel: " + arb1.nivel(1));
			Console.WriteLine ("3 se encuentra en el nivel: " + arb1.nivel(3));
			Console.WriteLine ("8 se encuentra en el nivel: " + arb1.nivel(8));
			Console.WriteLine ("9 se encuentra en el nivel: " + arb1.nivel(9));
			Console.WriteLine("");
			
			//ancho
			Console.WriteLine( "Ancho del arbol: "+ arb1.ancho());
			Console.WriteLine("");
			Console.WriteLine("************************************************************");
			
			//minimo caudal
			RedAgua red1=new RedAgua(arb1);
			Console.WriteLine( "El menor caudal es: "+ red1.minCaudal(1000));
			Console.WriteLine("");
			Console.WriteLine("************************************************************");
			
			//quadtree
			//ancho
			Console.WriteLine( "Cantidad de pixeles negros: "+ a1.quadtree(1024));
			Console.WriteLine("");
			
			Console.ReadKey(true);
			
		}
	}
}