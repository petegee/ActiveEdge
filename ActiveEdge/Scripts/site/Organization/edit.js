$(document)
  .ready(function () {

    var url = $("#getOrganizationApi").val();
    $.getJSON(url,
      function(data) {
        
        var viewModel = new OrganizationModel(data, "/organization/new");

        //ko.mapping.fromJS(data, viewModel);
        ko.applyBindings(viewModel);
        
      });
    
    $("[name='Suburb']")
      .activeEdgeTypeahead("../api/search/suburbs/");


    $("[name='City']")
      .activeEdgeTypeahead("../api/search/cities/");
  });