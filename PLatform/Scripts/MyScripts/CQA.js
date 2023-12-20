
const arrayOfObjects = [];

var ans = document.querySelectorAll(".handle");

ans.forEach(ele => {

    ele.addEventListener("click", () => {
        pushing(ele);
    })

})


 function pushing (ele) {
     var attr = ele.getAttribute("attr").split(",");
     var ansId = parseInt(attr[0]);
     var QuestId = parseInt(attr[1]);

     if (QuestId != null) {
         var existingAnswer = arrayOfObjects.find(obj => obj.QuestId === QuestId);
         if (existingAnswer) {

             existingAnswer.ansId = ansId;

         } else {
             arrayOfObjects.push({ ExId, QuestId, ansId });

         }
         console.log(arrayOfObjects);
         
     }
     
}


var submitbtn = document.getElementById("submitEx");
var Load = document.querySelector(".Load");
submitbtn.onclick = function () {

    if (arrayOfObjects.length == 0) {
        swal("كمل الامتحان يا كبير", "! انت تقدر");
        return;
    }
    //Load.style.display = "block";

    $.ajax({
        url: '/Quiz/submitExam',
        type: 'POST',
        data: JSON.stringify({ arrayOfObjects: arrayOfObjects }),
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.success) {

                swal("Good job!", "You Gaind " + response.points + " %", "success").then(() => { window.location.href = '/Quiz/Result' });
            } else {
                swal("كمل الامتحان يا كبير", "! انت تقدر");

            }


        },
        error: function (xhr, status, error) {
            swal("كمل الامتحان يا كبير", "! انت تقدر");

        }
    });
}





