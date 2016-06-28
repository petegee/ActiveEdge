function ClinicModel() {

  var self = this;

  // ********************************************************************************************************
  //  Knockout Observables                                                                                  *                                       
  // ********************************************************************************************************
  self.clinicName = ko.observable();
  self.addressLine1 = ko.observable();
  self.addressLine2 = ko.observable();
  self.suburb = ko.observable();
  self.postCode = ko.observable();
  self.contactPhoneNumber = ko.observable();
  self.city = ko.observable();
}

function OrganizationModel() {

  var self = this;

  self.organizationName = ko.observable();
  self.contactPerson = ko.observable();
  self.contactPhoneNumber = ko.observable();
  self.contactEmailAddress = ko.observable();
  self.clinics = ko.observableArray();

  self.clinics.push(new ClinicModel());

  self.addClinic = function() {
    self.clinics.push(new ClinicModel());

  };
  self.removeClinic = function() {
    self.clinics.remove(this);
  };
  self.submitForm = function(formElement) {


    if ($(formElement).valid()) { /* do something */

      var jsonData = ko.toJSON(self);

      $.ajax({
          url: "/Organization/Create",
          type: "POST",
          traditional: true,
          dataType: "json",
          contentType: "application/json; charset=utf-8",
          data: jsonData
        })
        .done(function(response) {
          if (response.isRedirect) {
            window.location.href = response.redirectUrl;
          }
        });


    }

  };
}