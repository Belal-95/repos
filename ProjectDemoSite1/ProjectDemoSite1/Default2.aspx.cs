using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RSN.Project.BLL;

public partial class Default2 : System.Web.UI.Page
{
    Student student = new Student();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        lblstatus.Text = string.Empty;
        if (!Page.IsPostBack)
        {
            BindStudents();
            BindStandards();

        }
    }

    void BindStudents()
    {
        DataSet dataSet = student.GetStudents();
        gvStudent.DataSource = dataSet.Tables[0];
        gvStudent.DataBind();
    }

    void BindStandards()
    {
        DataSet dataSet = student.GetStandards();

        //Create
        ddlStandard.DataSource = dataSet.Tables[0];
        ddlStandard.DataTextField = "StandardName";
        ddlStandard.DataValueField = "StandardId";
        ddlStandard.DataBind();
        ddlStandard.Items.Insert(0, new ListItem("Select", "0"));

       
    }

    protected void lnkBtnCreateNewStudent_Click(object sender, EventArgs e)
    {
        pnlCreateEdit.Visible = true;
        pnlCreateEdit.GroupingText = "Insert Student Details";
        btnSubmit.Text = "Save";
        PnlDetails.Visible = false;

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (btnSubmit.Text == "Save")
        {
            //Passing data to business logic via properties
            student.Name = txtName.Text.Trim();
            student.Address = txtAddress.Text.Trim();
            student.City = txtCity.Text.Trim();
            student.State = txtState.Text.Trim();
            student.PinCode = txtPinCode.Text.Trim();
            student.StandardId = int.Parse(ddlStandard.SelectedItem.Value);
        
        if (student.InsertStudentDetails() > 0)
        {
            ClearFields();

            BindStudents();

            txtName.Focus();
        }
        else
        {
            lblstatus.Text = "<br style='color:red'>Student Data Insertion faild !!!<br/>";
        }
    }
        else if (btnSubmit.Text == "Update")
        {
            student.StudentId = (int)ViewState["StudentId"];

            student.Name = txtName.Text.Trim();
            student.Address = txtAddress.Text.Trim();
            student.City = txtCity.Text.Trim();
            student.State = txtState.Text.Trim();
            student.PinCode = txtPinCode.Text.Trim();
            student.StandardId = int.Parse(ddlStandard.SelectedItem.Value);

            if (student.UpdateStuedentDetails() > 0)
            {

                BindStudents();
                lblstatus.Text = "<b style='color:green'>Student Details Updated Successfully!!!</b>";

            }
            else
            {
                lblstatus.Text = "<br style='color:red'>Student Details Updating faild !!!<br/>";
            }


        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlCreateEdit.Visible = false;
    }

    void ClearFields()
    {
        txtName.Text = txtAddress.Text = txtCity.Text = txtState.Text = txtPinCode.Text = string.Empty;
        ddlStandard.SelectedIndex = 0;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Passing data to business logic via properties
       
    }

    

    protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        pnlCreateEdit.Visible = PnlDetails.Visible = false;

        int studentId = int.Parse(e.CommandArgument.ToString());
        ViewState["StudentId"] = studentId;

        if (e.CommandName == "EditStudent")
        {
            DataSet dataSet = student.GetStudentDetails(studentId);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                pnlCreateEdit.Visible = true;
                pnlCreateEdit.GroupingText = "Update Student Details";
                btnSubmit.Text = "Update";
                PnlDetails.Visible = false;

                DataRow dataRow = dataSet.Tables[0].Rows[0];

                txtName.Text = dataRow["Name"].ToString();
                txtAddress.Text = dataRow["Address"].ToString();
                txtCity.Text = dataRow["City"].ToString();
                txtState.Text = dataRow["State"].ToString();
                txtPinCode.Text = dataRow["PinCode"].ToString();
                ddlStandard.SelectedIndex = ddlStandard.Items.IndexOf(ddlStandard.Items.FindByValue(dataRow["StandardId"].ToString()));

            }
        }

        else if (e.CommandName == "DeleteStudent")
        {
            if (student.DeleteStudentDetails(studentId) > 0)
            {
                BindStudents();
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('Student Details Deleted Successfully!!!')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('Student Details Deletion Failed!!! Please try again')</script>");
            }
        }

        else if (e.CommandName == "DetailsStudent")
        {
            DataSet dataSet = student.GetStudentDetails(studentId);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                PnlDetails.Visible = true;

                DataRow dataRow = dataSet.Tables[0].Rows[0];

                lblStudentId.Text = dataRow["StudentId"].ToString();
                lblName.Text = dataRow["Name"].ToString();
                lblAddress.Text = dataRow["Address"].ToString();
                lblCity.Text = dataRow["City"].ToString();
                lblState.Text = dataRow["State"].ToString();
                lblPinCode.Text = dataRow["PinCode"].ToString();
                lblStandard.Text = dataRow["StandardName"].ToString();
            }
        }
    }

    protected void btnCloseDetails_Click(object sender, EventArgs e)
    {
        PnlDetails.Visible = false;

    }
}