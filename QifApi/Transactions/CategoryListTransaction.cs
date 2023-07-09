
namespace Hazzik.Qif.Transactions
{
    /// <summary>
    /// A category list transaction.
    /// </summary>
    public class CategoryListTransaction : TransactionBase
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>The name of the category.</value>
        public string CategoryName { get; set; } = "";

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether the item is tax related.
        /// </summary>
        /// <value><c>true</c> if tax related; otherwise, <c>false</c>.</value>
        public bool TaxRelated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is an income category.
        /// </summary>
        /// <value><c>true</c> if income category; otherwise, <c>false</c>.</value>
        public bool IncomeCategory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is an expense category. Set to true
        /// by default so that a category defaults to being an Expense category if the type is not 
        /// defined in the file, which is how Quicken handles QIF files.
        /// </summary>
        /// <value><c>true</c> if expense category; otherwise, <c>false</c>.</value>
        public bool ExpenseCategory { get; set; } = true;

        /// <summary>
        /// Gets or sets the budget amount.
        /// </summary>
        /// <value>The budget amount.</value>
        public decimal BudgetAmount { get; set; }

        /// <summary>
        /// Gets or sets the tax schedule.
        /// </summary>
        /// <value>The tax schedule.</value>
        public string TaxSchedule { get; set; } = "";

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return CategoryName;
        }
    }
}
