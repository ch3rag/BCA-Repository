window.onload = function () {
	changeImages();
	setupButtons();
	loadMenu();
	validate();
}

function changeImages() {
	const images = document.querySelectorAll("#image-slider img");
	let i = 0;
	setInterval(() => {
		images[i].className = "hide";
		i = (i + 1) % images.length;
		images[i].className = "show";
	}, 2000);
}

function setupButtons() {

	const login = document.querySelector("#login-btn");
	const home = document.querySelector("#home-btn");
	const signUp = document.querySelector("#signup-btn");
	const loginBox = document.querySelector("#login");
	const about = document.querySelector("#about-btn");
	const aboutBox = document.querySelector("#about");
	const quoteBox = document.querySelector("#quote-container");
	const signUpBox = document.querySelector("#sign-up");
	const menu = document.querySelector("#menu-btn");
	const menuBox = document.querySelector("#menu");
	const credits = document.querySelector("#credits-btn");
	const creditsBox = document.querySelector("#credits");
	let currentCard = quoteBox;

	login.addEventListener("click", () => switchTo(loginBox));
	home.addEventListener("click", () => switchTo(quoteBox));
	signUp.addEventListener("click", () => switchTo(signUpBox));
	menu.addEventListener("click", () => switchTo(menuBox));
	about.addEventListener("click", () => switchTo(aboutBox));
	credits.addEventListener("click", () => switchTo(creditsBox));

	function switchTo(box) {
		currentCard.classList.remove("show");
		currentCard.classList.add("hide");
		box.classList.remove("hide");
		box.classList.add("show");
		currentCard = box;
	}
}

function loadMenu() {
	const menu = ["cake", "cookies", "cupcakes", "pastry", "pie"];
	const pie = ["Apple Pie", "Blueberry Pie", "Boston Cream Pie", "Butter Milk Pie", "Cherry Pie", "Chocolate Cream Pie", "Coconut Cream Pie", "Hedgehog Cream Pie"];
	const cake = ["Chocolate Cheese Cake", "Special Vanilla Cake", "Creamy Vanilla Fruit Cake", "Rasmalai Cake", "Chocolate Paan Cake", "Chocolate Creamy Cake", "Mango Cream Cake", "Furbished Choco ButterScotch"];
	const cookies = ["Oats Cookies", "Milk Kaju Cookies", "Marble Cookies", "Dry Fruit Cookies", "Chocolate Kaju Cookies", "Choco Chip Cookies", "Milk Pista Cookies", "Suger Free Multigrain Cookies"];
	const cupcakes = ["Blackforest Cupcake", "Butterscotch Cupcake", "Caramel Cupcake", "Chocolate Caramel Cupcake", "Chocolate Cherry Cupcake", "Chocolate Cupcake", "Chocolate Peanut Butter Cupcake", "Chocolate Rainbow Cupcake"];
	const pastry = ["Blackforest Egg Pastry", "Red Velvet Pastry", "Kshanji Pastry", "Fantasy Pastry", "Belgium Chocolate Pastry", "Truffle Eggless Pastry", "Chocolate Eggless Pastry", "Pineapple Egg Pastry"];
	const menuDiv = document.querySelector("#menu");
	let activeMenu = document.querySelectorAll("#cat-bar img")[0];
	for (let i = 0; i < menu.length; i++) {
		const catDiv = document.createElement("div");
		catDiv.className = "cat-container hide";
		catDiv.id = menu[i];
		menuDiv.appendChild(catDiv);
		for (let j = 0; j < 8; j++) {
			const newDiv = document.createElement("div");
			const img = document.createElement("img");
			const name = document.createElement("p");
			name.innerText = eval(`${menu[i]}[j]`);;
			img.src = `./images/products/${menu[i]}/${j + 1}.jpg`;
			newDiv.className = "item-card vsmall roboto";
			newDiv.appendChild(img);
			newDiv.appendChild(name);
			catDiv.appendChild(newDiv);
		}
	}
	document.querySelector("#cake").classList.remove("hide");
	document.querySelector("#cake").classList.add("show");
	let currentCat = "cake";
	document.querySelector("#cat-bar").addEventListener("click", (e) => {
		const pattern = new RegExp(/(\w+).png/g);
		if (e.target.src) {
			activeMenu.classList.remove("active");
			activeMenu = e.target;
			activeMenu.classList.add("active");
			document.getElementById(currentCat).classList.remove("show");
			document.getElementById(currentCat).classList.add("hide");
			let elem = document.getElementById(currentCat = pattern.exec(e.target.src)[1])
			elem.classList.remove("hide");
			elem.classList.add("show");
		}
	});
}

function validate() {

	const signUpForm = document.forms.signUp;
	new Array(signUpForm).forEach(x => x.addEventListener("keyup", e => testValue(e)));
	new Array(signUpForm).forEach(x => x.addEventListener("blur", e => testValue(e)));
	signUpForm.dob.addEventListener("change", e => testValue(e));
	document.querySelector("#submit").addEventListener("click", (e) => {
		e.preventDefault();
		!testValues() ? alert("Invalid Details") : alert("Sign Up Successful");
	});

	const usernameCritera = new RegExp(/^[a-zA-Z][a-zA-Z0-9_\.]{7,}$/);
	const passwordCritera = new RegExp(/^[a-zA-Z0-9\._@]{8,}$/);
	const email = new RegExp(/^[a-zA-Z0-9_\.]+@[a-zA-Z0-9]+(\.[a-zA-Z]+)+$/);
	const today = new Date();

	function testValue(e) {
		switch (e.target.name) {
			case "username":
				test(testName, e.target); break;
			case "password":
				test(testPass, e.target); break;
			case "retypePassword":
				test(testRetype, e.target); break;
			case "email":
				test(testMail, e.target); break;
			case "dob":
				test(testDob, e.target); break;
		}
	}

	function testValues() {
		let testRet = true;
		testRet &= test(testName, signUpForm.username);
		testRet &= test(testPass, signUpForm.password);
		testRet &= test(testRetype, signUpForm.retypePassword);
		testRet &= test(testMail, signUpForm.email);
		testRet &= test(testDob, signUpForm.dob);
		return testRet;
	}

	function testName(v) { return usernameCritera.test(v); }
	function testPass(v) { return passwordCritera.test(v); }
	function testRetype(v) { return (testPass(v) && signUpForm.password.value === v); }
	function testMail(v) { return email.test(v) }
	function testDob(v) { return (Math.abs(today.getFullYear() - new Date(v).getFullYear()) > 12); }

	function test(func, target) {
		if (func(target.value)) {
			target.classList.remove("error");
			return true;
		} else {
			target.classList.add("error");
			return false;
		}
	}
}