using System;
using System.Collections;
using System.Collections.Generic;

namespace Grafo
{
	class Program
	{
		public static void Main(string[] args)
		{
			//creacion grafo
			Grafo<int> g = new Grafo<int>();
			Vertice<int> v1 = new Vertice<int>(1);
            Vertice<int> v2 = new Vertice<int>(2);
            Vertice<int> v3 = new Vertice<int>(3);
            Vertice<int> v4 = new Vertice<int>(4);
            Vertice<int> v5 = new Vertice<int>(5);
            Vertice<int> v6 = new Vertice<int>(6);
            Vertice<int> v7 = new Vertice<int>(7);
            g.agregarVertice(v1);
            g.agregarVertice(v2);
            g.agregarVertice(v3);
            g.agregarVertice(v4);
            g.agregarVertice(v5);
            g.agregarVertice(v6);
            g.agregarVertice(v7);
            g.conectar(v1,v2,0);
            g.conectar(v1,v4,0);
            g.conectar(v2,v5,0);
            g.conectar(v3,v5,0);
            g.conectar(v4,v2,0);
            g.conectar(v4,v5,0);
            g.conectar(v4,v6,0);
            g.conectar(v4,v3,0);
            g.conectar(v5,v7,0);
            g.conectar(v6,v7,0);
            g.conectar(v6,v3,0);
            
            Console.WriteLine("Recorrido DFS");
            g.DFS(v1);
            Console.WriteLine("");
            Console.WriteLine("Recorrido BFS");
            g.BFS(v1);
            Console.WriteLine("");
            Console.WriteLine("");
            Caminos<int> c1=new Caminos<int>();
            Console.WriteLine("Camino entre {0} y {1}",v1.getDato(),v7.getDato());
            c1.caminosimpleconDFS(g,v1,v7);
            Console.WriteLine("");
            Caminos<int> c2=new Caminos<int>();
            Console.WriteLine("Nodos a 2 aristas de distacia del nodo 1");
            c2.verticesADistanciaConBFS(g,v1,2);
			Console.ReadKey(true);
		}
	}
}