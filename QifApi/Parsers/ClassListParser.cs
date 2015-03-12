using QifApi.Transactions;
using QifApi.Transactions.Fields;

namespace QifApi.Parsers
{
    internal class ClassListParser : IParser
    {
        private ClassListTransaction item = new ClassListTransaction();

        public void Yield(QifDom dom)
        {
            dom.ClassListTransactions.Add(item);
            item = new ClassListTransaction();
        }

        public void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case ClassListFields.ClassName:
                    item.ClassName = value;
                    break;
                case ClassListFields.Description:
                    item.Description = value;
                    break;
            }
        }
    }
}