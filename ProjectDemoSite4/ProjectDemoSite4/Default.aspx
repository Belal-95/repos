<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        $(document).ready(function () {
            //$.ajax({
            //    type: "POST",
            //    contentType: "application/json; charset=utf-8",
            //    url: "http://localhost:6178/StudentWebService.asmx/GetStudents",
            //    dataType: "json",
            //    success: function (response) {
            //        var students = response.d;

            //        var data = "<table width='100%' border='1' style='border-collapse:collapse'><tr><th>Student Id</th><th>Name</th><th>Address</th><th>City</th><th>State</th><th>Pin Code</th><th>Standard Name</th><th>Action</th></tr>";

            //        for (var index = 0; index < students.length; index++) {
            //            data += "<tr><td>" + students[index].StudentId + "</td>" + "<td>" + students[index].Name + "</td>" + "<td>" + students[index].Address + "</td>" + "<td>" + students[index].City + "</td>" + "<td>" + students[index].State + "</td>" + "<td>" + students[index].PinCode + "</td>" + "<td>" + students[index].StandardNamea + "</td>" + "<td><input type='button' value='Edit'/>&nbsp;<input type='button' value='Delete'/>&nbsp;<input type='button' value='Details'/></td></tr>";
            //        }
            //        data += "</table>";

            //        $("#divStudents").html(data);
            //    },
            //    error: function (error) {
            //        alert(error.statusText);
            //    }
            //});

            function StudentList() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "http://localhost:6178/StudentWebService.asmx/GetStudents",
                    dataType: "json",
                    success: function (response) {
                        var students = response.d;

                        //+ index + "</td><td style='display:none'>"


                        var data = "<table width='100%' border='1' style='border-collapse:collapse'><tr><th>Student Id</th><th>Name</th><th>Address</th><th>City</th><th>State</th><th>Pin Code</th><th>Standard Name</th><th>Action</th></tr>";
                        //-- + index + "</td><td style='display:none'>" -- this code in the code below is for making the student id appears from one forward
                        for (var index = 1; index < students.length; index++) {
                            data += "<tr><td>" + students[index].StudentId + "</td>" + "<td>" + students[index].Name + "</td>" + "<td>" + students[index].Address + "</td>" + "<td>" + students[index].City + "</td>" + "<td>" + students[index].State + "</td>" + "<td>" + students[index].PinCode + "</td>" + "<td>" + students[index].StandardNamea + "</td>" + "<td><input type='button' value='Edit' name='SEdit' id='" + students[index].StudentId + "' />&nbsp; <input type='button' value='Delete' name='SDelete' id='" + students[index].StudentId + "' /> &nbsp; <input type='button' value='Details' name='SDetails' id='" + students[index].StudentId + "' /></td ></tr > ";
                        }
                        data += "</table>";

                        $('#divStudents').html(data);

                        //  StandardList($("#ddlStandard"));
                        StandardList($("#ddlEStandard"));

                        $("input:button[name='SEdit']").click(function () {
                            $("#divEdit").show();
                            $("#divCreate").hide();

                            var studentId = $(this).attr("id");
                            $("#hidden1").val(studentId);

                            // StandardList($("#ddlEStandard")); //Bind Standard in DropDownList

                            $.ajax({
                                type: "POST",
                                contentType: "application/json;charset=utf-8",
                                url: "http://localhost:6178/StudentWebService.asmx/GetStudentDetails",
                                data: "{ studentId:" + studentId + "}",
                                dataType: "json",
                                success: function (response) {
                                    var data = response.d;
                                    if (data != null) {
                                        $("#txtEName").val(data.Name);
                                        $("#txtEAddress").val(data.Address);
                                        $("#txtECity").val(data.City);
                                        $("#txtEState").val(data.State);
                                        $("#txtEPinCode").val(data.PinCode);
                                        $("#ddlEStandard").val(data.StandardId);

                                    }
                                },
                                error: function (error) {
                                    alert(error.statusText);
                                }
                            });

                        });





                        $("input:button[name='SDelete']").click(function () {
                            var studentId = ($(this).attr("id"));

                            if (confirm("Are you sure? Do you want to delete student details?"))

                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "http://localhost:6178/StudentWebService.asmx/DeleteStudentDetails",
                                    data: "{ 'studentId':" + studentId + "}",
                                    dataType: "json",
                                    success: function (response) {
                                        var result = response.d;
                                        if (result > 0) {
                                            alert("Students Details Deleted Successfully!!!");
                                            StudentList();

                                        }
                                        else {
                                            alert("Student Details deleted Failed!!!");
                                        }
                                    },

                                    error: function (error) {
                                        alert(error.statusText);

                                    }
                                });
                        });


                        $("input:button[name='SDetails']").click(function () {
                            $("#divDetails").show();
                            $("#divCreate, #divEdit").hide();
                            var studentId = $(this).attr("id");
                            $.ajax({
                                type: "POST",
                                contentType: "application/json;charset=utf-8",
                                url: "http://localhost:6178/StudentWebService.asmx/GetStudentDetails",
                                data: "{ studentId:" + studentId + "}",
                                dataType: "json",
                                success: function (response) {
                                    var data = response.d;
                                    if (data != null) {
                                        $("#spanStudentId").html(data.studentId);
                                        $("#spanName").html(data.Name);
                                        $("#spanAddress").html(data.Address);
                                        $("#spanCity").html(data.City);
                                        $("#spanState").html(data.State);
                                        $("#spanPinCode").html(data.PinCode);
                                        $("#spanStandardName").html(data.StandardNamea);

                                    }
                                },
                                error: function (error) {
                                    alert(error.statusText);
                                }
                            })

                        });
                    },
                    error: function (error) {
                        alert(error.statusText);
                    }
                });
            }




            StudentList();

            function StandardList(ddl1) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "http://localhost:6178/StudentWebService.asmx/GetStandards",
                    dataType: "json",
                    success: function (response) {
                        var standards = response.d;
                        ddl1.find("option:gt(0)").remove();

                        for (var index = 0; index < standards.length; index++) {
                            ddl1.append("<option value='" + standards[index].StandardId + "'>" + standards[index].StandardNamea + "</option>");
                        }

                    },
                    error: function (error) {
                        alert(error.statusText);
                    }
                });
            }

            // StudentList();

            $('#CreateNew').click(function () {
                StandardList($("#ddlStandard"));
                // StandardList();
                $("#divEdit").hide();
                $('#divCreate').show();
            });
            $('#imgClose').click(function () {
                $('#divCreate').hide();


            });

            $('#imgEditClose').click(function () {
                $('#divEdit').hide();


            });
            $('#imgEditClose').click(function () {
                $('#divEdit').hide();


            });
            $('#imgDetailsClose').click(function () {
                $('#divDetails').hide();


            });

            $("#btnSave").click(function () {
                var name = $("#txtName").val();
                var address = $("#txtAddress").val();
                var city = $("#txtCity").val();
                var state = $("#txtState").val();
                var pinCode = $("#txtPinCode").val();
                var standardId = $("#ddlStandard").val();
                // only for checking 
                //   alert("Hello");
                //   alert(name + " " + address + " " + city + " " + state + " " + pinCode + " " + standardId);
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "http://localhost:6178/StudentWebService.asmx/InsertStudentDetails",
                    data: "{ 'name':'" + name + "', 'address':'" + address + "', 'city':'" + city + "','state':'" + state + "', 'pinCode': '" + pinCode + "', standardId:" + standardId + "}",
                    dataType: "json",
                    success: function (response) {
                        var result = response.d;
                        if (result > 0) {
                            alert("Students Details Inserted Successfully!!!");
                            StudentList();
                            $("#txtName").val("");
                            $("#txtAddress").val("");
                            $("#txtCity").val("");
                            $("#txtState").val("");
                            $("#txtPinCode").val("");
                            $("#ddlStandard").val("");
                            $("#txtName").focus();

                        }
                        else {
                            alert("Student Details Insertion Failed!!!");
                        }


                    },
                    error: function (error) {
                        alert(error.statusText);
                    }
                });

                $("#btnUpdate").click(function () {
                    var studentId = $("#hidden1").val();
                    var name = $("#txtEName").val();
                    var address = $("#txtEAddress").val();
                    var city = $("#txtECity").val();
                    var state = $("#txtEState").val();
                    var pinCode = $("#txtEPinCode").val();
                    var standardId = $("#ddlEStandard").val();
                    // only for checking 
                    //   alert("Hello");
                    //   alert(name + " " + address + " " + city + " " + state + " " + pinCode + " " + standardId);
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "http://localhost:6178/StudentWebService.asmx/UpdateStudentDetails",
                        data: "{ 'name':'" + name + "', 'address':'" + address + "', 'city':'" + city + "','state':'" + state + "', 'pinCode': '" + pinCode + "', standardId:" + standardId + ", studentId:" + standardId + "}",
                        dataType: "json",
                        success: function (response) {
                            var result = response.d;
                            if (result > 0) {
                                alert("Students Details Updated Successfully!!!");
                                StudentList();
                                $("#divEdit").hide();



                            }
                            else {
                                alert("Student Details Updation Failed!!!");
                            }


                        },
                        error: function (error) {
                            alert(error.statusText);
                        }
                    });


                    //$("#btnEdit").click(function () {
                    //    alert($(this).attr);
                    //});

                });

            });
        });

    </script>


