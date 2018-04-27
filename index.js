function videoResize() {
  targetHeight = window.innerHeight
  || document.documentElement.clientHeight
  || document.body.clientHeight;
  console.log("SDIJF")
  targetWidth = window.innerWidth
  || document.documentElement.clientWidth
  || document.body.clientWidth;

  if(document.getElementById("bgvid").offsetWidth < targetWidth) {
    document.getElementById("bgvid").style.width = "100%";
    document.getElementById("bgvid").style.height = "auto";
  }

  if(document.getElementById("bgvid").offsetHeight < targetHeight) {
    document.getElementById("bgvid").style.width = "auto";
    document.getElementById("bgvid").style.height = "100%";
  }
} 