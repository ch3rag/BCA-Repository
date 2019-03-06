function changeImages() {
	const images = document.querySelectorAll("#image-slider img");
	let i = 0;
	setInterval(() => {
		images[i].className = "hide";
		i = (i + 1) % images.length;
		images[i].className = "show";
	}, 2000);
}

window.onload = function() {
	changeImages();
	
}