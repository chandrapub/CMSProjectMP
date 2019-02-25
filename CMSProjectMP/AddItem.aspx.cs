
using CMSProjectMP.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CMSProjectMP
{
    public partial class AddItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedValue = ddlImage.SelectedValue;
            ShowImages();
            ddlImage.SelectedValue = selectedValue;
        }
        private void ShowImages()
        {
            string[] images = Directory.GetFiles(Server.MapPath("~/Images/"));

            //Get all filenames and add them to an arraylist
            ArrayList imageList = new ArrayList();

            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\") + 1);
                imageList.Add(imageName);
            }

            //Set the arrayList as the dropdownview's datasource and refresh
            ddlImage.DataSource = imageList;
            ddlImage.DataBind();
        }

        private void ClearTextFields()
        {
            //txtItemId.Text = "";
            txtItemName.Text = "";
            txtCategoryName.Text = "";
            txtPrice.Text = "";
            txtImage.Text = "";
            txtDescription.Text = "";
            txtSelectionId.Text = "";
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Images/") + filename);
                lblResult.Text = "Image " + filename + " succesfully uploaded!";
                Page_Load(sender, e);
            }
            catch (Exception)
            {
                lblResult.Text = "Upload failed!";
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //int id = Convert.ToInt32(txtItemId.Text);
                string name = txtItemName.Text;
                string type = txtCategoryName.Text;

                int price = Convert.ToInt32(txtPrice.Text);
                //price = price / 100;
                //string roast = txtRoast.Text;
                //string country = txtCountry.Text;
                string image = "/Images/" + ddlImage.SelectedValue;
                string description = txtDescription.Text;
                int selectionId = Convert.ToInt32(txtSelectionId.Text);
                
                    
                Item item = new Item(name, type, price, image, description, selectionId);
                ConnectionClass.AddItem(item);
                lblResult.Text = "Upload succesful!";
                ClearTextFields();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                lblResult.Text = "Upload failed!";
            }
        }
}}