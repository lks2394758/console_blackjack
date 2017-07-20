using System;
using System.Collections.Generic;

namespace test
{
	public class Player
	{
		public string name;
		private List<Card> hand;
		public Player(string n)
		{
			name = n;
			hand = new List<Card>();
		}

		public void AddHand(Card card)
		{
			hand.Add(card);
		}

		public List<Card> ShowHand()
		{
			return hand;
		}

		public int ShowTotalValue()
		{
			int result = 0;
			foreach (var item in hand)
				result += item.CardValue;

			return result;
		}
	}
}
