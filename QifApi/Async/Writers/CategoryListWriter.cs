﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Keg247.Qif.Transactions;
using Keg247.Qif.Transactions.Fields;

namespace Keg247.Qif.Writers
{
    using System.Threading.Tasks;
    static partial class CategoryListWriter
    {
        internal static async Task WriteAsync(TextWriter writer, ICollection<CategoryListTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                await (writer.WriteLineAsync(Headers.CategoryList)).ConfigureAwait(true);

                foreach (var item in list)
                {
                    await (writer.WriteAsync(CategoryListFields.BudgetAmount)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.BudgetAmount.ToString(CultureInfo.CurrentCulture))).ConfigureAwait(true);

                    if (!string.IsNullOrEmpty(item.CategoryName))
                    {
                        await (writer.WriteAsync(CategoryListFields.CategoryName)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.CategoryName)).ConfigureAwait(true);
                    }

                    if (!string.IsNullOrEmpty(item.Description))
                    {
                        await (writer.WriteAsync(CategoryListFields.Description)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Description)).ConfigureAwait(true);
                    }

                    await (writer.WriteAsync(CategoryListFields.ExpenseCategory)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.ExpenseCategory.ToString())).ConfigureAwait(true);

                    await (writer.WriteAsync(CategoryListFields.IncomeCategory)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.IncomeCategory.ToString())).ConfigureAwait(true);

                    await (writer.WriteAsync(CategoryListFields.TaxRelated)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.TaxRelated.ToString())).ConfigureAwait(true);

                    if (!string.IsNullOrEmpty(item.TaxSchedule))
                    {
                        await (writer.WriteAsync(CategoryListFields.TaxSchedule)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.TaxSchedule)).ConfigureAwait(true);
                    }

                    await (writer.WriteLineAsync(InformationFields.EndOfEntry)).ConfigureAwait(true);
                }
            }
        }
    }
}