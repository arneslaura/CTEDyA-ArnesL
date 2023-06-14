using System;
using System.Collections;
using System.Collections.Generic;

namespace TPF
{
    internal static class Program
    {
        static void Main()
        {
        	//creacion de arbol general de datos distancia
        	Estrategia e1= new Estrategia();
        	ArbolGeneral<DatoDistancia> a1=new ArbolGeneral<DatoDistancia>(new DatoDistancia(0,"color",""));
        	e1.AgregarDato(a1,new DatoDistancia(0,"olor",""));
        	e1.AgregarDato(a1,new DatoDistancia(0,"calor",""));
        	e1.AgregarDato(a1,new DatoDistancia(0,"mesa",""));
        	e1.AgregarDato(a1,new DatoDistancia(0,"masa",""));
        	e1.AgregarDato(a1,new DatoDistancia(0,"mesas",""));
        	e1.AgregarDato(a1,new DatoDistancia(0,"pastel",""));
        	e1.AgregarDato(a1,new DatoDistancia(0,"papel",""));
        	e1.AgregarDato(a1,new DatoDistancia(0,"carrito",""));
        	
        	//arbol ya armado
        	ArbolGeneral<DatoDistancia> ar1=new ArbolGeneral<DatoDistancia>(new DatoDistancia(0,"color",""));
        	ArbolGeneral<DatoDistancia> ar2=new ArbolGeneral<DatoDistancia>(new DatoDistancia(1,"olor",""));
        	ArbolGeneral<DatoDistancia> ar3=new ArbolGeneral<DatoDistancia>(new DatoDistancia(5,"mesa",""));
        	ArbolGeneral<DatoDistancia> ar4=new ArbolGeneral<DatoDistancia>(new DatoDistancia(6,"pastel",""));
        	ar1.agregarHijo(ar2);
        	ar1.agregarHijo(ar3);
        	ar1.agregarHijo(ar4);
        	ArbolGeneral<DatoDistancia> ar5=new ArbolGeneral<DatoDistancia>(new DatoDistancia(2,"calor",""));
        	ArbolGeneral<DatoDistancia> ar6=new ArbolGeneral<DatoDistancia>(new DatoDistancia(1,"masa",""));
        	ArbolGeneral<DatoDistancia> ar7=new ArbolGeneral<DatoDistancia>(new DatoDistancia(5,"papel",""));
        	ArbolGeneral<DatoDistancia> ar8=new ArbolGeneral<DatoDistancia>(new DatoDistancia(6,"carrito",""));
        	ar2.agregarHijo(ar5);
        	ar3.agregarHijo(ar6);
        	ar3.agregarHijo(ar7);
        	ar4.agregarHijo(ar8);
        	ArbolGeneral<DatoDistancia> ar9=new ArbolGeneral<DatoDistancia>(new DatoDistancia(2,"mesas",""));
        	ar6.agregarHijo(ar9);
        	
        	//consultas
        	Console.WriteLine("Hojas en el arbol:" + e1.Consulta1(ar1));
        	Console.WriteLine("");
        	Console.WriteLine(e1.Consulta2(ar1));
        	Console.WriteLine("");
        	Console.Write("Elementos por nivel: ");
        	Console.Write(e1.Consulta3(ar1));
        	Console.WriteLine("");
        	Console.WriteLine("");
        	e1.Buscar(ar1,"sol");
        	e1.Buscar(ar1,"papel");
        	
        	Console.ReadKey(true);
        }

    }
}