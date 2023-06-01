/*
 * Creado por SharpDevelop.
 * Usuario: Chichitos
 * Fecha: 31/5/2023
 * Hora: 23:58
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace ABB
{
	class Program
	{
		public static void Main(string[] args)
		{
			//creacion arboles binario de busqueda 
			ArbolBinarioBusqueda a1=new ArbolBinarioBusqueda(3);
			a1.agregar(1);
			a1.agregar(4);
			a1.agregar(6);
			a1.agregar(8);
			a1.agregar(2);
			a1.agregar(5);
			a1.agregar(7);
			Console.WriteLine("Arbol 1");
			Console.WriteLine("");
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
			
			ArbolBinarioBusqueda a2=new ArbolBinarioBusqueda(15);
			a2.agregar(11);
			a2.agregar(9);
			a2.agregar(7);
			a2.agregar(5);
			a2.agregar(4);
			a2.agregar(1);
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Arbol 2");
			Console.WriteLine("");
			Console.Write("Recorrido preorden: ");
			a2.preorden();
			Console.WriteLine("");
			Console.Write("Recorrido inorden: ");
			a2.inorden();
			Console.WriteLine("");
			Console.Write("Recorrido postorden: ");
			a2.postorden();
			Console.WriteLine("");
			Console.Write("Recorrido por niveles: ");
			a2.recorridoPorNiveles();
			
			//metodo incluye
			Console.WriteLine("");
			Console.WriteLine("");
			if(a1.incluye(8)){
				Console.WriteLine("El arbol 1 incluye 8");
			}
			if(a2.incluye(4)){
				Console.WriteLine("El arbol 2 incluye 4");
			}
			if(!a1.incluye(9)){
				Console.WriteLine("El arbol 1 no incluye 9");
			}
			Console.ReadKey(true);
		}
	}
}