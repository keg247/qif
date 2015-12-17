using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
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