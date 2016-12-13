var map = null, markers = [], newMarkers = [], markerCluster = null, bounds = [], infobox = [];

var customIcon = null;
var alter = 0;

function initMap() {
		
//var	mapOptions = {
	//center: new google.maps.LatLng(0, 0),
	//zoom: 14,
	//scrollwheel: false,
	//streetViewControl: true,
	//disableDefaultUI: true,
	//streetViewControl: true,
//};

	
	//map = new google.maps.Map(document.getElementById("map"), mapOptions);
	map = new google.maps.Map(document.getElementById('map'), {
          zoom: 14,
          center: new google.maps.LatLng(0, 0),
          //mapTypeId: 'roadmap'
        });

	 
	customIcon = new google.maps.MarkerImage(
		'http://www.tpayneandco.co.uk/wp-content/themes/realty/lib/images/map-marker/map-marker-gold-fat.png',
		 null, // size is determined at runtime
		 null, // origin is 0,0
		 null, // anchor is bottom center of the scaled image
		 new google.maps.Size(50, 69)
	);
	markerClusterOptions = {
		gridSize: 60, // Default: 60
		maxZoom: 14,
		styles: [{
			width: 50,
			height: 50,
			url: "http://www.tpayneandco.co.uk/wp-content/themes/realty/lib/images/map-marker/map-marker-gold-round.png"
		}]
	};
	bounds = new google.maps.LatLngBounds();
	
	markers = initMarkers(map, [
		{ permalink:'http://www.tpayneandco.co.uk/property/first-floor-flat-close-to-town-centre-one-double-bedroom-off-road-parking-investment-opportunity-leasehold-no-upward-chain/', 
		  price:'OIEO £70,000', 
		  latLng: new google.maps.LatLng(52.5469703, 0.0867680000000064), 
		  thumbnail: 'http://www.tpayneandco.co.uk/wp-content/uploads/2015/09/new-300x225.jpg' 
		},
		{ permalink:'http://www.tpayneandco.co.uk/property/we-are-pleased-to-be-able-to-offer-for-sale-this-immaculately-presented-three-bedroom-semi-detached-property/', 
		  price:'£140,000', 
		  latLng: new google.maps.LatLng(52.6450705, 0.03485369999998511), 
		  thumbnail: 'http://www.tpayneandco.co.uk/wp-content/uploads/2015/09/DSC07881-300x225.jpg'
		},
		{ permalink:'http://www.tpayneandco.co.uk/property/this-extended-semi-detached-bungalow-is-offered-for-sale-with-no-upward-chain-2/', 
		  price:'OIEO £170,000', 
		  latLng: new google.maps.LatLng(52.4862616, 0.17663040000002184), 
		  thumbnail: 'http://www.tpayneandco.co.uk/wp-content/uploads/2015/09/1-300x225.jpg' 
		},
		{ permalink:'http://www.tpayneandco.co.uk/property/this-detached-house-is-offered-for-sale-with-no-upward-chain-2/', title:'This detached house is offered for sale with no upward chain.', 
		  price:'£249,995', latLng: new google.maps.LatLng(52.4529606, 0.04036550000000716), 
		  thumbnail: 'http://www.tpayneandco.co.uk/wp-content/uploads/2015/09/DSC07691-300x225.jpg' 
		},
		{ permalink:'http://www.tpayneandco.co.uk/property/this-q-type-property-is-offered-for-sale-with-no-upward-chain/', 
		  price:'£95,000',
		  latLng: new google.maps.LatLng(52.47918319999999, 0.16426939999996648), 
		  thumbnail: 'http://www.tpayneandco.co.uk/wp-content/uploads/2015/09/DSC076391-300x225.jpg'
		},
		{ permalink:'http://www.tpayneandco.co.uk/property/offered-for-sale-with-no-upward-chain-is-this-detached-bungalow-situated-in-a-cul-de-sac-location/', title:'Offered for sale with no upward chain is this detached bungalow, situated in a Cul de Sac location.', 
		 price:'£235,000', latLng: new google.maps.LatLng(52.4465981, 0.044180999999980486), 
		 thumbnail: 'http://www.tpayneandco.co.uk/wp-content/uploads/2015/09/DSC07665-300x225.jpg' 
		},
		{ permalink:'http://www.tpayneandco.co.uk/property/this-spacious-semi-detached-house-is-situated-in-the-town-of-chatteris/', title:'This spacious semi detached house is situated in the town of Chatteris.', 
		  price:'£180,000', latLng: new google.maps.LatLng(52.463314, 0.04528359999994791), 
		 thumbnail: 'http://www.tpayneandco.co.uk/wp-content/uploads/2015/08/DSC07579-300x225.jpg'
		},
		{ permalink:'http://www.tpayneandco.co.uk/property/sitting-on-approximately-3-5-acres-stms-this-stunning-detached-house-is-beautifully-presented-inside-and-out/', 
		  price:'£550,000',
		  latLng: new google.maps.LatLng(52.549696, -0.03337540000006811), 
		  thumbnail: 'http://www.tpayneandco.co.uk/wp-content/uploads/2015/08/DSC07451-Custom-300x225.jpg' 
		},
		{ permalink:'http://www.tpayneandco.co.uk/property/this-semi-detached-house-is-offered-for-sale-with-no-upward-chain-2/', title:'This semi detached house is offered for sale with no upward chain.', price:'£120,000', latLng: new google.maps.LatLng(52.6732586, 0.16642780000006496), thumbnail: 'http://www.tpayneandco.co.uk/wp-content/uploads/2015/08/DSC07324-1-Custom-300x225.jpg' },
		{ permalink:'http://www.tpayneandco.co.uk/property/this-beautifully-presented-detached-home-is-offered-for-sale-with-no-upward-chain/', title:'This beautifully presented detached home is offered for sale with no upward chain.', 
		 price:'£315,000', latLng: new google.maps.LatLng(52.4630987, 0.04494669999996859), 
		 thumbnail: 'http://www.tpayneandco.co.uk/wp-content/uploads/2015/06/DSC03984-Custom-300x225.jpg' },

	]);	
		
	markerCluster = new MarkerClusterer(map, newMarkers ,markerClusterOptions); 
	// Maps Fully Loaded: Hide + Remove Spinner
	google.maps.event.addListenerOnce(map, 'idle', function() {
		jQuery('.spinner').fadeTo(800, 0.5);
		
		setTimeout(function() {
		  jQuery('.spinner').remove();
		  
		}, 800);
	});
	
	// Spiderfier
	var oms = new OverlappingMarkerSpiderfier(map, { markersWontMove: true, markersWontHide: true, keepSpiderfied: true, legWeight: 5 });
	
	function omsMarkers( markers ) {
	  for ( var i = 0; i < markers.length; i++ ) {
		 
	  	oms.addMarker( markers[i] );
	  }   
	}
	
	omsMarkers(markers);
		google.maps.event.addDomListener(window, 'load', initMap);
}


