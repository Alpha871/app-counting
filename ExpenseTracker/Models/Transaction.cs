using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ExpenseTracker.Models
{
	public class Transaction
	{
		[Key]
		public int TransactionId { get; set; }

		[Range(1,int.MaxValue, ErrorMessage ="Please select a category.")]
		public int CategoryId { get; set; }
		public Category? Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public int Amount { get; set; }
		public string? Note { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;

		[NotMapped]
		public string? categoryTitleWithIcon
		{
			get
			{
				return Category == null ? "" : Category.Icon + " " + Category.Title;
			}
		}

        [NotMapped]
        public string? FormattedAmount
        {
 

            get
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
                culture.NumberFormat.CurrencyNegativePattern = 1;
	
				return ((Category == null || Category.Type == "Expense") ? "-" : "+") + String.Format(culture, "{0:C0}", Amount);
            }
        }
    }
}

