using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using To_DoListApp.Models;

namespace To_DoListApp
{
    public partial class Default1 : System.Web.UI.Page
    {
        private TodoContext db = new TodoContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new TodoItem
            {
                Title = txtTitle.Text,
                IsCompleted = false
            };
            db.TodoItems.Add(newItem);
            db.SaveChanges();
            BindGrid();
            txtTitle.Text = string.Empty;
        }

        private void BindGrid()
        {
            GridView1.DataSource = db.TodoItems.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            var item = db.TodoItems.Find(id);
            if (item != null)
            {
                db.TodoItems.Remove(item);
                db.SaveChanges();
            }
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            var item = db.TodoItems.Find(Id);
            if (item != null)
            {
                item.Title = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                item.IsCompleted=((CheckBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Checked;
                db.SaveChanges();
            }
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void chckStatus_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}