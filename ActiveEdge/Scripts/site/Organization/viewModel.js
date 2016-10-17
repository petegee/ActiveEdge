//ko.bindingHandlers.typeaheadJS = {
//  init: function (element, valueAccessor, allBindingsAccessor) {
//    var el = $(element);
//    var options = ko.utils.unwrapObservable(valueAccessor());
//    var allBindings = allBindingsAccessor();

//    //var data = new Bloodhound({
//    //  datumTokenizer: Bloodhound.tokenizers.obj.whitespace(options.displayKey),
//    //  queryTokenizer: Bloodhound.tokenizers.whitespace,
//    //  limit: options.limit,
//    //  prefetch: options.prefetch, // pass the options from the model to typeahead
//    //  remote: options.remote // pass the options from the model to typeahead
//    //});

//    //// kicks off the loading/processing of 'local' and 'prefetch'
//    //initialize();

//    el.activeEdgeTypeahead("../../api/search/suburbs/")
//    //el.attr("autocomplete", "off").typeahead(null, {
//    //  name: options.name,
//    //  displayKey: options.displayKey,
//    //  // `ttAdapter` wraps the suggestion engine in an adapter that
//    //  // is compatible with the typeahead jQuery plugin
//    //  source: data.ttAdapter()

//    //})
//      .on('typeahead:selected', function (obj, datum) {
//      id(datum.id); // set the id observable when a user selects an option from the typeahead list
//    });
//  }
//};

function OrganizationModel(data, url) {

  var self = this;
  
  self.organizationName = ko.observable();
  self.contactPerson = ko.observable();
  self.contactPhoneNumber = ko.observable();
  self.contactEmailAddress = ko.observable();
  self.clinics = ko.observableArray();


  if (data !== null && data !== undefined) {
    self.organizationName(data.organizationName);
    self.contactPerson(data.contactPerson);
    self.contactPhoneNumber(data.contactPhoneNumber);
    self.contactEmailAddress(data.contactEmailAddress);

    if (data.clinics.length > 0) {
      $(data.clinics)
        .each(function(index, item) {
          self.clinics.push(new ClinicModel(item));
        });
    } else {
      self.clinics.push(new ClinicModel());
    }

  } else {
    self.clinics.push(new ClinicModel());
  }


  self.addClinic = function() {
    self.clinics.push(new ClinicModel());

  };
  self.removeClinic = function() {
    self.clinics.remove(this);
  };
  self.saveModel = function(formElement) {


    if ($(formElement).valid()) { /* do something */

      var jsonData = ko.toJSON(self);

      $.ajax({
        url: url,
          type: "POST",
          traditional: true,
          dataType: "json",
          contentType: "application/json; charset=utf-8",
          data: jsonData
        })
        .done(function(response, textStatus, jqXhr) {
          if (jqXhr.status === 201) {
            window.location.href = jqXhr.getResponseHeader("Location");
          }
        });


    }
  };
  self.updateModel = function (formElement) {


    if ($(formElement).valid()) { /* do something */

      var jsonData = ko.toJSON(self);

      $.ajax({
        url: url,
        type: "PUT",
        traditional: true,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: jsonData
      })
        .done(function (response, textStatus, jqXhr) {
          if (jqXhr.status === 204) {
            window.location.href = $("#getOrganization").val();
          }
        })
      .error(function(message) {
        displayDanger(message.responseJSON.Message);
        });


    }

  };
}

function ClinicModel(data) {

  var self = this;

  // ********************************************************************************************************
  //  Knockout Observables                                                                                  *                                       
  // ********************************************************************************************************
  self.id = ko.observable();
  self.clinicName = ko.observable();
  self.addressLine1 = ko.observable();
  self.addressLine2 = ko.observable();
  self.suburb = ko.observable();
  self.postCode = ko.observable();
  self.contactPhoneNumber = ko.observable();
  self.city = ko.observable();

  if (data !== null && data !== undefined) {
    self.id(data.id);
    self.clinicName(data.clinicName);
    self.addressLine1(data.addressLine1);
    self.addressLine2(data.addressLine2);
    self.suburb(data.suburb);
    self.postCode(data.postCode);
    self.contactPhoneNumber(data.contactPhoneNumber);
    self.city(data.city);

  }
}