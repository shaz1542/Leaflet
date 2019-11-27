// Write your JavaScript code.


console.log('test');

$(document).ready(function () {
    var mymap = L.map('mapid').setView([51.505, -0.09], 13);
    var init = function () {
        
        L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1Ijoic2hhei1hdXo4OSIsImEiOiJjazNkaGo1YjkxNW53M2RrM3ZvaG54MzdsIn0.sRR1R6SlVByfXQ9h-hSEhw', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 18,
            id: 'mapbox.satellite',
            accessToken: 'pk.eyJ1Ijoic2hhei1hdXo4OSIsImEiOiJjazNkaGo1YjkxNW53M2RrM3ZvaG54MzdsIn0.sRR1R6SlVByfXQ9h-hSEhw'
        }).addTo(mymap);

        mymap.on('click', onMapClick);

        loadMarkers();
    }
    init();
    
    function onMapClick(e) {
        console.log(e);
        var form = '<br/><textarea name="destinationTitle" lat="' + e.latlng.lat + '" lng="' + e.latlng.lng + '" latlng="' + e.latlng.toString() + '"></textarea>';
        var saveButton = '<input name="saveButton" onclick="saveDestination()" type ="submit"></input>'
        popup
            .setLatLng(e.latlng)
            .setContent("<b>Hello world!</b>" + form
            + "<br>I am a popup. you opened the popup at: " + e.latlng.toString()
            + "<br/>" + saveButton
            )
            .openOn(mymap);
        console.log(e);

    }

    

    function loadMarkers()
    {
        $('[name="destination"]').each(function (i,v) {
            //create the marker 
            var latidude = $(this).attr("latitude");
            var longitude =$(this).attr("longitude");
            var note =$(this).attr("note");
            var marker = L.marker([latidude, longitude]).addTo(mymap);
            //bind the popup
            marker.bindPopup("<b>Note :</b><br>"+note).openPopup();
        })
    }


});
var popup = L.popup();


function saveDestination() {
    var s = document.getElementsByName('destinationTitle')[0];

    var serviceURL = '/Holidays/SaveDestination';

    var locationData = {
        Note: s.value,
        Latitude: s.getAttribute("lat"),
        Longitude: s.getAttribute("lng")
    }

    $.ajax({
        type: "POST",
        url: serviceURL,
        data: JSON.stringify(locationData),
        contentType: "application/json",
        success: function (result) {
            location.reload();  
        },
        error: function (result) {
            alert('error');
        }
    });
    ////End of ajax request
}