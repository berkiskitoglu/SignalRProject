const BookingHub = (() => {

    let connection = null;

    function registerHandlers() {
        connection.on("ReceiveBookingList", (bookingList) => {
            $("#bookingList").empty();
            if (bookingList && bookingList.length > 0) {
                bookingList.forEach((item, index) => {
                    const row = `
                        <tr>
                            <td>${index + 1}</td>
                            <td>${item.name}</td>
                            <td>${item.phone}</td>
                            <td>${item.personCount}</td>
                            <td>${item.mail}</td>
                            <td><span class="badge bg-success">${item.description}</span></td>
                            <td>
                                <a href="/Booking/UpdateBooking/${item.bookingID}" class="btn btn-sm btn-outline-warning">Güncelle</a>
                                <a href="/Booking/DeleteBooking/${item.bookingID}" class="btn btn-sm btn-outline-danger">Sil</a>
                                <a href="/Booking/BookingStatusApproved/${item.bookingID}" class="btn btn-sm btn-outline-success">Onayla</a>
                                <a href="/Booking/BookingStatusCancelled/${item.bookingID}" class="btn btn-sm btn-outline-dark">İptal Et</a>
                            </td>
                        </tr>
                    `;
                    $("#bookingList").append(row);
                });
            } else {
                $("#bookingList").append("<tr><td colspan='7' class='text-center'>Henüz rezervasyon yok</td></tr>");
            }
        });

        connection.on("ReceiveError", (message) => {
            console.error("Hub Hatası:", message);
        });
    }

    function init(hubUrl) {
        connection = new signalR.HubConnectionBuilder()
            .withUrl(hubUrl)
            .withAutomaticReconnect()
            .build();

        registerHandlers();

        connection.start()
            .then(() => {
                connection.invoke("GetBookingList");
                setInterval(() => connection.invoke("GetBookingList"), 1000);
            })
            .catch((err) => console.error("Bağlantı hatası:", err));
    }

    return { init };

})();