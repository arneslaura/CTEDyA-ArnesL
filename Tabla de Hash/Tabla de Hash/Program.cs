
using System;
using System.Collections;
using System.Collections.Generic;

namespace Tabla_de_Hash
{
	class Program
	{
		public static void Main(string[] args)
		{
			//dispersion abierta
			DispersionAbierta dp= new DispersionAbierta(11);
			dp.agregar(5);
			dp.agregar(20);
			dp.agregar(3);
			dp.agregar(1000);
			dp.agregar(45);
			dp.agregar(27);
			dp.agregar(25);
			Console.WriteLine("Insercion con dispercion abierta: ");
			dp.imprimir();
			Console.WriteLine("");
			Console.WriteLine("");
			
			//dispersion cerrada lineal
			CerradaLineal dl= new CerradaLineal();
			dl.agregar(5);
			dl.agregar(20);
			dl.agregar(3);
			dl.agregar(1000);
			dl.agregar(45);
			dl.agregar(27);
			dl.agregar(38);
			Console.WriteLine("Insercion con dispercion cerrada lineal: ");
			dl.imprimir();
			Console.WriteLine("");
			Console.WriteLine("");
			
			//dispersion cerrada cuadratica
			CerradaCuadratica dc= new CerradaCuadratica();
			dc.agregar(5);
			dc.agregar(20);
			dc.agregar(3);
			dc.agregar(1000);
			dc.agregar(45);
			dc.agregar(27);
			dc.agregar(38);
			Console.WriteLine("Insercion con dispercion cerrada cuadratica: ");
			dc.imprimir();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("**********************************************************************");
			Console.WriteLine("");
			
			
			//clave
			Clave c = new Clave();
			c.guardarClave("Juan","23kle");
			c.guardarClave("Ana","ana345");
			c.guardarClave("Jose","pyj8988");
			Console.WriteLine("Verificacion de claves:");
			if(c.verificarClave("Ana","ana345")==true){
				Console.WriteLine("Verificacion correcta");
			   }
			else{
				Console.WriteLine("Verificacion incorrecta");
			}
			if(c.verificarClave("Maria","4500098")==true){
				Console.WriteLine("Verificacion correcta");
			   }
			else{
				Console.WriteLine("Verificacion incorrecta");
			}
			Console.WriteLine("");
			Console.WriteLine("**********************************************************************");
			
			//empleados
			TablaEmpleados te = new TablaEmpleados();
			Empleado e1 = new Empleado("Juan Perez", 20, 34555656);
			Empleado e2 = new Empleado("Ana Martinez", 2, 23777454);
			Empleado e3 = new Empleado("Jose Lopez", 89, 12090479);
			te.guardarEmpleado(e1);
			te.guardarEmpleado(e2);
			te.guardarEmpleado(e3);
			te.recuperarEmpleado(18776633);
			te.recuperarEmpleado(12090479);
			
			Console.ReadKey(true);
		}
	}
}