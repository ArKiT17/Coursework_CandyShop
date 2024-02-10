window.addEventListener('load', function () {
	let divs = this.document.getElementsByTagName('div')
	for (let i of divs) {
		if (i.style.height == '65px') {
			i.style.display = 'none'
		}
	}
})