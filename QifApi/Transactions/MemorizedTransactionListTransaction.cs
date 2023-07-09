﻿using System;
using System.Globalization;

namespace Keg247.Qif.Transactions
{
    /// <summary>
    /// A memorized transaction list transaction. It is used to describe a basic transaction that is memorized.
    /// </summary>
    public class MemorizedTransactionListTransaction : BasicTransaction
    {
        /// <summary>
        /// Gets or sets the transaction type.
        /// </summary>
        /// <value>The transaction type.</value>
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets or sets the amortization current loan balance.
        /// </summary>
        /// <value>The amortization current loan balance.</value>
        public decimal AmortizationCurrentLoanBalance { get; set; }

        /// <summary>
        /// Gets or sets the amortization first payment date.
        /// </summary>
        /// <value>The amortization first payment date.</value>
        public DateTime AmortizationFirstPaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the amortization interest rate.
        /// </summary>
        /// <value>The amortization interest rate.</value>
        public decimal AmortizationInterestRate { get; set; }

        /// <summary>
        /// Gets or sets the amortization number of payments already made.
        /// </summary>
        /// <value>The amortization number of payments already made.</value>
        public decimal AmortizationNumberOfPaymentsAlreadyMade { get; set; }

        /// <summary>
        /// Gets or sets the amortization number of periods per year.
        /// </summary>
        /// <value>The amortization number of periods per year.</value>
        public decimal AmortizationNumberOfPeriodsPerYear { get; set; }

        /// <summary>
        /// Gets or sets the amortization original loan amount.
        /// </summary>
        /// <value>The amortization original loan amount.</value>
        public decimal AmortizationOriginalLoanAmount { get; set; }

        /// <summary>
        /// Gets or sets the amortization total years for loan.
        /// </summary>
        /// <value>The amortization total years for loan.</value>
        public decimal AmortizationTotalYearsForLoan { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format(Resources.Culture, Resources.MemorizedTransactionDisplay, Payee, Amount.ToString("C2", CultureInfo.CurrentCulture));
        }
    }
}
