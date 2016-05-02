$.fn.extend({
  drawingCanvas: function() {
    var canvasWidth = 800;
    var canvasHeight = 625;

    var canvasDiv = document.getElementById('canvasDiv');
    var canvas = document.createElement('canvas');
    canvas.setAttribute('width', canvasWidth);
    canvas.setAttribute('height', canvasHeight);
    canvas.setAttribute('id', 'canvas');
    canvasDiv.appendChild(canvas);
    if (typeof window.G_vmlCanvasManager != 'undefined') {
      canvas = window.G_vmlCanvasManager.initElement(canvas);
    }
    var context = canvas.getContext("2d");

    var value = $('#AreasOfDiscomfort').val();
    var clicks;
    if (value === "")
      clicks = new Array();
    else {
      clicks = JSON.parse(value);
      redraw();
    }

    $('#canvas').mousedown(function (e) {
      var mouseX = e.offsetX;// e.pageX - this.offsetLeft;
      var mouseY = e.offsetY;// e.pageY - this.offsetTop;
      
      addClick(mouseX, mouseY);
      redraw();
    });
    
    function addClick(x, y) {
      clicks.push({ x: x, y: y });
      $('#AreasOfDiscomfort').val(JSON.stringify(clicks));
      console.debug(JSON.stringify(clicks));
    }

    function redraw() {
      context.clearRect(0, 0, context.canvas.width, context.canvas.height); // Clears the canvas

      context.strokeStyle = "#18a689";
      context.lineJoin = "round";
      context.lineWidth = 30;

      for (var i = 0; i < clicks.length; i++) {
        context.beginPath();

        context.moveTo(clicks[i].x - 1, clicks[i].y);

        context.lineTo(clicks[i].x, clicks[i].y);
        context.closePath();
        context.stroke();
      }
    }
  }
});