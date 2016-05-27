
$(document)
  .ready(function() {
    $("#Address_Suburb")
      .activeEdgeTypeahead('../api/search/suburbs/');


    $("#Address_City")
      .activeEdgeTypeahead('../api/search/cities/');
  });
