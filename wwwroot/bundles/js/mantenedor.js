$(function () {

    $("#crear").click(function () {

        $("#modalCrear").modal("show");

        $("#nombre").removeClass("borde_rojo")
        $("#tipo").removeClass("borde_rojo")

        CargaTipo();

    })

    $("#cancelar").click(function () {
        $("#modalCrear").removeClass("show").addClass("hide");
        $(".modal-backdrop").removeClass("show").addClass("hide");
        $(".modal-backdrop").remove();
    })

    $("#nombre").focusout(function () {
        if ($("#nombre").val() != "") {
            $("#nombre").removeClass("borde_rojo");
        }
    })

    $("#tipo").focusout(function () {
        if ($("#tipo").val() != "") {
            $("#tipo").removeClass("borde_rojo");
        }
    })

    $("#guardar").click(function () {

        var nombre = $("#nombre").val();
        var tipo = $("#tipo").val();
        var fuerza = $("#fuerza").val();
        var desc = $("#desc").val();

        var datos = {
            CartaNombre: nombre,
            TipoID: tipo,
            CartaFuerza: fuerza,
            CartaTexto: desc
        }

        $.ajax({
            type: "POST",
            url: "/Mantenedor/Nuevo",
            cache: false,
            async: true,
            data: datos,
            success: function (res) {

                if (res.status) {

                    alert("Registro completo");

                    setTimeout(() => {
                        location.href = "/Mantenedor/"
                    }, 500)

                } else {
                    if ($("#nombre").val() == "" || null) {
                        $("#nombre").addClass("borde_rojo");
                        alert("El nombre es obligatorio")
                    }

                    if ($("#tipo").val() == "0" || $("#tipo").val() == null) {
                        $("#tipo").addClass("borde_rojo");
                        alert("El tipo es obligatorio")
                    }
                }
            },
            error: function (ex) {

            }

        })

    })

    $("[id^=eliminar_]").click(function () {

        var id = $(this).attr("id").replace("eliminar_", "");
        if (confirm("¿Esta seguro de querer eliminar este registro?")) {
            $.ajax({
                type: "POST",
                url: "/Mantenedor/Eliminar",
                data: { CartaID : id },
                async: true,
                success: function (res) {

                    if (res.status) {

                        alert("Registro eliminado correctamente")

                        setTimeout(() => {

                            location.href = "/Mantenedor/"
                        }, 1000)

                    }

                },
                error: function () {

                }
            })
        }

    })

    $("[id^=editar_]").click(function () {

        var id = $(this).attr("id").replace("editar_", "");

        $.ajax({
            type: "POST",
            url: "/Mantenedor/EditarView",
            data: { CartaID: id },
            async: true,
            success: function (result) {

                $("<div class='modal fade' id='modalEditar'></div>").prependTo(".container")
                $("#modalEditar").modal("show").html(result);

            },
            error: function () {

            }

        })

    })

})



function CargaTipo() {

    $.ajax({
        type: "GET",
        url: "/Mantenedor/GetTipo",
        async: true,
        success: function (res) {
            var select = $("#tipo");
            $.each(res, function (index, data) {
                $("<option value='" + data.tipoID + "'>" + data.tipoTexto + "</option>").appendTo(select);
            })

        },
        error: function () {


        }
    })
}
