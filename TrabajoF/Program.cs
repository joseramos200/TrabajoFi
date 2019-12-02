/*
 * Created by SharpDevelop.
 * User: Windows 10
 * Date: 29/11/2019
 * Time: 2:16 (MIN)
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabajoF
{
	class Program
	{
		public static void Main(string[] args)
		{
				Game game = new Game();
				game.play();
			    Console.ReadKey();
		}
	}
}