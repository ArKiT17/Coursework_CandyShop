function makeOrder(id) {
	const modal = document.getElementById('modal');
	$.ajax({
		type: 'POST',
		url: '/Cart/Cart',
		data: { 'userId': id },
		success: function (responce) {
			modal.innerHTML = responce
		},
		failure: function () {
			modal.innerHTML = ''
		}
	});
}

function closeModalSender(userId) {
	document.getElementById('modal').innerHTML = ''
	deleteCart(userId)
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
			window.location.href = window.location.href
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
			window.location.href = window.location.href
		},
		failure: function (responce) {
			alert('Сталася помилка. Будь ласка, перезагрузіть сторінку.')
		}
	});
}

function addItemToCart(itemId, userId) {
	$.ajax({
		type: 'POST',
		url: '/Cart/AddItem',
		data: { 'itemId': itemId, 'userId': userId },
		success: function (responce) {
			window.location.href = '/Cart/Cart'
		},
		failure: function (responce) {
			alert('Сталася помилка. Будь ласка, перезагрузіть сторінку.')
		}
	});
}