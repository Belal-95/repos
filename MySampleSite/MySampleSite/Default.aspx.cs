using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FAR.Project.BLL;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    Student student = new Student();

    protected void Page_Load(object sender, EventArgs e)
    {
        // for jQuery ..........
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        if(!IsPostBack)
        {  
            BindStudents();
            BindStandards();
        }
    }

    private void BindStudents()
    {
        DataSet dataSet = student.GetAllStudents();
        gvStudent.DataSource = dataSet.Tables[0];
        gvStudent.DataBind();


    }

    private void BindStandards()
    {
        
        DataSet dataSet = student.GetStandards();
        //Create
        ddlGrad.DataSource = dataSet.Tables[0];
        ddlGrad.DataTextField = "TeacherName";
        ddlGrad.DataValueField = "Grad";
        ddlGrad.DataBind();
        ddlGrad.Items.Insert(0, new ListItem( "Select", "0" ));

        //Edit
        ddlEGrad.DataSource = dataSet.Tables[0];
        ddlEGrad.DataTextField = "TeacherName";
        ddlEGrad.DataValueField = "Grad";
        ddlEGrad.DataBind();
        
       
    }

    protected void lnkBtnCreateNewStudent_Click(object sender, EventArgs e)
    {
        pnlEdit.Visible = pnlDetails.Visible = false;

        pnlCreate.Visible = true;
    }

    protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        pnlEdit.Visible = pnlCreate.Visible = pnlDetails.Visible = false;

        int studentId = int.Parse(e.CommandArgument.ToString());
        ViewState["StudentId"]= studentId;

        if(e.CommandName == "EditStudent")
        {
            DataSet dataSet = student.GetStudentDetails(studentId);
            if(dataSet.Tables[0].Rows.Count >0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];

                txtEditName.Text = dataRow["Name"].ToString();
                txtEditAddress.Text = dataRow["Address"].ToString();
                txtEditPhonNo.Text = dataRow["PhoneNumber"].ToString();
                txtEditFamilyNo.Text = dataRow["FamilyNumber"].ToString();
                ddlEGrad.SelectedIndex = ddlEGrad.Items.IndexOf(ddlEGrad.Items.FindByValue(dataRow["Grad"].ToString()));


                pnlEdit.Visible = true;

            }
        }
        else if (e.CommandName == "DetailsStudent")
        {
            DataSet dataSet = student.GetStudentDetails(studentId);
            if(dataSet.Tables[0].Rows.Count >0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];

                lblStudent.Text = dataRow["StudentId"].ToString();
                lblName.Text = dataRow["Name"].ToString();
                lblAddress.Text = dataRow["Address"].ToString();
                lblPhonNo.Text = dataRow["PhoneNumber"].ToString();
                lblFamilyNo.Text = dataRow["FamilyNumber"].ToString();
                lblGrad.Text = dataRow["Grad"].ToString();

                pnlDetails.Visible = true;
            }
         }

        else if (e.CommandName == "DeleteStudent")
        {
            if(student.DeleteStudent(studentId)>0)
            {
                BindStudents();
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('Student Details successfully Deleted')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('Student Details Deletion Failed!!  Please try again')</script>");
            }
        }

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlCreate.Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        student.Name = txtName.Text.Trim();
        student.Address = txtAddress.Text;
        student.PhoneNumber = txtPhoneNo.Text;
        student.FamilyNumber = txtFamilyNo.Text;
        student.Grad =int.Parse(ddlGrad.SelectedItem.Value);

       if( student.InsertStudentDetails() >0)
        {
            ClearFields();

            BindStudents();

            lblStatus.Text = "<br style='color:green'>Stuedent details is Successfully Inserted<br />";
        }
       else
            lblStatus.Text = "<br style='color:red'>Stuedent details is Fail to Insert<br />";
    }

    private void ClearFields()
    {
        txtAddress.Text = txtFamilyNo.Text = txtName.Text = txtPhoneNo.Text = string.Empty;
        ddlGrad.SelectedIndex = 0;
    }

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        student.StudentId = (int)ViewState["StudentId"];

        student.Name = txtEditName.Text;
        student.Address = txtEditAddress.Text;
        student.PhoneNumber = txtEditPhonNo.Text;
        student.FamilyNumber = txtEditFamilyNo.Text;
        student.Grad =int.Parse( ddlEGrad.SelectedValue);

        if(student.UpdateStudentDetails() >0)
        {
            BindStudents();
            lblEditStatus.Text = "<b style='color:green'>Student Details Updated Successfully</b>";
        }
        else
        {
            lblEditStatus.Text = "<b style='color:red'>Student Details Updation Failed</b>";
        }
    }

    protected void btnEditClose_Click(object sender, EventArgs e)
    {
        pnlEdit.Visible = false;
    }


    protected void btnDetailsClose_Click(object sender, EventArgs e)
    {
        pnlDetails.Visible = false;
    }
}