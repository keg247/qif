using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    internal static class MemorizedTransactionListWriter
    {
        internal static void Write(TextWriter writer, ICollection<MemorizedTransactionListTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                writer.WriteLine(Headers.MemorizedTransactionList);

                foreach (MemorizedTransactionListTransaction item in list)
                {
                    foreach (string address in item.Address)
                    {
                        writer.Write(MemorizedTransactionListFields.Address);
                        writer.WriteLine(address);
                    }

                    writer.Write(MemorizedTransactionListFields.AmortizationCurrentLoanBalance);
                    writer.WriteLine(item.AmortizationCurrentLoanBalance.ToString(CultureInfo.CurrentCulture));

                    writer.Write(MemorizedTransactionListFields.AmortizationFirstPaymentDate);
                    writer.WriteLine(item.AmortizationFirstPaymentDate.ToString("d"));

                    writer.Write(MemorizedTransactionListFields.AmortizationInterestRate);
                    writer.WriteLine(item.AmortizationInterestRate.ToString(CultureInfo.CurrentCulture));

                    writer.Write(MemorizedTransactionListFields.AmortizationNumberOfPaymentsAlreadyMade);
                    writer.WriteLine(item.AmortizationNumberOfPaymentsAlreadyMade.ToString(CultureInfo.CurrentCulture));

                    writer.Write(MemorizedTransactionListFields.AmortizationNumberOfPeriodsPerYear);
                    writer.WriteLine(item.AmortizationNumberOfPeriodsPerYear.ToString(CultureInfo.CurrentCulture));

                    writer.Write(MemorizedTransactionListFields.AmortizationOriginalLoanAmount);
                    writer.WriteLine(item.AmortizationOriginalLoanAmount.ToString(CultureInfo.CurrentCulture));

                    writer.Write(MemorizedTransactionListFields.AmortizationTotalYearsForLoan);
                    writer.WriteLine(item.AmortizationTotalYearsForLoan.ToString(CultureInfo.CurrentCulture));

                    writer.Write(MemorizedTransactionListFields.Amount);
                    writer.WriteLine(item.Amount.ToString(CultureInfo.CurrentCulture));

                    if (!string.IsNullOrEmpty(item.Category))
                    {
                        writer.Write(MemorizedTransactionListFields.Category);
                        writer.WriteLine(item.Category);
                    }

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        writer.Write(MemorizedTransactionListFields.ClearedStatus);
                        writer.WriteLine(item.ClearedStatus);
                    }

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        writer.Write(MemorizedTransactionListFields.Memo);
                        writer.WriteLine(item.Memo);
                    }

                    if (!string.IsNullOrEmpty(item.Payee))
                    {
                        writer.Write(MemorizedTransactionListFields.Payee);
                        writer.WriteLine(item.Payee);
                    }

                    foreach (int i in item.SplitCategories.Keys)
                    {
                        writer.Write(MemorizedTransactionListFields.SplitCategory);
                        writer.WriteLine(item.SplitCategories[i]);
                        writer.Write(MemorizedTransactionListFields.SplitAmount);
                        writer.WriteLine(item.SplitAmounts[i]);

                        string value;
                        if (item.SplitMemos.TryGetValue(i, out value))
                        {
                            writer.Write(MemorizedTransactionListFields.SplitMemo);
                            writer.WriteLine(value);
                        }
                    }

                    writer.Write(MemorizedTransactionListFields.Transaction);
                    switch (item.Type)
                    {
                        case TransactionType.Check:
                            writer.WriteLine(MemorizedTransactionListTransactionTypes.Check);
                            break;
                        case TransactionType.Deposit:
                            writer.WriteLine(MemorizedTransactionListTransactionTypes.Deposit);
                            break;
                        case TransactionType.ElectronicPayee:
                            writer.WriteLine(MemorizedTransactionListTransactionTypes.ElectronicPayee);
                            break;
                        case TransactionType.Investment:
                            writer.WriteLine(MemorizedTransactionListTransactionTypes.Investment);
                            break;
                        case TransactionType.Payment:
                            writer.WriteLine(MemorizedTransactionListTransactionTypes.Payment);
                            break;
                    }
                }
            }
        }
    }
}