</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <h1 style="margin:0px; background-color:maroon;color:white;text-align:center" >Student List</h1>
    <br />
    <hr />
    <a href="#" id="CreateNew">Create New Student</a>
    <br /><br />

<div style="color:Highlight;background-color:burlywood" id="divStudents"></div>

<div id="divstudents">

</div>
    <br />

    <%--Create new student UI--%>
<div id="divCreate" style="border:2px solid red;width:500px; padding:5px; display:none ">
    <div align="right">
        <img id="imgClose" src="Images/Close.png" width="25px" height="25px" style="cursor:pointer" />
    </div>
    <h3 style="text-align:center;margin:0px">Create New Student Details</h3>

    <b>Name</b><br />
    <input type="text" id="txtName" />
    <br /><br />
    <b>Address</b><br />
    <textarea id="txtAddress" rows="3" cols="50" ></textarea>
    <br /><br />
    <b>City</b><br />
    <input type="text" id="txtCity"/>
    <br /><br />
    <b>State</b><br />
    <input type="text" id="txtState"/>
    <br /><br />
    <b>Pin Code</b><br />
    <input type="text" id="txtPinCode"/>
    <br /><br />
    <b>Standard Name</b><br />
    <select id="ddlStandard">
    <option value="">Select</option>
    </select>
    <br /><br />
    <input id="btnSave" type="button" value="Save"  />




