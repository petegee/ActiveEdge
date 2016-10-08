$(document)
  .ready(function() {
    
    var createUrl = $("#createOrganizationApi").val();
    ko.applyBindings(new OrganizationModel(null, createUrl));


    $("[name='Suburb']")
      .activeEdgeTypeahead("../api/search/suburbs/");
     
    $("[name='City']")
      .activeEdgeTypeahead("../api/search/cities/");
  });