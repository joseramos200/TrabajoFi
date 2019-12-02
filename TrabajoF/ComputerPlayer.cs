/*
 * Created by SharpDevelop.
 * User: Windows 10
 * Date: 29/11/2019
 * Time: 2:27 (MIN)
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabajoF
{
	public class ComputerPlayer: Jugador
	{
		private List<int> naipesComputer = new List<int>();
		private List<int> naipesUsuario = new List<int>();
		private int limite;
		private bool miTurno = false;
		public static ArbolGeneral<int> arbolMiniMax = new ArbolGeneral<int>(0);
		
		public ComputerPlayer()
		{
		}
		
		public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			NodoGeneral<int> raiz = new NodoGeneral<int>(0);
			this.naipesComputer = cartasPropias;
			this.naipesUsuario = cartasOponente;
			this.limite = limite;
			crearArbol(raiz, cartasOponente, cartasPropias, miTurno, limite);
			this.ArbolMiniMax.Raiz=raiz;
			Console.WriteLine();
		}
		
		public void crearArbol(NodoGeneral<int> raiz, List<int> Cusuario, List<int> Coponente, bool miTurno, int tope)
		{
			for (int i = 0; i < Cusuario.Count; i++)
			{
				//mi turno esta en false juega el usuario
				List<int> cartasRepetidas = fotocopia(Cusuario);
				int cartaSeleccionada = Cusuario[i];
				cartasRepetidas.Remove(cartaSeleccionada);
				NodoGeneral<int> Nuevohijo = new NodoGeneral<int>(cartaSeleccionada);
				raiz.setHijos(Nuevohijo);
				

				if(miTurno && ((tope-cartaSeleccionada) < 0))
				{
					Nuevohijo.PerdioUsuario=1;
				}
//				if(miTurno && ((tope-cartaSeleccionada) == 0))
//				{
//					Nuevohijo.perdioComputer=1;
//				}
				if(!miTurno && ((tope-cartaSeleccionada) == 0))
				{
					Nuevohijo.PerdioUsuario=1;
				}
				else
				{
					crearArbol(Nuevohijo, Coponente, cartasRepetidas, !miTurno, (tope - cartaSeleccionada));
				}
			}
			

		}

		public override int descartarUnaCarta()
		{
			int mejoropcion = -1;
			ArbolGeneral<int> nueopcion=null;
			foreach (ArbolGeneral<int> opciones in arbolMiniMax.getHijos())
			{
				if (opciones.Raiz.cuantasVecesPerdio > mejoropcion)
				{
					nueopcion = opciones;
					mejoropcion = opciones.Raiz.CuantasVecesPerdio;

				}
			}
			arbolMiniMax.Raiz=nueopcion.Raiz;
			Console.WriteLine("La maquina escogio la carta " + nueopcion.getDatoRaiz());
			return nueopcion.getDatoRaiz();
			encolarParaRecorrer(arbolMiniMax);
		}
		
		public override void cartaDelOponente(int carta)
		{
			foreach(ArbolGeneral<int> NuevaRaiz in arbolMiniMax.getHijos())
			{
				if (NuevaRaiz.getDatoRaiz() == carta)
					arbolMiniMax.Raiz=NuevaRaiz.Raiz;
			}
			encolarParaRecorrer(arbolMiniMax);
			limite = limite -carta;
		}
		
		public List<int> fotocopia(List<int> lista)
		{
			List<int> copia=new List<int>();
			foreach(int numeros in lista)
			{
				copia.Add(numeros);
			}
			return copia;
		}
		
		public ArbolGeneral<int> ArbolMiniMax
		{
			get
			{
				return arbolMiniMax;
			}
			
			set
			{
				arbolMiniMax = value;
			}
		}
		
		public void recorreHijos(ArbolGeneral<int> arbol)
		{

		}
		
		public void recoridoPorNiveles(Cola<ArbolGeneral<int>> cola, Cola<ArbolGeneral<int>> colaRepe, int nivel)
		{
			if(cola.esVacia()==true)
			{
				Console.WriteLine("Se termino");
			}
			if(cola.esVacia()==false)
			{
				while(cola.esVacia()==false)
				{
					ArbolGeneral<int> arboli=cola.desencolar();
					Console.Write(arboli.getDatoRaiz()+", ");
					colaRepe.encolar(arboli);
				}
				while(colaRepe.esVacia()==false)
				{
					ArbolGeneral<int> arbolito=colaRepe.desencolar();
					foreach (ArbolGeneral<int> hijos in arbolito.getHijos())
					{
						cola.encolar(hijos);
					}
				}
				if(nivel%2==1)
				{
					Console.WriteLine("Usuario");
				}
				if(nivel%2==0)
				{
					Console.WriteLine("Computer");
				}
				nivel++;
				recoridoPorNiveles(cola,colaRepe, nivel);
			}
			
			
		}
		
		public void encolarParaRecorrer(ArbolGeneral<int> arbol)
		{
			Cola<ArbolGeneral<int>> cola=new Cola<ArbolGeneral<int>>();
			Cola<ArbolGeneral<int>> colaVacia=new Cola<ArbolGeneral<int>>();
			cola.encolar(arbol);
			recoridoPorNiveles(cola,colaVacia,0);
		}
		
		
		
	}
}
