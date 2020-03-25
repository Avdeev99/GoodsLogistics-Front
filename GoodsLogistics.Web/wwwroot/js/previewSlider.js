

// 
var carousel = (function(){
  
  
    /* var  maxWidth = window.innerWidth;
  var  maxHeight = window.innerHeight; */
setTimeout(function(){
  

 //  console.log(maxWidth);
 // console.log(maxHeight);
  var image_holder = document.getElementById('main-slider');
  var img_array = image_holder.querySelectorAll('.slider-wrapper img'); 
  console.log(img_array[0]);
  console.log(img_array[0].clientHeight);
  var imageWidth = img_array[0].width; 
  var imageHeight = img_array[0].height;  
  
  


  function resizeBg(element_for_reszie) {
    
      var  maxWidth = document.body.clientWidth;
      var  maxHeight = document.body.clientHeight;  
       var aspectRatio = imageWidth /imageHeight;
      if (typeof(element_for_reszie) != 'undefined' && (element_for_reszie != null) ) {
          console.log(maxWidth / maxHeight);
          
          if ( (maxWidth / maxHeight) < aspectRatio ) {
            console.log('here')
              element_for_reszie.classList.remove("bgwidth");
              element_for_reszie.classList.add("bgheight");
          } else {
            console.log('there')
              element_for_reszie.classList.remove("bgheight");
              element_for_reszie.classList.add("bgwidth");
          }  
      }
  };

  for (var i = 0; i < img_array.length; i++) { 
      //console.log(img_array[i]);
      resizeBg(img_array[i]);
  }




  window.addEventListener('resize', function(event){
    console.log('resize');
    for (var i = 0; i < img_array.length; i++) { 
        //console.log(img_array[i]);
        resizeBg(img_array[i]);
    }
  });

  
  
  
  
  
  var box = document.getElementById('main-slider');
  var prev = box.querySelector('#prev');
  var next = box.querySelector('#next');
  var counter = 0;
  var items = box.querySelectorAll('.slider-wrapper img');
  console.log(items)
  var amount = items.length;
  
  //console.log(items);
  //console.log(amount);
  var current = items[0];
  current.classList.add('current');
  //box.classList.add('active'); //????
  function navigate(direction) {
    //console.log(current);
    current.classList.remove('current');
    counter = counter + direction;
    //console.log(counter);
    if  (direction === -1  && counter < 0) {
      counter = amount - 1; // start at 0, this last item
    }
    if( direction === 1 && !items[counter]) {
        counter = 0;
    }
     current = items[counter];
     current.classList.add('current');
    
  }
  
  next.addEventListener('click', function(e){
    navigate(1);
  });
  
   prev.addEventListener('click', function(e){
    navigate(-1);
  });
  


//var intervalID = window.setInterval(call_timer, 6000);
//
//function call_timer() {
//  navigate(1);
//}  
//  
  
   }, 100); 
  
})();
    
