using System;
using System.Collections.Generic;

namespace IOT_1030_Assignment_2
{
		class Program
		{
			// Assignment 1 program 
			static void Main(string[] args)
			{
				Console.WriteLine("Enter the number of cards to pick: ");
				string line = Console.ReadLine();
				if (int.TryParse(line, out int numCards))
				{
					foreach (var card in CardPicker.PickSomeCards(numCards))
					{
						Console.WriteLine(card);
					}
				}
				else
				{
					Console.WriteLine("Please enter a valid number.");
				}

				// Assignment 2 program
				Console.WriteLine();

				ParticleMovement particleMover = new ParticleMovement();
				while (true)
				{
					Console.Write("0 for base movement only\n1 if a magnetic field is present\n" +
								  "2 if a gravitational field is present\n3 for both fields\n");
					char key = Console.ReadKey().KeyChar;
					if (key != '0' && key != '1' && key != '2' && key != '3') return;
					Console.WriteLine($"\nParticle with a movement range of {particleMover.MovementRange} units" +
									  $" moved a total distance of {particleMover.DistanceMoved} units.\n");
				}
			}
		}
		
		// Assignment 1 program methods.
		public static class SubsequenceFinder // The static here means this class CANNOT be instantiated 
		{
			/// <summary>
			/// Determines whether a list of integers is a subsequence of another list of integers
			/// </summary>
			/// <param name="seq">The main sequence of integers.</param>
			/// <param name="subseq">The potential subsequence.</param>
			/// <returns>
			/// True if subseq is a subsequence of seq and false otherwise.
			/// </returns>
			public static bool IsValidSubsequeuce(List<int> seq, List<int> subseq)
			{
				int seqIdx = 0;
				int subseqIdx = 0;
				while (seqIdx < seq.Count && subseqIdx < subseq.Count)
				{
					if (seq[seqIdx] == subseq[subseqIdx])
					{
						++subseqIdx;
					}
					++seqIdx;
				}
				return subseqIdx == subseq.Count;
			}
		}

		class CardPicker
		{
			static Random random = new Random(1);
			/// <summary>
			/// Picks a random (with replacement) number of cards.
			/// </summary>
			/// <param name="numCards">The number of cards to choose at random.</param>
			/// <returns>An array of strings where each string represents a card.</returns>
			public static string[] PickSomeCards(int numCards)
			{
				string[] pickedCards = new string[numCards];
				for (int i = 0; i < numCards; ++i)
				{
					pickedCards[i] = RandomValue() + " of " + RandomSuit();
				}
				return pickedCards;
			}

			// here i am making values enumaration 
			enum Values_list
			{
				Ace,
				Jack,
				Queen,
				King
			}
			
			// and here i am making suits enumaration
			enum Suits_list
			{
				Clubs,
				Diamonds,
				Hearts,
				Spades
			}
		private static string RandomValue()
			{
				int value = random.Next(1, 14);
				switch (value)
				{
					// here i will call values enumaration function.
					case 1:
						Values_list ace = Values_list.Ace; 
						return ace.ToString();					
					case 11:
						Values_list jack = Values_list.Jack;
						return jack.ToString();                  
					case 12:
						Values_list queen = Values_list.Queen;
						return queen.ToString();                   
					case 13:
						Values_list king = Values_list.King;
						return king.ToString();                  
					default:
						// The integers 2 -> 10 can just be converted to a string
						return value.ToString();
				}
			}

			private static string RandomSuit()
			{
				int value = random.Next(1, 5);
				switch (value)
				{
					// here i will call suits enumaration function.
					case 1:
						Suits_list clubs = Suits_list.Clubs;
						return clubs.ToString();
					case 2:
						Suits_list diamonds = Suits_list.Diamonds;
						return diamonds.ToString();
					case 3:
						Suits_list hearts = Suits_list.Hearts;
						return hearts.ToString();
					default:
						Suits_list spades = Suits_list.Spades;
						return spades.ToString();
				}
			}
		}

	// Assignment 2 program method
	class ParticleMovement
	{
		static Random random = new Random(1);

		// 7. here i will make Xml documentation file
		/// <summary>
		/// here i will explain all public class members.
		/// </summary>
		/// <param name="BASE_Movement">this is the constant integer for base movement.</param>
		/// <param name="GRAVITY_MOVEMENT">this is the constant integer for gravity movement.</param>
		/// <param name="MovementRange">This property call movement range. </param>
		/// <param name="MagneticField">This property call Magnetic Field.</param>
		/// <param name="GravitationalField">This property call Gravitation Field.</param>
		/// <param name="Distance">This auto-implemented property call DIstance.</param>
		/// <returns></returns>

		public const int BASE_MOVEMENT = 3;
		public const int GRAVITY_MOVEMENT = 2;

		// 1. here i will make MovementRange property with getter and setter properties.
		private int movementRange;
		public int MovementRange
		{
			get { return movementRange; }
			set { movementRange = value; CalculateDistance(); }
		}

		// 2. here i will make magneticField property with getter and setter properties.

		private bool magneticField;
		public bool MagneticField
		{
			get { return magneticField; }
			set { magneticField = value; CalculateDistance(); }
		}

		// 3. here i will make GravitationalField property with getter and setter properties.

		private bool gravitationalField;
		public bool GravitationalField
		{
			get { return gravitationalField; }
			set { gravitationalField = value; CalculateDistance(); }
		}
		public int DistanceMoved;

		// 4. here i will call Distance auto-implemented property
		public double Distance
		{ get; private set; }

		// 6. here i will make constructor and access modifier
		private int movement_range;
		public ParticleMovement()
		{
			movementRange = movement_range;
			CalculateDistance();
			GetMovementRange(); // 9. here i will call GetMovementRange method in constructor.
		}

		// 5. here i will check properties of MovementRange, MagneticField, and GravitationalField
		public void CalculateDistance()
		{
				DistanceMoved = MovementRange + BASE_MOVEMENT + GRAVITY_MOVEMENT;
		}

		// 8. here i will make GetMovementRange method
		public void GetMovementRange()
		{
			movementRange = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
		}
	}
}