//google.maps.event.addDomListener(window, 'resize', initMap);

function initMarkers(map, markerData) {
	
	
	for( var i = 0; i < markerData.length; i++ ) {
		marker = new google.maps.Marker({
	    map: map,
	    position: markerData[i].latLng,
			icon: customIcon,
	    //animation: google.maps.Animation.DROP
		});
		bounds.extend(markerData[i].latLng);
		infoboxOptions = {
	    content: 	'<div class="map-marker-wrapper">'+
	    						'<div class="map-marker-container">'+
		    						'<div class="arrow-down"></div>'+
										'<img src="'+markerData[i].thumbnail+'" />'+
										'<div class="content">'+
										'<a href="'+markerData[i].permalink+'">'+
										//'<h5 class="title">'+markerData[i].title+'</h5>'+
										'</a>'+
										markerData[i].price+
										'</div>'+
									'</div>'+
						    '</div>',
	    disableAutoPan: false,
		  pixelOffset: new google.maps.Size(-33, -90),
		  zIndex: null,
		  isHidden: true,
		  alignBottom: true,
		  closeBoxURL: "http://www.tpayneandco.co.uk/wp-content/themes/realty/lib/images/close.png",
		  infoBoxClearance: new google.maps.Size(25, 25)
		};
		newMarkers.push(marker);
		
		newMarkers[i].infobox = new InfoBox(infoboxOptions);
		//newMarkers[i].infobox.open(map, marker);
	
		google.maps.event.addListener(marker, 'click', (function(marker, i) {
	    return function() {
				
	    	if ( newMarkers[i].infobox.getVisible() ) {
		    	newMarkers[i].infobox.setVisible(false);
	    	}
	    	else {
		    	jQuery('.infoBox').hide();
		    	newMarkers[i].infobox.setVisible(true);
	    	}	    	
	    	
	    	newMarkers[i].infobox.open(map, this);
	      map.panTo(markerData[i].latLng);
	      
	    }
	    
		})( marker, i ) );
		
		google.maps.event.addListener(map, 'click', function() {
	    jQuery('.infoBox').hide();
	  });
		
	}
	// Set Map Bounds And Max. Zoom Level
	google.maps.event.addListenerOnce(map, 'bounds_changed', function(event) {
		map.fitBounds(bounds);
				if (this.getZoom() > 13) {
	    this.setZoom(13);
	  }
	  	});
	
	return newMarkers;
	
} // initMarkers();