using Keg247.Qif.Transactions;

namespace Keg247.Qif.Parsers
{
    class CreditCardParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.CreditCardTransactions.Add(Item); 
            Item = new BasicTransaction();
        }
    }
}