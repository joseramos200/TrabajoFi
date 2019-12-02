/*
 * Created by SharpDevelop.
 * User: Windows 10
 * Date: 29/11/2019
 * Time: 2:24 (MIN)
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabajoF

{
	public abstract class Jugador
	{
		public  abstract void incializar(List<int> cartasPropias, List<int> cartasOponente, int limite);
		public  abstract int descartarUnaCarta();
		public abstract void cartaDelOponente(int carta);
	}
}