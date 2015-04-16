using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
{
    internal class CreditCardParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.CreditCardTransactions.Add(Item); 
            Item = new BasicTransaction();
        }
    }
}