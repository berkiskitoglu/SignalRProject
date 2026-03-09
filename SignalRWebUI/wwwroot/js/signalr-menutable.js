const MenuTableStatusHub = (() => {
    let connection = null;

    function registerHandlers() {
        connection.on("ReceiveMenuTableStatus", (menuTableStatusList) => {
            updateMenuTableUI(menuTableStatusList);
        });

        connection.on("ReceiveError", (message) => {
            console.error("Hub Hatası:", message);
            showErrorMessage(message);
        });

        connection.onreconnecting(() => {
            console.log("Yeniden bağlanılıyor...");
        });

        connection.onreconnected(() => {
            console.log("Yeniden bağlandı");
        });

        connection.onclose(() => {
            console.log("Bağlantı kapandı");
            setTimeout(() => connection.start(), 5000);
        });
    }

    function updateMenuTableUI(menuTableStatusList) {
        $("#menuTableContainer").empty();

        if (menuTableStatusList && menuTableStatusList.length > 0) {
            menuTableStatusList.forEach((item) => {
                const card = createMenuTableCard(item);
                $("#menuTableContainer").append(card);
            });
        } else {
            $("#menuTableContainer").append(
                "<div class='col-12 text-center'>" +
                "<p>Masa bilgisi yükleniyor...</p>" +
                "</div>"
            );
        }
    }

    function createMenuTableCard(item) {
        const color = item.status ? "card-success" : "card-danger";
        const statusText = item.status ? "Masa Dolu" : "Masa Boş";
        const iconClass = item.status ? "la-check-circle" : "la-times-circle";

        return `
            <div class="col-md-3">
                <div class="card card-stats ${color}">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-5">
                                <div class="icon-big text-center">
                                    <i class="la ${iconClass}"></i>
                                </div>
                            </div>
                            <div class="col-7 d-flex align-items-center">
                                <div class="numbers">
                                    <p class="card-category">${item.name}</p>
                                    <h4 class="card-title">${statusText}</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        `;
    }

    function showErrorMessage(message) {
        const alert = `
            <div class="alert alert-danger alert-dismissible fade show" role="alert">
                <i class="la la-exclamation-triangle"></i> ${message}
                <button type="button" class="close" data-dismiss="alert">
                    <span>&times;</span>
                </button>
            </div>
        `;
        $(".page-title").after(alert);
        setTimeout(() => $(".alert").fadeOut(), 5000);
    }

    function init(hubUrl) {
        connection = new signalR.HubConnectionBuilder()
            .withUrl(hubUrl)
            .withAutomaticReconnect()
            .build();

        registerHandlers();

        connection.start()
            .then(() => {
                console.log("SignalR bağlantısı başarılı");
                connection.invoke("GetMenuTableStatus");
                setInterval(() => connection.invoke("GetMenuTableStatus"), 2000);
            })
            .catch((err) => console.error("Bağlantı hatası:", err));
    }

    return { init };
})();