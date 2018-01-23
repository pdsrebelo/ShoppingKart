function addItemClick(elem, addUrl, removeUrl) {
    var name = elem.val();
    if (name) {
        var id = $("#itemId_" + name).val();
        var quantity = $("#quantity_" + name).val();
        var objData = { id: id, name: name, quantity: quantity }

        if (quantity > 0) {
            $.ajax({
                url: addUrl,
                data: objData,
                success: function (result) {
                    var tr = $('#shoppingCartItem_' + result.newModel.Name);

                    // Bind the result to the shopping cart area
                    if (tr.length > 0) {
                        tr.find("td[name='quantity']").text(result.newModel.Quantity);
                    } else {
                        $("#shoppingCartItems").append(
                            '<tr id="shoppingCartItem_' + result.newModel.Name + '">' +
                                '<td name="quantity">' + result.newModel.Quantity + '</td>' +
                                '<td>' + result.newModel.Name + '</td>' +
                                '<td>' +
                                    '<button name="removeItem" value="' + result.newModel.Name + '" type="button" class="btn btn-sm btn-danger">-</button>' + 
                                '</td>' +
                            '</tr>');

                        $("button[name='removeItem']").click(function () {
                            removeItemClick($(this), removeUrl);
                        });
                    }

                    // Update the shopping cart total
                    $("#shoppingCartTotal").text(result.total.toFixed(2));
                }
            });
        }
    }
}

function removeItemClick(elem, url) {
    var name = elem.val();
    if (name) {
        $.ajax({
            url: url,
            data: { name: name },
            success: function (result) {
                if (result.success === true) {
                    // Remove this item from the list
                    $('#shoppingCartItem_' + name).remove();

                    // Update the shopping cart total
                    $("#shoppingCartTotal").text(result.total.toFixed(2));
                }
            }
        });
    }
}