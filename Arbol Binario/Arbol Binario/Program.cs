
using System;
using System.Collections;
using System.Collections.Generic;

namespace Arbol_Binario
{
	class Program
	{
		public static void Main(string[] args)
		{
			//creacion de arbol binario
			ArbolBinario <int> arb1=new ArbolBinario<int>(1);
			ArbolBinario <int> arb2=new ArbolBinario<int>(2);
			ArbolBinario <int> arb3=new ArbolBinario<int>(3);
			arb1.agregarHijoIzquierdo(arb2);
			arb1.agregarHijoDerecho(arb3);
			arb2.agregarHijoIzquierdo(new ArbolBinario<int>(4));
			arb2.agregarHijoDerecho(new ArbolBinario<int>(5));
			arb3.agregarHijoIzquierdo(new ArbolBinario<int>(6));
			arb3.agregarHijoDerecho(new ArbolBinario<int>(7));
			
			//creacion de red binaria
			RedBinariaLlena <int> r1=new RedBinariaLlena<int>(1);
			RedBinariaLlena <int> r2=new RedBinariaLlena<int>(2);
			RedBinariaLlena <int> r3=new RedBinariaLlena<int>(3);
			r1.agregarHijoIzq(r2);
			r1.agregarHijoDer(r3);
			r2.agregarHijoIzq(new RedBinariaLlena<int>(4));
			r2.agregarHijoDer(new RedBinariaLlena<int>(9));
			r3.agregarHijoIzq(new RedBinariaLlena<int>(6));
			r3.agregarHijoDer(new RedBinariaLlena<int>(7));
			
			//creacion de arbol binario de chars
			ArbolBinario <char> a1=new ArbolBinario<char>('-');
			ArbolBinario <char> a2=new ArbolBinario<char>('+');
			ArbolBinario <char> a3=new ArbolBinario<char>('+');
			ArbolBinario <char> a4=new ArbolBinario<char>('*');
			a1.agregarHijoIzquierdo(a2);
			a1.agregarHijoDerecho(a3);
			a2.agregarHijoIzquierdo(new ArbolBinario<char>('A'));
			a2.agregarHijoDerecho(new ArbolBinario<char>('B'));
			a3.agregarHijoIzquierdo(a4);
			a3.agregarHijoDerecho(new ArbolBinario<char>('E'));
			a4.agregarHijoIzquierdo(new ArbolBinario<char>('C'));
			a4.agregarHijoDerecho(new ArbolBinario<char>('D'));
			
			//invocacion a recorridos
			Console.Write("Recorrido preorden: ");
			arb1.preorden();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("Recorrido inorden: ");
			arb1.inorden();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("Recorrido postorden: ");
			arb1.postorden();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("Recorrido por niveles: ");
			arb1.recorridoPorNiveles();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("************************************************************");
			
			//metodo incluye
			int ele=4;
			bool es= arb1.incluye(ele);
			if(es==true){
				Console.WriteLine(ele + " esta en el arbol");
			}
			else{
				Console.WriteLine(ele + " no esta en el arbol");
			}
			Console.WriteLine("");
			int elem=8;
			bool est= arb1.incluye(elem);
			if(est==true){
				Console.WriteLine(elem + " esta en el arbol");
			}
			else{
				Console.WriteLine(elem + " no esta en el arbol");
			}
			Console.WriteLine("");
			
			//cantidad de hojas del arbol
			Console.WriteLine("Cantidad de hojas: " + arb1.contarHojas());
			Console.WriteLine("");

			//recorrido entre niveles
			int p=0, v=1;
			Console.Write("Recorrido entre niveles {0} y {1}: ",p,v);
			arb1.recorridoEntreNiveles(p,v);
			Console.WriteLine("");
			Console.WriteLine("");
			
			//sum de elementos de una profundidad
			int nivel=2;
			ProfundidadDeArbolBinario pro= new ProfundidadDeArbolBinario(arb1);
			Console.WriteLine("La suma de elementos del nivel {0} es: {1} ", nivel, pro.sumaElementosProfundidad(nivel));
			Console.WriteLine("");
			Console.WriteLine("************************************************************");
			
			//red binaria llena
			Console.WriteLine("El retardo mayor es: " + r1.retardoReenvio());
			Console.WriteLine("");
			Console.WriteLine("************************************************************");
			
			//invocacion a recorridos arbol de chars
			Console.Write("Recorrido preorden: ");
			a1.preorden();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("Recorrido inorden: ");
			a1.inorden();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("Recorrido postorden: ");
			a1.postorden();
			Console.WriteLine("");
			Console.WriteLine("");
			
			Console.ReadKey(true);
		}
	}
}