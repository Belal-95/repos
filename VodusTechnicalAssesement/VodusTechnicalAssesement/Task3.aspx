﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task3.aspx.cs" Inherits="VodusTechnicalAssesement.Task11" %>

<!DOCTYPE HTML>
<html>
<head>
    <title>Task3</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script>
        function dragStart(event) {
            event.dataTransfer.setData("Text", event.target.id);
        }

        function dragEnd(event) {
            if ($("#dragtarget").parent().attr('id') == "thecustomizationDiv") {
                $("#dragtarget").attr('contenteditable', 'true');
                $("#Span1").text("");
            }

            else {
                $("#dragtarget").attr('contenteditable', 'false');
                $("#Span1").text("drop the  table here for customization");
            }

        }

        function allowDrop(event) {
            event.preventDefault();
        }

        function drop(event) {
            event.preventDefault();
            var data = event.dataTransfer.getData("Text");
            event.target.appendChild(document.getElementById(data));
        }
    </script>
    <style>
        .droptarget {
            float: left;
            width: 50%;
            height: 200px;
            margin: 15px;
            padding: 10px;
            border: 1px solid #aaaaaa;
        }
    </style>
</head>
<body>
    <div style="width: 100%">
        <div class="droptarget" ondrop="drop(event)" ondragover="allowDrop(event)" id="b">
            <table ondragstart="dragStart(event)" ondragend="dragEnd(event)" draggable="true" id="dragtarget">
                <thead>
                    <tr>
                        <th class="index">No.</th>
                        <th>Year</th>
                        <th>Title</th>
                        <th>Grade</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="index">1</td>
                        <td>2000</td>
                        <td>Scince</td>
                        <td>A+</td>
                    </tr>
                    <tr>
                        <td class="index">2</td>
                        <td>2002</td>
                        <td>Frensh</td>
                        <td>B</td>
                    </tr>
                    <tr>
                        <td class="index">3</td>
                        <td>1999</td>
                        <td>English</td>
                        <td>A+</td>
                    </tr>
                    <tr>
                        <td class="index">4</td>
                        <td>2005</td>
                        <td>Programming</td>
                        <td>C</td>
                    </tr>
                    <tr>
                        <td class="index">5</td>
                        <td>2010</td>
                        <td>Math</td>
                        <td>A</td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="droptarget" ondrop="drop(event)" ondragover="allowDrop(event)" id="thecustomizationDiv">
            <span id="Span1">drop the  table here for customization</span>
        </div>
    </div>
    <br />
    <div>
        <p><a href="/Default.aspx" class="btn btn-primary btn-lg">Back</a></p>
    </div>
    <br />
    <br />
    <div>
        Note: I did not get what kind of customization do you want me to allow the user to do. But I did something simple according to the time mentioned. If the requirements are more than that I will be happy to do it as well if you recommend it.
    </div>
</body>
</html>
