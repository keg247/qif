using QifApi.Transactions;

namespace QifApi.Parsers
{
    internal class CreditCardParser : BasicTransactionParser
    {
        public override void Yield(QifDom dom)
        {
            dom.CreditCardTransactions.Add(Item); 
            Item = new BasicTransaction();
        }
    }
}