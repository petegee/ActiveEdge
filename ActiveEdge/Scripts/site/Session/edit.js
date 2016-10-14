$(document).ready(function() {
 
  $("#canvasDiv").drawingCanvas();

  $("#ClientFullName")
    .activeEdgeTypeahead("../../api/search/clients/")
    .bind("typeahead:select", function (ev, suggestion) {
      $("#ClientId").val(suggestion.Id);
    });
  
  //new Taggle('Hypothesis');
});

