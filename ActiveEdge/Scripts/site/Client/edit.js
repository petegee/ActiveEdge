
$(document)
  .ready(function() {


    var sliderOptions = {
      start: 4,
      behaviour: "tap",
      connect: "lower",
      step: 1,
      range: {
        'min': 0,
        'max': 10
      }
    };

    $("#currentStressLevelsSlider")
      .noUiSlider(sliderOptions)
      .change(function(event, value) {
        $("#CurrentStressLevels").val(Math.round(value));
      });

    $("#currentPainOrTensionLevelsSlider")
      .noUiSlider(sliderOptions)
      .change(function(event, value) {
        $("#CurrentPainOrTensionLevels").val(Math.round(value));
      });

    $(".date")
      .datepicker({
        todayBtn: "linked",
        todayHighlight: true,
        keyboardNavigation: true,
        endDate: "0d",
        format: "dd/mm/yyyy",
        forceParse: false,
        calendarWeeks: false,
        autoclose: true
      });


    $("#Suburb")
      .activeEdgeTypeahead('../api/search/suburbs/');


    $("#City")
      .activeEdgeTypeahead('../api/search/cities/');

  });