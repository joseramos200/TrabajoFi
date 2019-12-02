/*
 * Created by SharpDevelop.
 * User: Windows 10
 * Date: 29/11/2019
 * Time: 2:29 (MIN)
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TrabajoF
{
	/// <summary>
	/// Description of NodoGeneral.
	/// </summary>
	public class NodoGeneral<T>
	{
		private T dato;
		private List<NodoGeneral<T>> hijos;
		public int cuantasVecesPerdio;
		public int perdioUsuario;
		
		public int PerdioUsuario
		{
			get
			{
				return perdioUsuario;
			}
			set
			{
				perdioUsuario = 0;
			}
		}
		
		public int CuantasVecesPerdio
		{
			get
			{
				return cuantasVecesPerdio;
			}
			set
			{
				cuantasVecesPerdio = value;
			}
		}
	
		public NodoGeneral(T dato){		
			this.dato = dato;
			this.hijos = new List<NodoGeneral<T>>();
		}
	
		public T getDato(){		
			return this.dato; 
		}
		
		public List<NodoGeneral<T>> getHijos(){		
			return this.hijos;
		}

		public void setDato(T dato){		
			this.dato = dato;
		}
		
		public void setHijos(NodoGeneral<T> Hijo){
			this.hijos.Add(Hijo);
		}
	
	}
}
