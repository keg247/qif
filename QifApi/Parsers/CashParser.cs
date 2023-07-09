using Keg247.Qif.Transactions;

namespace Keg247.Qif.Parsers
{
    class CashParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.CashTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}