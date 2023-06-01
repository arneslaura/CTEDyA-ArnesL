
using System;
using System.Collections;
using System.Collections.Generic;

namespace Heap_Binaria
{
	class Program
	{
		public static void Main(string[] args)
		{
			bool s1=true, s2=false;
			int [] u1=new int [] {9,7,1,5,2,10,8,3};
			int [] u2=new int [] {9,7,1,5,2,10,8,3};
			int t=10;
			Console.Write("Heap desordenada: ");
			foreach(int n in u1){
				Console.Write(n+ " ");
			}
			HeapBinaria h1=new HeapBinaria(s1,u1);
			HeapBinaria h2=new HeapBinaria(s2,u2);
			Console.WriteLine();
			Console.Write("Ordenada con max heap: ");
			h1.imprimir();
			Console.WriteLine();
			Console.Write("Ordenada con min heap: ");
			h2.imprimir();
			Console.WriteLine();

			Console.WriteLine("***********************************************************************************************************");
			Console.WriteLine();
			HeapBinaria h3=new HeapBinaria(s1,t);
			h3.agregar(50);
			h3.agregar(52);
			h3.agregar(41);
			h3.agregar(54);
			h3.agregar(46);
			h3.imprimir();
			Console.WriteLine();
			h3.eliminar();
			h3.eliminar();
			h3.eliminar();
			h3.imprimir();
			Console.WriteLine();
			h3.agregar(45);
			h3.agregar(48);
			h3.agregar(55);
			h3.agregar(43);
			h3.imprimir();
			Console.WriteLine();
			h3.eliminar();
			h3.eliminar();
			h3.eliminar();
			h3.imprimir();
			Console.WriteLine();
			Console.WriteLine("***********************************************************************************************************");
						
			//impresora
			Console.WriteLine();
			Impresora i = new Impresora();
			i.nuevoDocumento("hola");
			i.nuevoDocumento("sol");
			i.nuevoDocumento("saturno");
			i.nuevoDocumento("la");
			i.nuevoDocumento("vez");
			Console.WriteLine("documento impreso: "+ i.imprime());
			Console.WriteLine("documento impreso: "+ i.imprime());
			Console.WriteLine("documento impreso: "+ i.imprime());
			Console.WriteLine("documento impreso: "+ i.imprime());
			Console.ReadKey(true);
		}
	}
}