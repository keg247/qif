using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using QifApi.Parsers;
using QifApi.Transactions;
using QifApi.Transactions.Fields;
using QifApi.Writers;

namespace QifApi
{
    /// <summary>
    /// Represents a Document Object Model for a QIF file.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    public class QifDom
    {
        /// <summary>
        /// Represents a collection of bank transactions.
        /// </summary>
        public List<BasicTransaction> BankTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Represents a collection of cash transactions.
        /// </summary>
        public List<BasicTransaction> CashTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Represents a collection of credit card transactions.
        /// </summary>
        public List<BasicTransaction> CreditCardTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Represents a collection of investment transactions.
        /// </summary>
        public List<InvestmentTransaction> InvestmentTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Represents a collection of asset transactions.
        /// </summary>
        public List<BasicTransaction> AssetTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Represents a collection of liability transactions.
        /// </summary>
        public List<BasicTransaction> LiabilityTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Represents a collection of account list transactions.
        /// </summary>
        public List<AccountListTransaction> AccountListTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Represents a collection of category list transactions.
        /// </summary>
        public List<CategoryListTransaction> CategoryListTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Represents a collection of class list transactions.
        /// </summary>
        public List<ClassListTransaction> ClassListTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Represents a collection of memorized transaction list transactions.
        /// </summary>
        public List<MemorizedTransactionListTransaction> MemorizedTransactionListTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new QIF DOM.
        /// </summary>
        public QifDom()
        {
            BankTransactions = new List<BasicTransaction>();
            CashTransactions = new List<BasicTransaction>();
            CreditCardTransactions = new List<BasicTransaction>();
            InvestmentTransactions = new List<InvestmentTransaction>();
            AssetTransactions = new List<BasicTransaction>();
            LiabilityTransactions = new List<BasicTransaction>();
            AccountListTransactions = new List<AccountListTransaction>();
            CategoryListTransactions = new List<CategoryListTransaction>();
            ClassListTransactions = new List<ClassListTransaction>();
            MemorizedTransactionListTransactions = new List<MemorizedTransactionListTransaction>();
        }

        /// <summary>
        /// Imports the specified file and replaces the current instance properties with details found in the import file.
        /// </summary>
        /// <param name="fileName">Name of the file to import.</param>
        public void Import(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                Import(reader);
            }
        }

        /// <summary>
        /// Imports a stream in a QIF format and replaces the current instance properties with details found in the import stream.
        /// </summary>
        /// <param name="reader">The import reader stream.</param>
        public void Import(TextReader reader)
        {
            QifDom import = ImportFile(reader);

            this.AccountListTransactions = import.AccountListTransactions;
            this.AssetTransactions = import.AssetTransactions;
            this.BankTransactions = import.BankTransactions;
            this.CashTransactions = import.CashTransactions;
            this.CategoryListTransactions = import.CategoryListTransactions;
            this.ClassListTransactions = import.ClassListTransactions;
            this.CreditCardTransactions = import.CreditCardTransactions;
            this.InvestmentTransactions = import.InvestmentTransactions;
            this.LiabilityTransactions = import.LiabilityTransactions;
            this.MemorizedTransactionListTransactions = import.MemorizedTransactionListTransactions;
        }

        /// <summary>
        /// Exports the current instance properties to the specified file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <remarks>This will overwrite an existing file.</remarks>
        public void Export(string fileName)
        {
            ExportFile(this, fileName);
        }

        /// <summary>
        /// Exports the specified instance properties to the specified file.
        /// </summary>
        /// <param name="qif">The <seealso cref="T:QifDom"/> to export.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <remarks>This will overwrite an existing file.</remarks>
        public static void ExportFile(QifDom qif, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.SetAttributes(fileName, FileAttributes.Normal);
            }

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.AutoFlush = true;

                AccountListWriter.Write(writer, qif.AccountListTransactions);
                BasicTransactionWriter.Write(writer, Headers.Asset, qif.AssetTransactions);
                BasicTransactionWriter.Write(writer, Headers.Bank, qif.BankTransactions);
                BasicTransactionWriter.Write(writer, Headers.Cash, qif.CashTransactions);
                BasicTransactionWriter.Write(writer, Headers.CreditCard, qif.CreditCardTransactions);
                BasicTransactionWriter.Write(writer, Headers.Liability, qif.LiabilityTransactions);
                CategoryListWriter.Write(writer, qif.CategoryListTransactions);
                ClassListWriter.Write(writer, qif.ClassListTransactions);
                InvestmentWriter.Write(writer, qif.InvestmentTransactions);
                MemorizedTransactionListWriter.Write(writer, qif.MemorizedTransactionListTransactions);
            }
        }

        /// <summary>
        /// Imports a QIF file and returns a QifDom object.
        /// </summary>
        /// <param name="fileName">The QIF file to import.</param>
        /// <returns>A QifDom object of transactions imported.</returns>
        public static QifDom ImportFile(string fileName)
        {
            QifDom result;

            // If the file doesn't exist
            if (File.Exists(fileName) == false)
            {
                // Identify the file doesn't exist
                throw new FileNotFoundException();
            }

            // Open the file
            using (StreamReader sr = new StreamReader(fileName))
            {
                result = ImportFile(sr);
            }

            return result;
        }

        /// <summary>
        /// Imports a QIF file stream reader and returns a QifDom object.
        /// </summary>
        /// <param name="reader">The stream reader pointing to an underlying QIF file to import.</param>
        /// <returns>A QifDom object of transactions imported.</returns>
        public static QifDom ImportFile(TextReader reader)
        {
            QifDom result = new QifDom();

            string line;
            IParser parser = null;
            while ((line = reader.ReadLine()) != null)
            {
                switch (line[0])
                {
                    case InformationFields.TransactionType:
                        parser = CreateParser(line);
                        break;
                    case InformationFields.EndOfEntry:
                        Debug.Assert(parser != null, "parser != null");
                        parser.Yield(result);
                        break;
                    default:
                        Debug.Assert(parser != null, "parser != null");
                        parser.ParseLine(line);
                        break;
                }
            }

            return result;
        }

        private static IParser CreateParser(string line)
        {
            switch (line)
            {
                case Headers.Bank  :
                    return new BankParser();
                case Headers.Cash:
                    return new CashParser();
                case Headers.CreditCard:
                    return new CreditCardParser();
                case Headers.Investment:
                    return new InvestmentParser();
                case Headers.Asset:
                    return new AssetParser();
                case Headers.Liability:
                    return new LiabilityParser();
                case Headers.AccountList:
                    return new AccountListParser();
                case Headers.CategoryList:
                    return new CategoryListParser();
                case Headers.ClassList:
                    return new ClassListParser();
                case Headers.MemorizedTransactionList:
                    return new MemorizedTransactionListParser();

                default:
                    throw new NotSupportedException("The transaction type '" + line + "' is not supported");
            }
        }
    }
}
