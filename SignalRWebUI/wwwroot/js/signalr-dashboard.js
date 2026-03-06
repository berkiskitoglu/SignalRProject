const StatisticsHub = (() => {

    let connection = null;

    function registerHandlers() {
        connection.on("ReceiveCategoryCount", (val) => $("#categorycount").text(val));
        connection.on("ReceiveProductCount", (val) => $("#productCount").text(val));
        connection.on("ReceiveActiveCategoryCount", (val) => $("#activeCategoryCount").text(val));
        connection.on("ReceivePassiveCategoryCount", (val) => $("#passiveCategoryCount").text(val));
        connection.on("ReceiveProductCountByCategoryNameHamburger", (val) => $("#productCountByCategoryNameHamburger").text(val));
        connection.on("ReceiveProductCountByCategoryNameDrink", (val) => $("#productCountByCategoryNameDrink").text(val));
        connection.on("ReceiveProductPriceAvg", (val) => $("#avgProductPrice").text(val));
        connection.on("ReceiveProductNameByMinPrice", (val) => $("#productNameByMinPrice").text(val));
        connection.on("ReceiveAvgHamburgerPrice", (val) => $("#avgHamburgerPrice").text(val));
        connection.on("ReceiveOrderCount", (val) => $("#orderCount").text(val));
        connection.on("ReceiveActiveOrderCount", (val) => $("#activeOrderCount").text(val));
        connection.on("ReceiveLastOrderPrice", (val) => $("#lastOrderPrice").text(val));
        connection.on("ReceiveTotalMoneyCase", (val) => $("#totalMoneyCase").text(val));
        connection.on("ReceiveTotalTableCount", (val) => $("#totalTableCount").text(val));
        connection.on("ReceiveProductNameByMaxPrice", (val) => $("#productNameByMaxPrice").text(val));
    }

    function init(hubUrl) {
        connection = new signalR.HubConnectionBuilder()
            .withUrl(hubUrl)
            .build();

        registerHandlers();

        connection.start()
            .then(() => {
                setInterval(() => connection.invoke("SendStatistics"), 1000);
            })
            .catch((err) => console.error("SignalR Hatası:", err));
    }

    return { init };

})();