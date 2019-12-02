using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E324
{
    public partial class Default : System.Web.UI.Page
    {
        List<Record> list = new List<Record>();
        protected void Page_Load(object sender, EventArgs e)
        {
            int start = ASPxGridView1.PageIndex * ASPxGridView1.SettingsPager.PageSize;
            int end = (ASPxGridView1.PageIndex + 1) * ASPxGridView1.SettingsPager.PageSize;
            GridViewDataColumn column1 = ASPxGridView1.Columns["CategoryName"] as GridViewDataColumn;
            GridViewDataColumn column2 = ASPxGridView1.Columns["Description"] as GridViewDataColumn;
            for (int i = start; i < end; i++)
            {
                ASPxTextBox txtBox1 = (ASPxTextBox)ASPxGridView1.FindRowCellTemplateControl(i, column1, "txtBox");
                ASPxTextBox txtBox2 = (ASPxTextBox)ASPxGridView1.FindRowCellTemplateControl(i, column2, "txtBox");
                if (txtBox1 == null || txtBox2 == null)
                    continue;
                int id = Convert.ToInt32(ASPxGridView1.GetRowValues(i, ASPxGridView1.KeyFieldName));
                list.Add(new Record(id, txtBox1.Text, txtBox2.Text));
            }
        }

        protected void ASPxGridView1_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "post")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    AccessDataSource1.UpdateParameters["CategoryName"].DefaultValue = list[i].CategoryName;
                    AccessDataSource1.UpdateParameters["Description"].DefaultValue = list[i].Description;
                    AccessDataSource1.UpdateParameters["CategoryID"].DefaultValue = list[i].Id.ToString();
                    //AccessDataSource1.Update();  //Uncomment this line to update data!
                }
                ASPxGridView1.DataBind();
            }
        }
    }
}