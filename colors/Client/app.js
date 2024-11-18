let localColorData = [];

$(document).ready(function () {
    fetchColorsData();

    $("#datatable tbody").sortable({
        update: function (event, ui) {
            updatePresentationOrder();
        }
    }).disableSelection();
});

function fetchColorsData() {
    $.ajax({
        url: "https://localhost:7148/api/colors/getallcolors",
        dataType: "json",
        success: function (data) {
            localColorData = data;
            const $tableBody = $('#datatable tbody');
            $tableBody.empty();
            $.each(localColorData, function (index, color) {
                const stockStatus = color.isInStock ? '✔' : '✘';
                const htmlRow = `
                <tr id="${color.colorId}">
                    <td>${color.colorName}</td> 
                    <td>${color.price}</td>
                    <td>${color.presentationOrder}</td>
                    <td>${stockStatus}</td>
                    <td>
                        <button class="btn btn-info" onclick="onEditColor(${color.colorId})">
                            <img src="./pen.png" alt="Edit" id="icon">
                        </button>
                    </td>
                    <td>
                        <button class="btn btn-danger" onclick="onDeleteColor(${color.colorId})">
                            <img src="./recycle-bin.png" alt="Delete" id="icon">
                        </button>
                    </td>
                </tr>`;
                $tableBody.append(htmlRow);
            });
            $('#totalColorsNumber').text(localColorData.length);
        },
        error: function (err) {
            console.error("Error fetching colors:", err);
        }
    });
}

function onAddNewColor() {
    let colorData = {
        colorName: $("#colorNameInput").val(),
        price: parseInt($("#colorPriceInput").val()),
        presentationOrder: parseInt($("#presentationOrderInput").val()),
        isInStock: $("#isInStockInput").is(":checked")
    };
    $.ajax({
        url: "https://localhost:7148/api/colors/addNewColor",
        contentType: "application/json",
        type: "POST",
        data: JSON.stringify(colorData),
        success: function (newColorId) {
            console.log(newColorId);
            colorData.colorId = newColorId;
            localColorData.push(colorData);
            fetchColorsData(); 
        },
        error: function (err) {
            console.log("Error:", err);
        }
    });
}

function checkFormValidation() {
    let valid = true;
    $(".allCaution").css("visibility", "hidden");

    if (!$('#colorNameInput').val().match(/^[A-Za-z\u0590-\u05FF ]+$/)) { //only English Hebrew characters or spaces
        showError('#caution1b', 'Please enter a valid name');
        valid = false;
    }

    if (localColorData.some(e => e.colorName === $('#colorNameInput').val())) { //checks if the color name already exists
        showError('#caution1b', 'Name already exists');
        valid = false;
    }

    if (!$('#colorPriceInput').val().match(/^\d+$/)) { //ensures that the field is numeric
        showError('#caution2', 'Please enter a valid price');
        valid = false;
    }

    if (!$('#presentationOrderInput').val().match(/^\d+$/)) { //ensures that the field is numeric
        showError('#caution3', 'Please enter a valid order');
        valid = false;
    }

    if (valid) {
        onAddNewColor();
        clearForm();
    }
}

function onDeleteColor(colorId) {
    $.ajax({
        url: "https://localhost:7148/api/colors/deleteColor",
        contentType: "application/json",
        type: "POST",
        data: JSON.stringify({ colorId }),
        success: function () {
            $(`#${colorId}`).remove();
            localColorData = localColorData.filter(color => color.colorId !== colorId);
            $('#totalColorsNumber').text(localColorData.length);
        },
        error: function (err) {
            console.log("Error:", err);
        }
    });
}

function onEditColor(colorId) {
    const color = localColorData.find(c => c.colorId === colorId);
    $("#colorNameInput").val(color.colorName); 
    $("#colorPriceInput").val(color.price);
    $("#presentationOrderInput").val(color.presentationOrder);
    $("#isInStockInput").prop("checked", color.isInStock);

    $("#colorIdHiddenInput").val(colorId);
}

function editColorInDB() {
    const colorId = parseInt($("#colorIdHiddenInput").val()); 
    if (isNaN(colorId)) {
        console.error("Invalid color ID");
        return;
    }

    const updatedData = {
        colorId: colorId,
        colorName: $("#colorNameInput").val(),
        price: parseInt($("#colorPriceInput").val()),
        presentationOrder: parseInt($("#presentationOrderInput").val()),
        isInStock: $("#isInStockInput").is(":checked")
    };

    $.ajax({
        url: "https://localhost:7148/api/colors/editColor",
        contentType: "application/json",
        type: "POST",
        data: JSON.stringify(updatedData),
        success: function () {
            fetchColorsData();
            clearForm();
        },
        error: function (err) {
            console.error("Error updating color:", err);
        }
    });
}

function showError(element, message) {
    $(element).css("visibility", "visible").text(message);
}

function clearForm() {
    $('#colorNameInput, #colorPriceInput, #presentationOrderInput').val('');
    $("#isInStockInput").prop("checked", false);
}

function updatePresentationOrder() {
    $("#datatable tbody tr").each(function (index) {
        $(this).find("td:nth-child(3)").text(index + 1); // Update in the frontend 
    });

}