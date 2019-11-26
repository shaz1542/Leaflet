// Write your JavaScript code.

var mymap = L.map('mapid').setView([51.505, -0.09], 13);

L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1Ijoic2hhei1hdXo4OSIsImEiOiJjazNkaGo1YjkxNW53M2RrM3ZvaG54MzdsIn0.sRR1R6SlVByfXQ9h-hSEhw', {
    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
    maxZoom: 18,
    id: 'mapbox.satellite',
    accessToken: 'pk.eyJ1Ijoic2hhei1hdXo4OSIsImEiOiJjazNkaGo1YjkxNW53M2RrM3ZvaG54MzdsIn0.sRR1R6SlVByfXQ9h-hSEhw'
}).addTo(mymap);

//Add a marker
var marker = L.marker([51.5, -0.09]).addTo(mymap);
marker.bindPopup("<b>Hello world!</b><br>I am a popup.").openPopup();

//add circle
var circle = L.circle([51.508, -0.11], {
    color: 'red',
    fillColor: '#f03',
    fillOpacity: 0.5,
    radius: 500
}).addTo(mymap);
circle.bindPopup("I am a circle.");
//add polygon
var polygon = L.polygon([
    [51.509, -0.08],
    [51.503, -0.06],
    [51.51, -0.047]
]).addTo(mymap);
polygon.bindPopup("I am a polygon.");

var popup = L.popup();

function saveDestination() {
    var s = document.getElementsByName('destinationTitle')[0];
    console.log(s);
    console.log('save destination: ' + s.value + ' ; lat:' + s.getAttribute("lat") + ';lng : ' + s.getAttribute("lng"));
    //send ajax request to the controller
    
}



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

mymap.on('click', onMapClick);

console.log('test');
