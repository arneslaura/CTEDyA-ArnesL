
using System;

namespace Tabla_de_Hash
{
	/// <summary>
	/// Description of Empleado.
	/// </summary>
	public class Empleado
	{
		//atributos
		private string nombre;
		private int numero;
		private int dni;
		
		//constructor
		public Empleado(string n, int nu, int d)
		{
			this.nombre=n;
			this.numero=nu;
			this.dni=d;
		}
		
		//propiedades
		public string getNombre(){
			return nombre;
		}
		
		public int getNumero(){
			return numero;
		}
		
		public int getDni(){
			return dni;
		}
	}
}
