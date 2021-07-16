
function draw() {
var canvas = document.getElementById('canvas2D');
if (canvas.getContext) {
    var ctx = canvas.getContext('2d');
      
      
    ctx.fillStyle = 'rgb(200, 0, 0)';
    ctx.fillRect(10, 10, 50, 50);

    ctx.fillStyle = 'rgba(0, 0, 200, 0.5)';
    ctx.fillRect(30, 30, 50, 50);
}
}

function setCanvas(bytes){  
    var byteArray = Blazor.platform.toUint8Array(bytes);
    
    var canvas = document.getElementById('canvas2D');
    if (canvas.getContext) {
        var ctx = canvas.getContext('2d');
        var imgData = ctx.createImageData(canvas.width, canvas.height);
      
        for (let i = 0; i < imgData.data.length; i++) {
            imgData.data[i] = byteArray[i];
        }
         
        ctx.putImageData(imgData, 0, 0);
    }
}