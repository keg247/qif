using Keg247.Qif.Transactions;
using Keg247.Qif.Transactions.Fields;

namespace Keg247.Qif.Parsers
{
    class ClassListParser : IParser
    {
        private ClassListTransaction item = new ClassListTransaction();

        public void Yield(QifDocument document)
        {
            document.ClassListTransactions.Add(item);
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