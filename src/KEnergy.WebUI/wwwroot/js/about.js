$(document).ready(function () {
    GetMap();
});

// Функция загрузки
function GetMap() {
    google.maps.visualRefresh = true;
    // установка основных координат вул. Кіквідзе, 4БКиїв
   
    var target = new google.maps.LatLng(50.417325, 30.547874);
    // Установка общих параметров отображения карты, как масштаб, центральная точка и тип карты
    var mapOptions = {
        zoom: 17,
        center: target,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
    };

    // Встраиваем гугл-карты в элемент на странице и получаем объект карты
    var map = new google.maps.Map(document.getElementById("canvas"), mapOptions);

    // Настраиваем красный маркер, который будет использоваться для центральной точки
    //var myLatlng = target;

    var marker = new google.maps.Marker({
        position: target,
        map: map,
        title: 'Our location'
    });

    // Берем для маркера иконку с сайта google
    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')

    // Получаем данные
    $.getJSON('@Url.Action("GetData","Order")', function (data) {
        // Проходим по всем данным и устанавливаем для них маркеры
        $.each(data,
            function (i, item) {
                var marker = new google.maps.Marker({
                    'position': new google.maps.LatLng(item.GeoLong, item.GeoLat),
                    'map': map,
                    'title': item.PlaceName
                });

                // Берем для этих маркеров синие иконки с сайта google
                marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png')

                // Для каждого объекта добавляем доп. информацию, выводимую в отдельном окне
                var infowindow = new google.maps.InfoWindow({
                    content: "<div class='stationInfo'><h2>Address " + item.PlaceName
                });
                // обработчик нажатия на маркер объекта
                google.maps.event.addListener(marker,
                    'click',
                    function () {
                        infowindow.open(map, marker);
                    });
            });
    });
};