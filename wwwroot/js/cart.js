function makeOrder(id) {
	const modal = document.getElementById('modal');
	$.ajax({
		type: 'POST',
		url: '/Cart/Cart',
		data: { 'userId': id },
		success: function (responce) {
			modal.innerHTML = responce
			deleteCart(id)
		},
		failure: function () {
			modal.innerHTML = ''
		}
	});
}

function openModuleDelete() {
	const modal = document.getElementById('modal');
	$.ajax({
		type: 'GET',
		url: '/Cart/ModalDelete',
		success: function (responce) {
			modal.innerHTML = responce
		},
		failure: function (responce) {
			alert('Сталася помилка. Будь ласка, перезагрузіть сторінку.')
		}
	});
}

function deleteItem(userId, itemId) {
	$.ajax({
		type: 'DELETE',
		url: '/Cart/Cart',
		data: { 'userId': userId, 'itemId': itemId },
		success: function (responce) {
			window.location.href = url
		},
		failure: function (responce) {
			alert('Сталася помилка. Будь ласка, перезагрузіть сторінку.')
		}
	});
}

function deleteCart(userId) {
	$.ajax({
		type: 'DELETE',
		url: '/Cart/Cart',
		data: { 'userId': userId },
		success: function (responce) {
			window.location.href = url
		},
		failure: function (responce) {
			alert('Сталася помилка. Будь ласка, перезагрузіть сторінку.')
		}
	});
}