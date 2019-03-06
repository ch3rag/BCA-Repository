window.onload = function() {
	let i = 0;
	const images = document.querySelectorAll("#main-image-slider img");
	setInterval(() => {
		images[i].classList = "hidden";
		i = (i + 1) % images.length;
		images[i].classList = "show";
		images[(i + 1) % images.length].classList = "hidden-right"
	}, 3000);
}