</div>


        <%--Edit new student UI--%>
<div id="divEdit" style="border:2px solid red;width:500px; padding:5px; display:none ">
    <div align="right">
        <img id="imgEditClose" src="Images/Close.png" width="25px" height="25px" style="cursor:pointer" />
    </div>
    <h3 style="text-align:center;margin:0px">Update New Student Details</h3>
    <%--this is added--%>
    <input type="hidden" id="hidden1" />

    <b>Name</b><br />
    <input type="text" id="txtEName" />
    <br /><br />
    <b>Address</b><br />
    <textarea id="txtEAddress" rows="3" cols="50" ></textarea>
    <br /><br />
    <b>City</b><br />
    <input type="text" id="txtECity"/>
    <br /><br />
    <b>State</b><br />
    <input type="text" id="txtEState"/>
    <br /><br />
    <b>Pin Code</b><br />
    <input type="text" id="txtEPinCode"/>
    <br /><br />
    <b>Standard Name</b><br />
    <select id="ddlEStandard">
   <%--no need for it here--%>
   <%--<option value="">Select</option>--%>
    </select>
    <br /><br />
    <input id="btnUpdate" type="button" value="Update"  />




</div>


       <%--Details new student UI--%>
<div id="divDetails" style="border:2px solid red;width:500px; padding:5px; display:none ">
    <div align="right">
        <img id="imgDetailsClose" src="Images/Close.png" width="25px" height="25px" style="cursor:pointer" />
    </div>
    <h3 style="text-align:center;margin:0px">Student Details</h3>
    <%--this is added--%>
    <b>Student Id</b> <br />
    <span id="spanStudentId"></span>
    <br /><br />
    <b>Name</b><br />
    <span id="spanName"></span>
    <br /><br />
    <b>Address</b><br />
    <span id="spanAddress"></span>
    <br /><br />
    <b>City</b><br />
    <span id="spanCity"></span>
    <br /><br />
    <b>State</b><br />
    <span id="spanState"></span>
    <br /><br />
    <b>Pin Code</b><br />
    <span id="spanPinCode"></span>
    <br /><br />
    <b>Standard Name</b><br />
       <span id="spanStandardName"></span>

</div>

</asp:Content>