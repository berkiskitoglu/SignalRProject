const ProgressHub = (() => {

    let connection = null;

    function buildProgressBar(label, value, colorClass) {
        return `
            <div class="d-flex justify-content-between mb-1">
                <span class="text-muted">${label}</span>
                <span class="text-muted fw-bold">${value}</span>
            </div>
            <div class="progress mb-2" style="height: 7px;">
                <div class="progress-bar ${colorClass}" role="progressbar"
                     style="width: ${value}%"
                     data-toggle="tooltip" data-placement="top" title="${value}%">
                </div>
            </div>
        `;
    }

    function registerHandlers() {
        connection.on("ReceiveTotalBalance", (val) => $("#totalBalance").text(val));
        connection.on("ReceiveActiveOrderCount", (val) => $("#activeOrderCount").text(val));
        connection.on("ReceiveTableCount", (val) => {
            $("#tableCount").text(val);
            $("#totalMenuTableCountProgress").html(buildProgressBar("Masa Sayısı", val, "bg-success"));
        });
        connection.on("ReceiveAverageProductPrice", (val) => {
            $("#averageProductPrice").html(buildProgressBar("Ortalama Ürün Fiyatı", val, "bg-info"));
        });
        connection.on("ReceiveProductCountByCategoryNameHamburger", (val) => {
            $("#productCountByCategoryNameHamburger").html(buildProgressBar("Burger Sayısı", val, "bg-secondary"));
        });
        connection.on("ReceiveProductCountByCategoryNameDrink", (val) => {
            $("#productCountByCategoryNameDrink").html(buildProgressBar("İçecek Sayısı", val, "bg-warning"));
        });
        connection.on("ReceiveProductCount", (val) => {
            $("#productCount").html(buildProgressBar("Ürün Sayısı", val, "bg-dark"));
        });
        connection.on("ReceiveOrderCount", (val) => {
            $("#orderCount").html(buildProgressBar("Sipariş Sayısı", val, "bg-primary"));
        });
        connection.on("ReceiveActiveCategoryCount", (val) => {
            $("#activeCategoryCount").html(buildProgressBar("Aktif Kategori Sayısı", val, "bg-warning"));
        });
        connection.on("ReceivePassiveCategoryCount", (val) => {
            $("#passiveCategoryCount").html(buildProgressBar("Pasif Kategori Sayısı", val, "bg-success"));
        });
    }

    function init(hubUrl) {
        connection = new signalR.HubConnectionBuilder()
            .withUrl(hubUrl)
            .build();

        registerHandlers();

        connection.start()
            .then(() => {
                setInterval(() => connection.invoke("SendProgress"), 1000);
            })
            .catch((err) => console.error("SignalR Hatası:", err));
    }

    return { init };

})();