let form = document.querySelector("#log-in");
form.addEventListener("submit", () => {
    sessionStorage.setItem("Product-Nmae", form[0].value)
    localStorage.setItem("Product-Nmae", form[0].value)
    document.cookie = `Product-Nmae=${form[0].value}; expires=Thu, 18 Dec 2024 12:00:00 UTC`
});
