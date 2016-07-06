$(document)
  .ready(function() {

    ko.applyBindings(new OrganizationModel(null, "/organization/new"));


    $("[name='Suburb']")
      .activeEdgeTypeahead("../api/search/suburbs/");
     
    $("[name='City']")
      .activeEdgeTypeahead("../api/search/cities/");
  });