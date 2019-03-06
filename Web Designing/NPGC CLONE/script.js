window.onload = function() {
	let curDate = new Date();
	const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    document.getElementById("time").innerHTML = days[curDate.getDay()] + ", " + months[curDate.getMonth()] + " " + curDate.getDate() + ", " + curDate.getFullYear();
	console.log(curDate.toString());
}