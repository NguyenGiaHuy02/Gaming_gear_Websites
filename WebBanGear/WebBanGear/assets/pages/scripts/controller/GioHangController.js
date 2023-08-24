var cart = {
    init: function(){
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function (){
            window.location.href = "/";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        $('#btnLogin').off('click').on('click', function () {
            window.location.href = "/dang-nhap";
        });
        $('#btnLoginPage').off('click').on('click', function () {
            window.location.href = "/dang-nhap";
        });
        $('#btnPaymentPage').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.form-control.input-sm.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    sanpham: {
                        MaSanPham: $(item).data('id')  
                    }
                });
            });      
            $.ajax({
                url: '/GioHang/Update',
                data: { giohangModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
        $('.del-goods').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { masp: $(this).data('id') },
                url: '/GioHang/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function () {
            $.ajax({
                url: '/GioHang/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/";
                    }
                }
            })
        });
    }
}
cart.init();