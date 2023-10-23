using System;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Expense_manager
{
    public partial class Transaction1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransactionsGrid();
                BindCategoryDropDown();
            }
        }
        protected void TransactionGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            TransactionGridView.EditIndex = e.NewEditIndex;
            BindTransactionsGrid();
            GridViewRow editRow = TransactionGridView.Rows[e.NewEditIndex];
            DropDownList ddlEditCategory = (DropDownList)editRow.FindControl("ddlEditCategory");
            BindCategoryDropDown(ddlEditCategory); 
        }

        private void BindCategoryDropDown(DropDownList ddl)
        {
            using (var context = new ExpenseDbContext())
            {
                var categories = context.Categories.ToList();
                ddl.DataSource = categories;
                ddl.DataBind();
            }
        }

        protected void TransactionGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            TransactionGridView.EditIndex = -1;
            BindTransactionsGrid();
        }

        protected void TransactionGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            GridViewRow row = TransactionGridView.Rows[e.RowIndex];
            int transactionId = Convert.ToInt32(TransactionGridView.DataKeys[e.RowIndex].Value);
            string description = ((TextBox)row.FindControl("txtDescription")).Text;
            decimal amount = Convert.ToDecimal(((TextBox)row.FindControl("txtAmount")).Text);
            string dateStr = ((TextBox)row.FindControl("txtDate")).Text;
            DateTime date;
            DateTime.TryParseExact(dateStr, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            DropDownList ddlEditCategory = (DropDownList)row.FindControl("ddlEditCategory");
            int categoryId = Convert.ToInt32(ddlEditCategory.SelectedValue); 

            using (var context = new ExpenseDbContext())
            {
                var transaction = context.Transactions.Find(transactionId);
                if (transaction != null)
                {
                    transaction.Description = description;
                    transaction.Amount = amount;
                    transaction.Date = date;
                    transaction.CategoryID = categoryId; 
                    context.SaveChanges();
                }
            }

            TransactionGridView.EditIndex = -1;
            BindTransactionsGrid();
        }


        protected void TransactionGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int transactionId = Convert.ToInt32(TransactionGridView.DataKeys[e.RowIndex].Value);

            using (var context = new ExpenseDbContext())
            {
                var transaction = context.Transactions.Find(transactionId);
                if (transaction != null)
                {
                    context.Transactions.Remove(transaction);
                    context.SaveChanges();
                }
            }

            BindTransactionsGrid();
        }

        private void BindTransactionsGrid()
        {
            using (var context = new ExpenseDbContext())
            {
                var transactions = context.Transactions.Include("Category").ToList();
                TransactionGridView.DataSource = transactions;
                TransactionGridView.DataBind();
            }
            BindCategoryDropDown();
        }
 private void BindCategoryDropDown()
{
    using (var context = new ExpenseDbContext())
    {
        var categories = context.Categories.ToList();
        ddlCategory.DataSource = categories;
        ddlCategory.DataBind();
    }
}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            pnlNewTransaction.Visible = true;
            btnAddTransaction.Visible = false;
        }

        protected void btnAddTransaction_Click(object sender, EventArgs e)
        {
            string description = txtNewDescription.Text;
            decimal amount;
            DateTime date;

            if (decimal.TryParse(txtNewAmount.Text, out amount) && DateTime.TryParse(txtNewDate.Text, out date))
            {
                int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);

                using (var context = new ExpenseDbContext())
                {
                    var newTransaction = new Transaction
                    {
                        Description = description,
                        Amount = amount,
                        Date = date,
                        CategoryID = categoryId,
                    };

                    context.Transactions.Add(newTransaction);
                    context.SaveChanges();
                }

                BindTransactionsGrid();
                txtNewDescription.Text = string.Empty;
                txtNewAmount.Text = string.Empty;
                txtNewDate.Text = string.Empty;

            }
            else
            {
                lblMessage.Text = "Please enter valid values for Amount and Date.";
                lblMessage.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlNewTransaction.Visible = false;
            btnAddTransaction.Visible = true;
        }
    }
}
