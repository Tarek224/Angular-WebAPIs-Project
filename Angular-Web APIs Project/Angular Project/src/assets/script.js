var link = document.getElementsByClassName("nav-link");
for (let i = 0; i < link.length; i++) {
       link[i].onclick = function()
       {
           link[i].style.color = "#696763";
       }
}


document.onscroll = function() {scrollFunc()};
function scrollFunc()
{
    if (document.body.scrollTop > 150 || document.documentElement.scrollTop > 150) {
        document.getElementById("scrollUp").style.display = "block";
    } else {
        document.getElementById("scrollUp").style.display = "none";
    }
}

// var path ;
// var original ;
// var imgs = [];
// var getimgs = document.getElementsByClassName("rateimg");
// for (let index = 0; index < getimgs.length; index++) {
//     imgs.push(getimgs[index]);
// }
// function rate(element)
// {
//     original = element.src ;
//     path = element.src;
//     element.src = "./images/product-details/Filled_star.png";    
// }
// function stopRate(element)
// {
//     element.src = original;
// }
// function makeRate(element)
// {
//     var imgindex = imgs.indexOf(element);
//     if(original === path)
//     {
//         for (let index = 0; index <= imgindex; index++) 
//         {
//             original = imgs[index].src;
//             imgs[index].src = "./images/product-details/Filled_star.png";
//         }
//     }
// }


// var dropdownlist = document.getElementsByClassName("dropdown-menu")[1];
function ShowList(element)
{
    var dropdownlist = element.lastChild;
    dropdownlist.style.display = "block";
}
function CloseList(element)
{
    var dropdownlist = element.lastChild;
    dropdownlist.style.display = "none";
}