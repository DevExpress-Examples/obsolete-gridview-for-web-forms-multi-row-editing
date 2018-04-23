using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Record {
    int id;
    string categoryName;

    string description;

	public Record(int id, string categoryName, string description) {
        this.id = id;
        this.categoryName = categoryName;
        this.description = description;
	}
    public int Id { get { return this.id; } }
    public string CategoryName { get { return categoryName; } }
    public string Description { get { return description; } }

}
