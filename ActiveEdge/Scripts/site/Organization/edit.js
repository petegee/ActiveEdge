$(document)
  .ready(function () {

    var url = $("#getOrganizationApi").val();
    $.getJSON(url,
      function(data) {
        // Now use this data to update your view models, 
        // and Knockout will update your UI automatically 

        
    
        var viewModel = new OrganizationModel(data, "/organization/new");

        //ko.mapping.fromJS(data, viewModel);
        ko.applyBindings(viewModel);
        
      });
   


    //$("[name='Suburb']")
    //  .activeEdgeTypeahead("../api/search/suburbs/");


    //$("[name='City']")
    //  .activeEdgeTypeahead("../api/search/cities/");
  });