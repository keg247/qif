﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Hazzik.Qif.Parsers;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;
using Hazzik.Qif.Writers;

namespace Hazzik.Qif
{
    /// <summary>
    /// Represents a Document Object Model for a QIF file.
    /// </summary>
    public partial class QifDocument
    {
        /// <summary>
        /// Represents a collection of bank transactions.
        /// </summary>
        public IList<BasicTransaction> BankTransactions { get; } = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of cash transactions.
        /// </summary>
        public IList<BasicTransaction> CashTransactions { get; } = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of credit card transactions.
        /// </summary>
        public IList<BasicTransaction> CreditCardTransactions { get; } = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of investment transactions.
        /// </summary>
        public IList<InvestmentTransaction> InvestmentTransactions { get; } = new List<InvestmentTransaction>();

        /// <summary>
        /// Represents a collection of asset transactions.
        /// </summary>
        public IList<BasicTransaction> AssetTransactions { get; } = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of liability transactions.
        /// </summary>
        public IList<BasicTransaction> LiabilityTransactions { get; } = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of account list transactions.
        /// </summary>
        public IList<AccountListTransaction> AccountListTransactions { get; } = new List<AccountListTransaction>();

        /// <summary>
        /// Represents a collection of category list transactions.
        /// </summary>
        public IList<CategoryListTransaction> CategoryListTransactions { get; } = new List<CategoryListTransaction>();

        /// <summary>
        /// Represents a collection of class list transactions.
        /// </summary>
        public IList<ClassListTransaction> ClassListTransactions { get; } = new List<ClassListTransaction>();

        /// <summary>
        /// Represents a collection of memorized transaction list transactions.
        /// </summary>
        public IList<MemorizedTransactionListTransaction> MemorizedTransactionListTransactions { get; } = new List<MemorizedTransactionListTransaction>();

        /// <summary>
        /// Saves the QIF document to the <see cref="Stream"/>.
        /// </summary>
        public void Save(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                Save(writer);
            }
        }

        /// <summary>
        /// Exports the QIF document to the <see cref="TextWriter"/>.
        /// </summary>
        public void Save(TextWriter writer)
        {
            AccountListWriter.Write(writer, AccountListTransactions);
            BasicTransactionWriter.Write(writer, Headers.Asset, AssetTransactions);
            BasicTransactionWriter.Write(writer, Headers.Bank, BankTransactions);
            BasicTransactionWriter.Write(writer, Headers.Cash, CashTransactions);
            BasicTransactionWriter.Write(writer, Headers.CreditCard, CreditCardTransactions);
            BasicTransactionWriter.Write(writer, Headers.Liability, LiabilityTransactions);
            CategoryListWriter.Write(writer, CategoryListTransactions);
            ClassListWriter.Write(writer, ClassListTransactions);
            InvestmentWriter.Write(writer, InvestmentTransactions);
            MemorizedTransactionListWriter.Write(writer, MemorizedTransactionListTransactions);
        }

        /// <summary>
        /// Returns a string representation of the QIF document.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            using (var writer = new StringWriter())
            {
                Save(writer);
                return writer.ToString();
            }
        }

        /// <summary>
        /// Parses a QIF document from the specified <see cref="String"/>.
        /// </summary>
        /// <param name="text">The text representation of QIF file to parse.</param>
        /// <returns>A QifDocument object of transactions imported.</returns>
        public static QifDocument Parse(string text)
        {
            using (var reader = new StringReader(text))
            {
                return Load(reader);
            }
        }

        /// <summary>
        /// Loads a QIF document from the specified <see cref="Stream"/>
        /// </summary>
        /// <param name="stream">The stream pointing to an underlying QIF file to load.</param>
        /// <returns>A QifDocument object of transactions imported.</returns>
        public static QifDocument Load(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return Load(reader);
            }
        }

        /// <summary>
        /// Loads a QIF document from the specified <see cref="TextReader"/>
        /// </summary>
        /// <param name="reader">The text reader pointing to an underlying QIF file to load.</param>
        /// <returns>A QifDocument object of transactions imported.</returns>
        public static QifDocument Load(TextReader reader)
        {
            var result = new QifDocument();

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
