//tinymce.init({
//    selector: "textarea",
//    plugins: [
//        "advlist autolink lists link image charmap print preview anchor",
//        "searchreplace visualblocks code fullscreen",
//        "insertdatetime media table contextmenu paste"
//    ],
//    toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image",
//    setup: function (ed) {
//        ed.on('init', function () {
//            $(ed.getBody()).on('blur', function (e) {
//                console.log('blur');
//            });
//            $(ed.getBody()).on('focus', function (e) {
//                console.log('focus');
//            });
//        });
//    }

//});





tinymce.PluginManager.add('placeholder', function (editor) {
    editor.on('init', function() {
        var label = new Label;

        onBlur();

        tinymce.DOM.bind(label.el, 'click', onFocus);
        editor.on('focus', onFocus);
        editor.on('blur', onBlur);
        editor.on('change', onBlur);
        editor.on('setContent', onBlur);
        editor.on('keydown', onKeydown);

        function onFocus() {
            if (!editor.settings.readonly === true) {
                label.hide();
            }
            editor.execCommand('mceFocus', false);
        }

        function onBlur() {
            if (editor.getContent() == '') {
                label.show();
            } else {
                label.hide();
            }
        }

        function onKeydown(){
            label.hide();
        }
    });

    var Label = function(){
        var placeholder_text = editor.getElement().getAttribute("placeholder") || editor.settings.placeholder;
        var placeholder_attrs = editor.settings.placeholder_attrs || {style: {position: 'absolute', top:'5px', left:0, color: '#888', padding: '1%', width:'98%', overflow: 'hidden', 'white-space': 'pre-wrap'} };
        var contentAreaContainer = editor.getContentAreaContainer();

        tinymce.DOM.setStyle(contentAreaContainer, 'position', 'relative');

        // Create label el
        this.el = tinymce.DOM.add( contentAreaContainer, editor.settings.placeholder_tag || "label", placeholder_attrs, placeholder_text );
    }

    Label.prototype.hide = function(){
        tinymce.DOM.setStyle( this.el, 'display', 'none' );
    }

    Label.prototype.show = function(){
        tinymce.DOM.setStyle( this.el, 'display', '' );
    }

    //editor.on('keyup', function (e) {
    //    alert('keyup occured');
    //    //console.log('init event', e);
    //    console.log('Editor contents was modified. Contents: ' + editor.getContent());
    //    check_submit(); //another function calling
    //});
    //////////////////////////////////////////////////////////////////////////////////////////////////
    //editor.onInit.add(function (editor) {
    //    tinymce.dom.Event.add(editor.getBody(), "focus", function (e) {
    //        parent.console.log('focus');
    //    });
    //});

    //editor.onInit.add(function (editor) {
    //    tinymce.dom.Event.add(editor.getBody(), "blur", function (e) {
    //        parent.console.log('blur');
    //    });
    //});
});

$(document).ready(function () {

    //Updating a Course name
    $("input[name='CourseName']").focusout(function () {
        var eduId = $(this).attr("id");
        var courseName = $("input[name='CourseName']").val();

        $.ajax({
            type: "POST",
            contentType: "application/json;charset=utf-8",
            url: "/WorkExperience/UpdateCourseName",
            data: "{ eduId:'" + eduId + "', courseName: '" + courseName + "'}",
            dataType: "json",
            success: function (response) {

                if (response > 0) {

                    location.reload(true);


                }
                else {

                }
            },
            error: function (error) {
                alert("Error Status: " + error.statusText);
            }
        });
    });

    //Adding a Job title
    $("input[name='jobTitle']").focusout(function () {
        var workExperienceId = $(this).attr("id");
        var jobTitle = $("input[name='jobTitle']").val();
        alert("worked");
        alert(jobTitle);
        $.ajax({
            type: "POST",
            contentType: "application/json;charset=utf-8",
            url: "/WorkExperience/UpdateWorkTitle",
            data: "{ workExperienceId:'" + workExperienceId + "', jobTitle: '" + jobTitle + "'}",
            dataType: "json",
            success: function (response) {

                if (response > 0) {

                    location.reload(true);


                }
                else {

                }
            },
            error: function (error) {
                alert("Error Status: " + error.statusText);
            }
        });
    });

})