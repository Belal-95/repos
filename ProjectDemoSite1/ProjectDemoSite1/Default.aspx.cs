using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RSN.Project.BLL;

public partial class _Default : System.Web.UI.Page
{
    Student student = new Student();

    protected void Page_Load(object sender, EventArgs e)
    {
        // for jQuery ..........
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        if (!IsPostBack)
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

        //Edit
        ddlEStandard.DataSource = dataSet.Tables[0];
        ddlEStandard.DataTextField = "StandardName";
        ddlEStandard.DataValueField = "StandardId";
        ddlEStandard.DataBind();
    }

    protected void lnkBtnCreateNewStudent_Click(object sender, EventArgs e)
    {
        pnlCreate.Visible = true;
        pnlEdit.Visible = false;
        PnlDetails.Visible = false;

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
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

    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlCreate.Visible = false;
    }

    void ClearFields()
    {
        txtName.Text = txtAddress.Text = txtCity.Text = txtState.Text = txtPinCode.Text = string.Empty;
        ddlStandard.SelectedIndex = 0;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Passing data to business logic via properties
        student.StudentId = (int)ViewState["StudentId"];

        student.Name = txtEName.Text.Trim();
        student.Address = txtEAddress.Text.Trim();
        student.City = txtECity.Text.Trim();
        student.State = txtEState.Text.Trim();
        student.PinCode = txtEPinCode.Text.Trim();
        student.StandardId = int.Parse(ddlEStandard.SelectedItem.Value);

        if (student.UpdateStuedentDetails() > 0)
        {

            BindStudents();
            lblEditStatus.Text = "<b style='color:green'>Student Details Updated Successfully!!!</b>";

        }
        else
        {
            lblstatus.Text = "<br style='color:red'>Student Details Updating faild !!!<br/>";
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlEdit.Visible = false;
    }

    protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        pnlCreate.Visible = pnlEdit.Visible = PnlDetails.Visible= false;

        int studentId = int.Parse(e.CommandArgument.ToString());
        ViewState["StudentId"] = studentId;

        if (e.CommandName == "EditStudent")
        {
            DataSet dataSet = student.GetStudentDetails(studentId);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                pnlEdit.Visible = true;
                pnlCreate.Visible = false;
                PnlDetails.Visible = false;

                DataRow dataRow = dataSet.Tables[0].Rows[0];

                txtEName.Text = dataRow["Name"].ToString();
                txtEAddress.Text = dataRow["Address"].ToString();
                txtECity.Text = dataRow["City"].ToString();
                txtEState.Text = dataRow["State"].ToString();
                txtEPinCode.Text = dataRow["PinCode"].ToString();
                ddlEStandard.SelectedIndex = ddlEStandard.Items.IndexOf(ddlEStandard.Items.FindByValue(dataRow["StandardId"].ToString()));

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