
function OrganizationModel(data) {

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
        url: $("#createOrganizationApi").val(),
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
  self.updateModel = function (formElement) {


    if ($(formElement).valid()) { /* do something */

      var jsonData = ko.toJSON(self);

      $.ajax({
        url: $("#updateOrganizationApi").val(),
        type: "PUT",
        traditional: true,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: jsonData
      })
        .done(function (response) {
          if (response.isRedirect) {
            window.location.href = response.redirectUrl;
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