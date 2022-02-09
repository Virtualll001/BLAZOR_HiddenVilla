window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operace proběhla úspěšně", { timeOut: 10000 });
    }
    if (type === "error") {
        toastr.error(message, "Operace selhala", { timeOut: 10000 });
    }
}