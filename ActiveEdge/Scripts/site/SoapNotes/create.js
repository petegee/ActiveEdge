$(document).ready(function() {
 


  var clients = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    //prefetch: '../data/films/post_1960.json',
    remote: {
      url: '../api/search/clients/%QUERY',
      wildcard: '%QUERY'
    }
  });

  $('#ClientFullName').typeahead({
    hint: true,
    highlight: true,
    minLength: 1
  }, {
    name: 'best-pictures',
    display: 'FullName',
    source: clients,
    templates: {
      empty: [
        '<div class="empty-message">',
          'no results found',
        '</div>'
      ].join('\n'),
      //suggestion: Handlebars.compile('<div><strong>{{value}}</strong> – {{year}}</div>')
    }
  })
  .bind('typeahead:select', function (ev, suggestion) {
      $("#ClientId").val(suggestion.Id);
    });
  ;
});