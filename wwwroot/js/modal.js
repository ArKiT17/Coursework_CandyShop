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
		if (link != null) 
			link.addEventListener('input', function () {
				image.src = link.value
			})
	}, 200);
}

function closeModal() {
	document.getElementById('modal').innerHTML = ''
}

function deleteObject(id) {
	if (id === undefined) {
		alert("Виникла помилка. Перезапустіть сторінку.");
		return;
	}

	$.ajax({
		type: 'DELETE',
		url: window.location.href,
		data: { 'id': id },
		success: function (responce) {
			modal.innerHTML = ''
			window.location.href = '/Admin/Items'
		}
	});
}