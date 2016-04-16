$(document).ready(function() {
 
  $('#date').datepicker({
    todayBtn: "linked",
    keyboardNavigation: true,
    endDate: "0d",
    format: "dd/mm/yyyy",
    forceParse: false,
    calendarWeeks: false,
    autoclose: true
  });

  var bestPictures = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
   // prefetch: '../data/films/post_1960.json',
    remote: {
      url: '../api/search/clients/%QUERY',
      wildcard: '%QUERY'
    }
  });

  $('#ClientName').typeahead({
    hint: true,
    highlight: true,
    minLength: 1
  }, {
    name: 'best-pictures',
    display: 'FullName',
    source: bestPictures,
    templates: {
      empty: [
        '<div class="empty-message">',
          'unable to find any Best Picture winners that match the current query',
        '</div>'
      ].join('\n'),
      //suggestion: Handlebars.compile('<div><strong>{{value}}</strong> – {{year}}</div>')
    }
  });
});