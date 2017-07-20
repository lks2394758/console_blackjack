using System;
using System.Collections.Generic;

namespace test
{
	public class Dealer
	{

		private List<Card> cards;
		public Dealer()
		{
			cards = new List<Card>();
			InitializeDeck();
			Shuffle();
		}

		public void InitializeDeck()
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					var card = new Card
					{
						Suit = (Constants.Suit)i,
						Face = (Constants.Face)j + 1,
						CardValue = j < 9 && j > 0 ? j + 1 : 10
					};
					cards.Add(card);
				}
			}
		}

		public void Shuffle()
		{
			Random random = new Random();
			int n = cards.Count;
			while (n > 1)
			{
				n--;
				int k = random.Next(n + 1);
				var tmp = cards[k];
				cards[k] = cards[n];
				cards[n] = tmp;
			}
		}

		public Card DrawCard()
		{
			if (cards.Count <= 0)
			{
				InitializeDeck();
				Shuffle();
			}

			var card = cards[cards.Count - 1];
			cards.Remove(cards[cards.Count - 1]);
			return card;
		}

	}

	public class Card
	{
		public Constants.Suit Suit
		{
			get;
			set;
		}

		public Constants.Face Face
		{
			get;
			set;
		}

		public int CardValue
		{
			get;
			set;
		}
	}
}
