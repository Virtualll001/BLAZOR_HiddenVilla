window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operace proběhla úspěšně", {timeOut: 10000});
    }
    if (type === "error") {
        toastr.error(message, "Operace selhala", {timeOut: 10000});
    }
}



window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Operace se zdařila',
            message,
            'success' //Swal zobrazí success ikonu = tenhle řádek neměnit!
        )
    }
    if (type === "error") {
        Swal.fire(
            'Operace se nezdařila',
            message,
            'error'            
        )
    }
}






