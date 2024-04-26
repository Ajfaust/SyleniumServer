﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetUpServer.Entity
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        public string? Notes { get; set; }

        public decimal Inflow { get; set; }

        public decimal Outflow { get; set; }

        public bool Cleared { get; set; }

        #region Spreadsheet Relation

        public int SpreadsheetId { get; set; }

        public virtual Spreadsheet Spreadsheet { get; set; }

        #endregion Spreadsheet Relation

        #region Vendor Relation

        public int? VendorId { get; set; }

        public virtual Vendor? Vendor { get; set; }

        #endregion Vendor Relation

        #region Transaction Category Relation

        public int? TransactionCategoryId { get; set; }

        public virtual TransactionCategory? TransactionCategory { get; set; }

        #endregion Transaction Category Relation

        #region Account Relation

        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }

        #endregion Account Relation
    }
}