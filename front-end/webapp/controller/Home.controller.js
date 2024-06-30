sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/m/MessageToast"
], function (Controller, MessageToast) {
    "use strict";

    return Controller.extend("frontend.controller.Home", {

        onInit: function () {
            this.loadClientes();
        },

        loadClientes: function () {
            var that = this;
            fetch("http://localhost:5240/api/Cliente")
                .then(response => {
                    if (!response.ok) {
                        throw new Error("Network response was not ok");
                    }
                    return response.json();
                    console.log(response)
                })
                .then(data => {
                    var oModel = new sap.ui.model.json.JSONModel(data);
                    that.getView().setModel(oModel, "clientesModel");
                })
                .catch(error => {
                    MessageToast.show("Failed to load data: " + error.message);
                });
        }
    });
});
