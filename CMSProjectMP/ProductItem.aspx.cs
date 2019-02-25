using CMSProjectMP.App_Code;
using System;
using System.Collections;
using System.Text;

namespace CMSProjectMP
{
    public partial class ProductItem : System.Web.UI.Page
    {

        //public int id { get; set; }
        //public string name { get; set; }
        //public string type { get; set; }
        //public int price { get; set; }
        //public string description { get; set; }
        //public string image { get; set; }
        //public int selectionid { get; set; }
        ////public int id;
        ////public string name;
        ////public string type;
        ////public int price;
        ////public string description;
        ////public string image;
        ////public int selectionid;

        //public Item(int id, string name, string type, int price, string description, string image, int selectionid)
        //{
        //    this.id = id;
        //    this.name = name;
        //    this.type = type;
        //    this.price = price;
        //    this.description = description;
        //    this.image = image;
        //    this.selectionid = selectionid;
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();            
        }
        public void FillPage()
        {
            ArrayList itemList = ConnectionClass.GetItemByType(!IsPostBack ? "%" : DropDownList1.SelectedValue);
            StringBuilder sb = new StringBuilder();
            
            foreach (Item item in itemList)
            {
                sb.Append(
                    string.Format(

                     @"<table class='coffeeTable'>
                          <tr>
                             <th width='50px'>id: </th>
                             <td>{0}</td>
                         </tr>

                         <tr>
                             <th width='50px'>Name: </th>
                             <td>{1}</td>
                         </tr>
                         <tr>
                             <th>Type: </th>
                             <td>{2}</td>
                         </tr>

                         <tr>
                             <th>Price: </th>
                             <td>{3} $</td>
                         </tr>

                         <tr>
                             <th>Description: </th>
                             <td>{4}</td>
                         </tr>

                         <tr>
                             <th>SelectionId: </th>
                             <td>{6}</td>
                         </tr>

                         <tr>
                             <th rowspan='6' width='150px'>Image:</th>
                             <td><img runat='server' src='{5}' /> </td>

                         </tr>

                         ////<tr>
                         ////    <td colspan='2'>{6}</td>
                         ////</tr>           

                        </table>", item.id, item.name, item.type, item.price, item.description, item.image, item.selectionid));
                lblOutput.Text = sb.ToString();

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPage();
        }
    }
}