using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.Title = "BlackJack";
			var player = new Player("user");
			var computer = new Player("computer");
			var dealer = new Dealer();
			for (int i = 0; i < 2; i++)
			{
				player.AddHand(dealer.DrawCard());
				computer.AddHand(dealer.DrawCard());
			}
			while (true)
			{
				var hands = player.ShowHand();
				Console.WriteLine("Your hand cards are:");
				foreach (var item in hands)
					Console.WriteLine("{0} {1}", Enum.GetName(typeof(Constants.Face), item.Face), Enum.GetName(typeof(Constants.Suit), item.Suit));
				if (player.ShowTotalValue() > 21)
				{
					Console.WriteLine("You boom! total value is :{0}", player.ShowTotalValue());
					break;
				}

				if (computer.ShowTotalValue() > 21)
				{
					Console.WriteLine("Computer boom! total value is :{0}", computer.ShowTotalValue());
					break;
				}

				Console.WriteLine("Do you want another Card? Y/N:");
				var a = Console.ReadLine();
				if (a == "Y" || a == "y")
				{
					player.AddHand(dealer.DrawCard());
					computer.AddHand(dealer.DrawCard());
				}
				else
				{
					var playerValue = player.ShowTotalValue();
					var compValue = computer.ShowTotalValue();
					if (playerValue < compValue)
					{
						Console.WriteLine("You Lose, your value is {0}, computer value is {1}", playerValue, compValue);
					}
					else if (playerValue > compValue)
					{
						Console.WriteLine("You Win, your value is {0}, computer value is {1}", playerValue, compValue);

					}else
						Console.WriteLine("Draw, your value is {0}, computer value is {1}", playerValue, compValue);

					break;

				}
			}
			Console.WriteLine("Press any key to close...");
			Console.ReadLine();
			return;
		}
	}
}
