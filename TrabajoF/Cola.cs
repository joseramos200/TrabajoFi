/*
 * Created by SharpDevelop.
 * User: Windows 10
 * Date: 29/11/2019
 * Time: 2:37 (MIN)
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;


namespace TrabajoF
{
	/// <summary>
	/// Description of Cola.
	/// </summary>
	public class Cola<T>
	{

		
		private List<T> datos = new List<T>();
	
		public void encolar(T elem) {
			this.datos.Add(elem);
		}
	
		public T desencolar() {
			T temp = this.datos[0];
			this.datos.RemoveAt(0);
			return temp;
		}
		
		public T tope() {
			return this.datos[0]; 
		}
		
			public bool esVacia() {
				return this.datos.Count == 0;
			}
		}
}
	