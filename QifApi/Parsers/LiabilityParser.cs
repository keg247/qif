using Keg247.Qif.Transactions;

namespace Keg247.Qif.Parsers
{
    class LiabilityParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.LiabilityTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}