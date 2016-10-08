$(document)
  .ready(function () {

    var url = $("#getOrganizationApi").val();
    var updateUrl = $("#updateOrganizationApi").val();
    $.getJSON(url,
      function(data) {
        
        var viewModel = new OrganizationModel(data, updateUrl);

        ko.applyBindings(viewModel);
        
      });
    
    $("[name='Suburb']")
      .activeEdgeTypeahead("../api/search/suburbs/");


    $("[name='City']")
      .activeEdgeTypeahead("../api/search/cities/");
  });