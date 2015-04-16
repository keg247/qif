using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
{
    internal class LiabilityParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.LiabilityTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}