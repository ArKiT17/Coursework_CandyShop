function openModal(parameters) {
	const id = parameters.id;
	const url = parameters.url;
	const modal = document.getElementById('modal');

	if (id === undefined || url === undefined) {
		alert("Виникла помилка. Перезапустіть сторінку.");
		return;
	}

	$.ajax({
		type: 'GET',
		url: url,
		data: { 'id': id },
		success: function (responce) {
			modal.innerHTML = responce
		},
		failure: function () {
			modal.innerHTML = ''
		}
	});

	setTimeout(() => {
		const link = document.getElementById('link');
		const image = document.getElementById('image');
		link.addEventListener('input', function () {
			image.src = link.value
		})
	}, 200);
}

function closeModal() {
	document.getElementById('modal').innerHTML = ''
}