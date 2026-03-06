const NotificationHub = (() => {

    let connection = null;

    function formatDate(dateString) {
        const date = new Date(dateString);
        const day = String(date.getDate()).padStart(2, '0');
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const year = date.getFullYear();
        const hours = String(date.getHours()).padStart(2, '0');
        const minutes = String(date.getMinutes()).padStart(2, '0');
        return `${day}.${month}.${year} ${hours}:${minutes}`;
    }

    function registerHandlers() {
        connection.on("ReceiveUnreadNotification", (val) => {
            $("#unreadNotifications").text(val);
        });

        connection.on("ReceiveUnreadNotificationList", (list) => {
            $("#unreadNotificationList").empty();
            list.forEach(item => {
                const notificationItem = `
                    <a>
                        <div class="${item.type}">
                            <i class="${item.icon}"></i>
                        </div>
                        <div class="notif-content">
                            <span class="block">${item.description}</span>
                            <span class="time">${formatDate(item.date)}</span>
                        </div>
                    </a>`;
                $("#unreadNotificationList").append(notificationItem);
            });
        });
    }

    function init(hubUrl) {
        connection = new signalR.HubConnectionBuilder()
            .withUrl(hubUrl)
            .build();

        registerHandlers();

        connection.start()
            .then(() => {
                setInterval(() => connection.invoke("SendNotification"), 1000);
            })
            .catch((err) => console.error("SignalR Hatası:", err));
    }

    return { init };

})();