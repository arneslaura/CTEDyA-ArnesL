using System.Collections;
using System.Collections.Generic;
using System;

namespace AVL
{
	class Program
	{
		public static void Main(string[] args)
		{
			//creacion de AVL
			AVL a1=new AVL(40);
			a1=a1.agregar(20);
			a1=a1.agregar(30);
			a1=a1.agregar(38);
			a1=a1.agregar(33);
			a1=a1.agregar(36);
			a1=a1.agregar(34);
			a1=a1.agregar(37);
			
			//llamada a recooridos
			Console.Write("Recorrido preorden: ");
			a1.preorden();
			Console.WriteLine("");
			Console.Write("Recorrido inorden: ");
			a1.inorden();
			Console.WriteLine("");
			Console.Write("Recorrido postorden: ");
			a1.postorden();
			Console.WriteLine("");
			Console.Write("Recorrido por niveles: ");
			a1.recorridoPorNiveles();
			Console.ReadKey(true);
		}
	}
}