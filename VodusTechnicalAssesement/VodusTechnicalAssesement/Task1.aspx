﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task1.aspx.cs" Inherits="VodusTechnicalAssesement.Task1" %>

<!DOCTYPE html>

<html>
<head>
    <title>Task1</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.13.5/xlsx.full.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
</head>

<body>

    <form id="form1" runat="server">

        <script>
            /* set up XMLHttpRequest */
            var url = "https://vodus.com/content/test/vodus-test.xlsx";
            var oReq = new XMLHttpRequest();
            oReq.open("GET", url, true);
            oReq.responseType = "arraybuffer";
            var s;

            oReq.onload = function (e) {
                var arraybuffer = oReq.response;

                /* convert data to binary string */
                var data = new Uint8Array(arraybuffer);
                var arr = new Array();
                for (var i = 0; i != data.length; ++i) arr[i] = String.fromCharCode(data[i]);
                var bstr = arr.join("");

                /* Call XLSX */
                var workbook = XLSX.read(bstr, {
                    type: "binary"
                });

                var first_sheet_name = workbook.SheetNames[0];
                /* Get worksheet */
                var worksheet = workbook.Sheets[first_sheet_name];

                /* I used this to check the output while i was coding */
                //console.log(XLSX.utils.sheet_to_json(worksheet, {
                //    raw: true
                //}));

                s = XLSX.utils.sheet_to_json(worksheet, {
                    raw: true
                });
                document.getElementById("json").innerHTML = JSON.stringify(s, undefined, 2);
            }
            oReq.send();

        </script>
        <div>
            <p><a href="/Default.aspx" class="btn btn-primary btn-lg">Back</a></p>
        </div>
        <pre id="json"></pre>

    </form>
</body>
</html>
