using Keg247.Qif.Transactions;

namespace Keg247.Qif.Parsers
{
    class BankParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.BankTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}