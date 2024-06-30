sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/m/MessageToast"
], function (Controller, MessageToast) {
    "use strict";

    return Controller.extend("frontend.controller.NotaFiscal", {

        onInit: function () {
            this.loadNotaFiscal();
        },

        loadNotaFiscal: function () {
            var that = this;
            fetch("http://localhost:5240/api/Nota")
                .then(response => {
                    if (!response.ok) {
                        throw new Error("Network response was not ok");
                    }
                    return response.json();
                })
                .then(data => {
                    console.log("NotaFiscal Data: ", data); // Verifica os dados das notas fiscais
                    that.getClienteNames(data).then(dataWithNames => {
                        console.log("NotaFiscal Data with Cliente Names: ", dataWithNames); // Verifica os dados das notas fiscais com nomes de clientes
                        var oModel = new sap.ui.model.json.JSONModel(dataWithNames);
                        that.getView().setModel(oModel, "notaFiscalModel");
                    });
                })
                .catch(error => {
                    console.error("Failed to load data: ", error.message);
                    MessageToast.show("Failed to load data: " + error.message);
                });
        },

        getClienteNames: function (notaFiscalData) {
            return fetch("http://localhost:5240/api/Cliente")
                .then(response => response.json())
                .then(clienteData => {
                    console.log("Cliente Data: ", clienteData); // Verifica os dados dos clientes
                    var clienteMap = clienteData.reduce((map, cliente) => {
                        map[cliente.id] = cliente.name;
                        return map;
                    }, {});

                    console.log("Cliente Map: ", clienteMap); // Verifica o mapa de clientes

                    return notaFiscalData.map(nota => {
                        console.log("Mapping nota: ", nota); // Verifica cada nota
                        // Acessa o nome do cliente através do mapeamento e o objeto cliente
                        const clienteName = clienteMap[nota.clienteId] || "Desconhecido";
                        return {
                            ...nota,
                            clienteName: clienteName
                        };
                    });
                });
        }
    });
});
