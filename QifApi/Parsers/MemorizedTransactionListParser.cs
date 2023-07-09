using Keg247.Qif.Transactions;
using Keg247.Qif.Transactions.Fields;

namespace Keg247.Qif.Parsers
{
    class MemorizedTransactionListParser : IParser
    {
        private MemorizedTransactionListTransaction item = new MemorizedTransactionListTransaction();

        public void Yield(QifDocument document)
        {
            document.MemorizedTransactionListTransactions.Add(item);
            item = new MemorizedTransactionListTransaction();
        }

        public void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case MemorizedTransactionListFields.Address:
                    item.Address.Add(value);
                    break;
                case MemorizedTransactionListFields.AmortizationCurrentLoanBalance:
                    item.AmortizationCurrentLoanBalance = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmortizationFirstPaymentDate:
                    item.AmortizationFirstPaymentDate = Common.GetDateTime(value);
                    break;
                case MemorizedTransactionListFields.AmortizationInterestRate:
                    item.AmortizationInterestRate = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmortizationNumberOfPaymentsAlreadyMade:
                    item.AmortizationNumberOfPaymentsAlreadyMade = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmortizationNumberOfPeriodsPerYear:
                    item.AmortizationNumberOfPeriodsPerYear = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmortizationOriginalLoanAmount:
                    item.AmortizationOriginalLoanAmount = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmortizationTotalYearsForLoan:
                    item.AmortizationTotalYearsForLoan = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.Amount:
                    item.Amount = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.Category:
                    item.Category = value;
                    break;
                case MemorizedTransactionListFields.Transaction:
                    switch (value)
                    {
                        case MemorizedTransactionListTransactionTypes.Check:
                            item.Type = TransactionType.Check;
                            break;
                        case MemorizedTransactionListTransactionTypes.Deposit:
                            item.Type = TransactionType.Deposit;
                            break;
                        case MemorizedTransactionListTransactionTypes.ElectronicPayee:
                            item.Type = TransactionType.ElectronicPayee;
                            break;
                        case MemorizedTransactionListTransactionTypes.Investment:
                            item.Type = TransactionType.Investment;
                            break;
                        case MemorizedTransactionListTransactionTypes.Payment:
                            item.Type = TransactionType.Payment;
                            break;
                    }
                    break;
                case MemorizedTransactionListFields.ClearedStatus:
                    item.ClearedStatus = value;
                    break;
                case MemorizedTransactionListFields.Memo:
                    item.Memo = value;
                    break;
                case MemorizedTransactionListFields.Payee:
                    item.Payee = value;
                    break;
                case MemorizedTransactionListFields.SplitAmount:
                    item.SplitAmounts.Add(item.SplitAmounts.Count, Common.GetDecimal(value));
                    break;
                case MemorizedTransactionListFields.SplitCategory:
                    item.SplitCategories.Add(item.SplitCategories.Count, value);
                    break;
                case MemorizedTransactionListFields.SplitMemo:
                    // NOTE: Using split amount count because memo is optional
                    item.SplitMemos.Add(item.SplitAmounts.Count, value);
                    break;
            }
        }
    }
}