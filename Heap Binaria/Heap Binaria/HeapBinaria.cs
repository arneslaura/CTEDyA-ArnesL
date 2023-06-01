
using System;
using System.Collections;
using System.Collections.Generic;

namespace Heap_Binaria
{
	/// <summary>
	/// Description of HeapBinaria.
	/// </summary>
	public class HeapBinaria//calse de tipo generica
	{
		//atributos
		private int [] datos; //array de enteros
		private int cantElementos; //cantidad de elementos que hay
		private bool es; //true=maxheap false=minheap
		
		//constructores
		public HeapBinaria(bool b, int c){//para crear heap vacia
			this.es=b; //si es max o min
			datos=new int[c];//se inicializa el array 
			this.cantElementos=0;//no hay elementos dentro de la heap
		}
		
		public HeapBinaria(bool b, int[] d){//para crear heap a partir de un arreglo desordenado
			this.es=b;
			this.datos=d;
			this.cantElementos=d.Length;
			fhaciaabajo(); //buildheap
			fhaciaabajo();
			fhaciaabajo();
		}
		
		//propiedades
		public int getCantElems(){
			return this.cantElementos;
		}
		
		public bool getEs(){
			return this.es;
		}
		
		//metodos
		public bool esVacia(){
			return this.cantElementos==0; //retorna true si la lista esta vacia o false si tiene elementos
		}
		
		public int tope(){
			return this.datos[0]; //retorna el elemento que esta primero en la lista
		}
		
		public void imprimir(){
			for(int i=0;i<=cantElementos-1;i++){
				Console.Write(this.datos[i] + " ");//imprime en pantalla los datos de la heap
			}
		}
		
		public bool agregar (int elem){
			this.datos[this.cantElementos]=elem;//se inserta el elemento en la ultima posc
			this.cantElementos++; //se agrego un elemento
			fhaciaarriba();//filtrado hacia arriba
			return true;
		}
		
		public int eliminar (){
			int aux= this.datos[0]; //auxiliar para el elemento que se va a eliminar
			this.datos[0]=this.datos[this.cantElementos-1]; //el de la ultima posc pasa a la primera
			this.datos[this.cantElementos-1]=0; //se elimina el dato de la ultima posc
			this.cantElementos--; //se elimino un elemento
			fhaciaabajo();//varias veces para qie quede en orden
			fhaciaabajo();
			fhaciaabajo();
			return aux;
		}
		
		private void fhaciaarriba(){
			if(this.es==false){//si es min
				for(int i=cantElementos-1;i>=1;i--){ //recorro los nodos del arbol excepto la raiz
					int hijo=i, padre=(i-1)/2, auxili; //posicion donde esta el padre y donde esta el hijo
					if(this.datos[hijo]<this.datos[padre]){//si el hijo es menor que el padre
						auxili=this.datos[hijo];
						this.datos[hijo]=this.datos[padre];
						this.datos[padre]=auxili;//cambian de posicion padre e hijo
					}
				}
			}
			if(this.es==true){//si es max
				for(int i=cantElementos-1;i>=1;i--){ //recorro los nodos del arbol excepto la raiz
					int hijo=i, padre=(i-1)/2, auxili; //posicion donde esta el padre y donde esta el hijo
					if(this.datos[hijo]>this.datos[padre]){//si el hijo es mayor que el padre
						auxili=this.datos[hijo];
						this.datos[hijo]=this.datos[padre];
						this.datos[padre]=auxili;//cambian de posicion padre e hijo
					}
				}
			}
		}
		
		private void fhaciaabajo(){
			int aux, mitad=(cantElementos/2)-1;//defino la mitad de la lista
			for(int i=mitad;i>=0;i--){ //recorro datos que no son hojas
				int hijo1=((i+1)*2)-1, hijo2=((i+1)*2);
				if(this.es==false){//si es una min heap
					if((i+1)*2<=cantElementos-1){ //si tiene 2 hijos
						if(this.datos[i]>this.datos[hijo1] || this.datos[i]>this.datos[hijo2]){ //si el dato es mayor a alguno de sus hijos
								if(this.datos[hijo1]<=this.datos[hijo2]){ //si el hijo 1 es el menor
								aux=this.datos[i];
								this.datos[i]=this.datos[hijo1];
								this.datos[hijo1]=aux;
							}
							else{ //si el hijo 2 es el menor
								aux=this.datos[i];
								this.datos[i]=this.datos[hijo2];
								this.datos[hijo2]=aux;
							}
						}
					}
					else{
						if(this.datos[i]>this.datos[hijo1]){//si tiene un solo hijo y es menor al dato 
							aux=this.datos[i];
							this.datos[i]=this.datos[hijo1];
							this.datos[hijo1]=aux;
						}
					}
				}
				if(this.es==true){//si es una max heap
					if((i+1)*2<=cantElementos-1){ //si tiene 2 hijos
						if(this.datos[i]<this.datos[hijo1] || this.datos[i]<this.datos[hijo2]){ //si el dato es menor a alguno de sus hijos
								if(this.datos[hijo1]>=this.datos[hijo2]){ //si el hijo 1 es el mayor
								aux=this.datos[i];
								this.datos[i]=this.datos[hijo1];
								this.datos[hijo1]=aux;
							}
							else{ //si el hijo 2 es el mayor
								aux=this.datos[i];
								this.datos[i]=this.datos[hijo2];
								this.datos[hijo2]=aux;
							}
						}
					}
					else{
						if(this.datos[i]<this.datos[hijo1]){//si tiene un solo hijo y es mayor al dato 
							aux=this.datos[i];
							this.datos[i]=this.datos[hijo1];
							this.datos[hijo1]=aux;
						}
					}
				}
			
			}
		}
	}
}
