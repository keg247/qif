using QifApi.Transactions;
using QifApi.Transactions.Fields;

namespace QifApi.Parsers
{
    internal abstract class BasicTransactionParser : IParser
    {
        protected BasicTransaction Item = new BasicTransaction();

        public abstract void Yield(QifDocument document);

        public virtual void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case NonInvestmentAccountFields.Date:
                    Item.Date = Common.GetDateTime(value);
                    break;
                case NonInvestmentAccountFields.Amount:
                    Item.Amount = Common.GetDecimal(value);
                    break;
                case NonInvestmentAccountFields.ClearedStatus:
                    Item.ClearedStatus = value;
                    break;
                case NonInvestmentAccountFields.Number:
                    Item.Number = value;
                    break;
                case NonInvestmentAccountFields.Payee:
                    Item.Payee = value;
                    break;
                case NonInvestmentAccountFields.Memo:
                    Item.Memo = value;
                    break;
                case NonInvestmentAccountFields.Category:
                    Item.Category = value;
                    break;
                case NonInvestmentAccountFields.Address:
                    Item.Address.Add(value);
                    break;
                case NonInvestmentAccountFields.SplitCategory:
                    Item.SplitCategories.Add(Item.SplitCategories.Count, value);
                    break;
                case NonInvestmentAccountFields.SplitMemo:
                    // NOTE: I use split amount count because memos are optional
                    Item.SplitMemos.Add(Item.SplitAmounts.Count, value);
                    break;
                case NonInvestmentAccountFields.SplitAmount:
                    Item.SplitAmounts.Add(Item.SplitAmounts.Count, Common.GetDecimal(value));
                    break;
            }
        }
    }
}