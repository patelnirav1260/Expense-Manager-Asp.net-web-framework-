using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Expense_manager
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                BindCategoriesGrid();
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
            }
        }

        private void BindCategoriesGrid()
        {
            using (var context = new ExpenseDbContext())
            {
                var categories = context.Categories.ToList();
                CategoryGridView.DataSource = categories;
                CategoryGridView.DataBind();
            }
        }

        protected void CategoryGridView_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            CategoryGridView.EditIndex = e.NewEditIndex;
            BindCategoriesGrid();
        }

        protected void CategoryGridView_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            CategoryGridView.EditIndex = -1;
            BindCategoriesGrid();
        }
        protected void btnNewCategory_Click(object sender, EventArgs e)
        {
            pnlNewCategory.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlNewCategory.Visible = false;
        }

        protected void CategoryGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = CategoryGridView.Rows[e.RowIndex];
            int categoryId = Convert.ToInt32(CategoryGridView.DataKeys[e.RowIndex].Value);
            string categoryName = ((TextBox)row.FindControl("txtCategoryName")).Text;

            using (var context = new ExpenseDbContext())
            {
                var category = context.Categories.Find(categoryId);
                if (category != null)
                {
                    category.CategoryName = categoryName;
                    context.SaveChanges();
                }
            }

            CategoryGridView.EditIndex = -1;
            BindCategoriesGrid();
        }


        protected void CategoryGridView_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int categoryId = Convert.ToInt32(CategoryGridView.DataKeys[e.RowIndex].Value);

            using (var context = new ExpenseDbContext())
            {
                var category = context.Categories.Find(categoryId);
                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }

            BindCategoriesGrid();
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategoryName = txtNewCategory.Text;

            using (var context = new ExpenseDbContext())
            {
                var newCategory = new Category { CategoryName = newCategoryName };
                context.Categories.Add(newCategory);
                context.SaveChanges();
            }

            BindCategoriesGrid();
            txtNewCategory.Text = string.Empty;
        }
    }
}