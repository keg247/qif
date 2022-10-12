using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    static partial class CategoryListWriter
    {
        internal static void Write(TextWriter writer, ICollection<CategoryListTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                writer.WriteLine(Headers.CategoryList);

                foreach (var item in list)
                {
                    writer.Write(CategoryListFields.BudgetAmount);
                    writer.WriteLine(item.BudgetAmount.ToString(CultureInfo.CurrentCulture));

                    if (!string.IsNullOrEmpty(item.CategoryName))
                    {
                        writer.Write(CategoryListFields.CategoryName);
                        writer.WriteLine(item.CategoryName);
                    }

                    if (!string.IsNullOrEmpty(item.Description))
                    {
                        writer.Write(CategoryListFields.Description);
                        writer.WriteLine(item.Description);
                    }

                    writer.Write(CategoryListFields.ExpenseCategory);
                    writer.WriteLine(item.ExpenseCategory.ToString());

                    writer.Write(CategoryListFields.IncomeCategory);
                    writer.WriteLine(item.IncomeCategory.ToString());

                    writer.Write(CategoryListFields.TaxRelated);
                    writer.WriteLine(item.TaxRelated.ToString());

                    if (!string.IsNullOrEmpty(item.TaxSchedule))
                    {
                        writer.Write(CategoryListFields.TaxSchedule);
                        writer.WriteLine(item.TaxSchedule);
                    }

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}