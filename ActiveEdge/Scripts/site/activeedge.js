$(document).ready(function() {

  $('.date').datepicker({
    todayBtn: "linked",
    keyboardNavigation: true,
    endDate: "0d",
    format: "dd/mm/yyyy",
    forceParse: true,
    calendarWeeks: false,
    autoclose: true
  });

  function htmlEncode(value) {
    //create a in-memory div, set it's inner text(which jQuery automatically encodes)
    //then grab the encoded contents back out.  The div never exists on the page.
    return $("<div/>").text(value).html();
  }

  function htmlDecode(value) {
    return $("<div/>").html(value).text();
  }

  $(".summernote").summernote({
    //toolbar: [
    //  // [groupName, [list of button]]
    //  ['style', ['bold', 'italic', 'underline', 'clear']],
    //  ['font', ['strikethrough']],
    //  ['fontsize', ['fontsize']],
    //  ['color', ['color']],
    //  ['para', ['ul', 'ol', 'paragraph']],
    //  ['height', ['height']]
    //]
  })
    .on("summernote.change", function(we, contents, $editable) {
      var hiddenFieldId = we.target.attributes["for"].value;
      var htmlEncodedContents = htmlEncode(contents);
      $("#" + hiddenFieldId).val(htmlEncodedContents);
    });

});