
using System;
using System.Collections;

namespace Tabla_de_Hash
{
	/// <summary>
	/// Description of TablaEmpleados.
	/// </summary>
	public class TablaEmpleados
	{
		//atributos
		ArrayList [] arr; //lista que va a contener las arraylist
		
		//constructor
		public TablaEmpleados()
		{
			arr=new ArrayList[11]; //se instancia la lista
			for (int i=0; i<11; i ++){
				this.arr[i]=new ArrayList();
			}
		}
		
		//metodos
		private int gethash(int n){
			return n%11;
		}
		
		public void guardarEmpleado(Empleado e){
			int h=gethash(e.getDni());
			arr[h].Add(e);
		}
		
		public void recuperarEmpleado(int dn){
			bool esta=false; //si sigue en false no encontro coincidencia con el dni del empleado
			int h=gethash(dn);
			foreach(Empleado em in arr[h]){
					if(dn == em.getDni()){
						Console.WriteLine("{0} Empleado num: {1}" ,em.getNombre(), em.getNumero());
						esta=true;
					}
			}
			if(esta==false){
				Console.WriteLine("El DNI no esta ligado a ningun empleado de la base de datos");
			}
		}
		
	}
}
