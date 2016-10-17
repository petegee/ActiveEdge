$(document).ready(function() {

  $('.date').datepicker({
    todayBtn: "linked",
    todayHighlight: true,
    keyboardNavigation: true,
    endDate: "0d",
    format: "dd/mm/yyyy",
    forceParse: false,
    calendarWeeks: false,
    autoclose: true
  });



  $(".summernote").summernote({
    toolbar: [
      // [groupName, [list of button]]
      ['style', ['bold', 'italic', 'underline', 'clear']],
      ['font', ['strikethrough', 'superscript', 'subscript']],
      ['fontsize', ['fontsize']],
      ['color', ['color']],
      ['para', ['ul', 'ol', 'paragraph']],
      ['height', ['height']]
    ]
  })
    .on("summernote.change", function(we, contents, $editable) {
      var hiddenFieldId = we.target.attributes["for"].value;
      var htmlEncodedContents = htmlEncode(contents);
      $("#" + hiddenFieldId).val(htmlEncodedContents);
    });

});

$.fn.activeEdgeTypeahead = function (url) {
  
  var results = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    //prefetch: '../data/films/post_1960.json',
    remote: {
      url:  url + '%QUERY',
      wildcard: '%QUERY'
    }
  });


  var typeahead = $(this)
    .attr("autocomplete", "off")
    .typeahead({
      hint: true,
      highlight: true,
      minLength: 1
    },
    {
      name: 'search-results',
      display: 'DisplayValue',
      source: results,
      templates: {
        empty: [
          '<div class="empty-message">',
          'no results found',
          '</div>'
        ].join('\n')
      }
    });

 $(".tt-hint").removeClass("required");

  typeahead.bind('typeahead:change',
    function(ev, suggestion) {
      var dataBindAttribute = $(this).attr("data-bind");
      $("[data-bind='" + dataBindAttribute + "'].tt-hint").val(suggestion);
    });

  return typeahead;
};


function htmlEncode(value) {
  //create a in-memory div, set it's inner text(which jQuery automatically encodes)
  //then grab the encoded contents back out.  The div never exists on the page.
  return $("<div/>").text(value).html();
}

function htmlDecode(value) {
  return $("<div/>").html(value).text();
}

function displayAlert(alert, message) {

  var rawTemplate = "<div class='notification row'><div class='col-lg-12'><div class='alert {{alert}} alert-dismissable'><button aria-hidden='true' data-dismiss='alert' class='close' type='button'>×</button><b>{{message}}</b></div></div></div>"; // (step 1)
  var compiledTemplate = Handlebars.compile(rawTemplate); // (step 2)

  var html = compiledTemplate({ alert: alert, message: message });

  var doesMessageExistAlready = false;
  $(".alert b")
      .each(function (index, item) {

        if (item.innerText === message) {
          doesMessageExistAlready = true;
        }
      });

  if (doesMessageExistAlready === false) {
    $(html).appendTo("#notifications");
  }
}

function displaySuccess(message) {
  displayAlert("alert-success", message);
}

function displayInfo(message) {
  displayAlert("alert-info", message);
}

function displayDanger(message) {
  displayAlert("alert-danger", message);
}

function displayWarning(message) {
  displayAlert("alert-warning", message);
}