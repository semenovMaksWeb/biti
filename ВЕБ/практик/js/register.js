const buttonOk = document.querySelector("button.register");
const buttonCancel = document.querySelector("button.cancel");
const form = document.querySelector("form[name=register]");

if (buttonOk) {
    buttonOk.onclick = (e) => {
        let params = "";
        e.preventDefault();
        const formData = new FormData(form);
        if (formData) {
            for (const data of formData.entries()) {
                if (data[1]) {
                    if (data[0] == "checkBxodOne") {
                        const val = data[1] == "one" ? true : false;
                        params += `${data[0]}=${val}&`
                        continue;
                    }
                    params += `${data[0]}=${data[1]}&`
                }
            }
        }
        window.location.replace(`./index.html?${params}`)
    }
}
if (buttonCancel) {
    buttonCancel.onclick = (e) => {
        e.preventDefault();
        form.reset();
    }
}