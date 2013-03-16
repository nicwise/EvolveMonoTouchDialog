using System;
using System.Collections.Generic;
using MonoTouch.Dialog;

namespace mixandmatch
{

	//our basic class.
	// This has both MT.D annotations and also the data structure. 
	// In real life, you might want to split this off into 2 classes - one to 
	// handle the data (and sit in the database), and one for the viewing 
	// ie, an MVVM style split.
	public class Bank
	{

		[Entry("Bank name")]
		public string Name;
		public bool TarpFunded;

		[Caption("Funds taken")]
		[Range(0, 10, ShowCaption = true)]
		public float TarpFunds;

		[Skip]
		public bool IsUsBank = true;
	}

	// Dummy data source - make up some banks and how much TARP money they took
	public class BankDatasource
	{
		static List<Bank> banks;

		static void InitBanks()
		{
			banks = new List<Bank> 
			{
				new Bank { Name = "Barclays", TarpFunded = false, TarpFunds = 0f, IsUsBank = false},
				new Bank { Name = "Bank of America", TarpFunded = true, TarpFunds = 7.5f},
				new Bank { Name = "Wells Fargo", TarpFunded = true, TarpFunds = 2f},
				new Bank { Name = "Citibank", TarpFunded = true, TarpFunds = 5f},
				new Bank { Name = "JP Morgan", TarpFunded = true, TarpFunds = 9f},
				new Bank { Name = "Bank Direct", TarpFunded = false, TarpFunds = 0f, IsUsBank = false},
				new Bank { Name = "ASB Bank", TarpFunded = false, TarpFunds = 0f, IsUsBank = false},

			};
		}


		public static IEnumerable<Bank> Banks()
		{
			if (banks == null)
			{
				InitBanks ();
			}

			foreach(var bank in banks)
			{
				yield return bank;
			}
		}
	}


}

