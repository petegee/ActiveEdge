$(document)
  .ready(function () {

    ko.applyBindings(new OrganizationModel());


    //$("[name='Suburb']")
    //  .activeEdgeTypeahead("../api/search/suburbs/");


    //$("[name='City']")
    //  .activeEdgeTypeahead("../api/search/cities/");
  });