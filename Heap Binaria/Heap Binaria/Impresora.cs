
using System;
using System.Collections;
using System.Collections.Generic;

namespace Heap_Binaria
{
	/// <summary>
	/// Description of Impresora.
	/// </summary>
	public class Impresora
	{
		//atributos
		private List <string> documentos;
		int cantElementos;
		
		//constructor
		public Impresora() 
		{
			this.documentos=new List <string>();
			this.cantElementos=0;
			
		}
		
		//metodos
		public void nuevoDocumento(string doc){
			documentos.Add(doc);
			this.cantElementos++;
			harriba();
		}
		
		public string imprime(){
			string temp="";
			if(this.documentos.Count!=0){
				temp=this.documentos[0]; //variable para colocar temporalmente el dato que se desencola
				this.documentos.RemoveAt(0); //se borra el primer dsto de la cola
				this.cantElementos--;
				habajo();
				habajo();
				habajo();
			}
			return temp;
		}
		
		private void harriba(){
			int d=this.cantElementos;
			string auxili;
			for(int i=d-1;i>=1;i--){ //recorro los nodos del arbol excepto la raiz
			int hijo=i, padre=(i-1)/2; //posicion donde esta el padre y donde esta el hijo
			if(this.documentos[hijo].Length<this.documentos[padre].Length){//si el hijo es menor que el padre
				auxili=this.documentos[i];
				this.documentos[i]=this.documentos[(i-1)/2];
				this.documentos[(i-1)/2]=auxili;//cambian de posicion padre e hijo
			}
			}
		}
		
		private void habajo(){
			int d=this.cantElementos;
			string aux;
			int mitad=(d/2)-1;//defino la mitad de la lista
			for(int i=mitad;i>=0;i--){ //recorro datos que no son hojas
				int hijo1=((i+1)*2)-1, hijo2=((i+1)*2);
					if((i+1)*2<=d-1){ //si tiene 2 hijos
					if(this.documentos[i].Length>this.documentos[hijo1].Length || this.documentos[i].Length>this.documentos[hijo2].Length){ //si el dato es mayor a alguno de sus hijos
						if(this.documentos[hijo1].ToString().Length<=this.documentos[hijo2].ToString().Length){ //si el hijo 1 es el menor
								aux=this.documentos[i].ToString();
								this.documentos[i]=this.documentos[hijo1];
								this.documentos[hijo1]=aux;
							}
							else{ //si el hijo 2 es el menor
								aux=this.documentos[i];
								this.documentos[i]=this.documentos[hijo2];
								this.documentos[hijo2]=aux;
							}
						}
					}
					else{
						if(this.documentos[i].Length>this.documentos[hijo1].Length){//si tiene un solo hijo y es menor al dato 
							aux=this.documentos[i];
							this.documentos[i]=this.documentos[hijo1];
							this.documentos[hijo1]=aux;
						}
					}
				}

		}
		
		}
	}

