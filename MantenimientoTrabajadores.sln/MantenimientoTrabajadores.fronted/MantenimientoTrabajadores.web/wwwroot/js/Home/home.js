document.addEventListener("DOMContentLoaded", () => {
    var isValidacionNombre = 0;
    var isValidacionDocumento = 0;
    var isValidacionDepartamento = 0;
    var isValidacionProvincia = 0;
    var isValidacionDistrito = 0;
    var isValidacionSexo = 0;
    const departamento = document.getElementById("departamento");
    const provincia = document.getElementById("provincia");
    const distrito = document.getElementById("distrito");
    const nombreInput = document.getElementById("nombreInput");
    const documentoInput = document.getElementById("documentoInput");
    const sexoSeleccionado = document.querySelector('input[name="sexo"]:checked');
    const radiosSexo = document.querySelectorAll('input[name="sexo"]');


    departamento.addEventListener("change", async () => {
        const id = departamento.value;
        provincia.innerHTML = "";
        distrito.innerHTML = "";

        if (id) {
            const response = await fetch(`/Home/GetProvincias?id=${id}`);
            const data = await response.json();

            data.forEach(p => {
                const option = document.createElement("option");
                option.value = p.id;
                option.textContent = p.nombreProvincia;
                provincia.appendChild(option);
            });
        }
        provincia.value = "0";
    });

    provincia.addEventListener("change", async () => {
        const id = provincia.value;
        distrito.innerHTML = "";

        if (id) {
            const response = await fetch(`/Home/GetDistritos?id=${id}`);
            const data = await response.json();

            data.forEach(d => {
                const option = document.createElement("option");
                option.value = d.id;
                option.textContent = d.nombreDistrito;
                distrito.appendChild(option);
            });
        }
        distrito.value = "0"
    });


    btnCancelar.addEventListener("click", function () {

        departamento.value = "0";

        provincia.innerHTML = '<option value="0">Seleccione provincia</option>';
        distrito.innerHTML = '<option value="0">Seleccione distrito</option>';

        nombreInput.classList.remove("is-invalid"); 
        documentoInput.classList.remove("is-invalid");
        departamento.classList.remove("is-invalid");
        provincia.classList.remove("is-invalid");
        distrito.classList.remove("is-invalid");

        nombreInput.value = "";
        documentoInput.value = "";
    });



    //validaciones
    document.getElementById("btnGuardar").addEventListener("click",  function (e) {
        e.preventDefault();

         Guardar();

    });

    function Guardar() {

        if (nombreInput.value.trim() === "") {
            isValidacionNombre = 0;
            nombreInput.classList.add("is-invalid");
        } else {
            isValidacionNombre = 1;
            nombreInput.classList.remove("is-invalid");
        }

        nombreInput.addEventListener("input", limpiarValidacion);
        nombreInput.addEventListener("focus", limpiarValidacion);

        if (documentoInput.value.trim() === "") {
            isValidacionDocumento = 0;
            documentoInput.classList.add("is-invalid");
        } else {
            isValidacionDocumento = 1;
            documentoInput.classList.remove("is-invalid");
        }

        documentoInput.addEventListener("input", limpiarValidacion);
        documentoInput.addEventListener("focus", limpiarValidacion);

        if (departamento.value === "0") {
            departamento.classList.add("is-invalid");
            isValidacionDepartamento = 0;
        } else {
            isValidacionDepartamento = 1;
            departamento.classList.remove("is-invalid");
        }

        if (provincia.value === "0") {
            provincia.classList.add("is-invalid");
            isValidacionProvincia = 0;
        } else {
            isValidacionProvincia = 1;
            provincia.classList.remove("is-invalid");
        }

        if (distrito.value === "0") {
            distrito.classList.add("is-invalid");
            isValidacionDistrito = 0;
        } else {
            isValidacionDistrito = 1;
            distrito.classList.remove("is-invalid");
        }

        departamento.addEventListener("change", () => {
            if (departamento.value !== "0") {
                departamento.classList.remove("is-invalid");
            }
        });

        provincia.addEventListener("change", () => {
            if (provincia.value !== "0") {
                provincia.classList.remove("is-invalid");
            }
        });

        distrito.addEventListener("change", () => {
            if (distrito.value !== "0") {
                distrito.classList.remove("is-invalid");
            }
        });

        const sexoValido = validarSexo();

        radiosSexo.forEach(radio => {
            radio.addEventListener("change", function () {
                if (radio.checked) {
                    radiosSexo.forEach(r => r.classList.remove("is-invalid"));
                }
            });
        });

        if (sexoValido) {
            isValidacionSexo = 1;
        }

        //console.info(isValidacionNombre + isValidacionDocumento + isValidacionDepartamento + isValidacionProvincia + isValidacionDistrito + isValidacionSexo)

        if (isValidacionNombre === 1 && isValidacionDocumento === 1 && isValidacionDepartamento === 1 && isValidacionProvincia === 1 && isValidacionDistrito === 1 && isValidacionSexo === 1) {
            guardarTrabajador()
        }
    }

    function limpiarValidacion() {
        if (nombreInput.value.trim() !== "") {
            nombreInput.classList.remove("is-invalid");
        }
        if (documentoInput.value.trim() !== "") {
            documentoInput.classList.remove("is-invalid");
        }
        
    }

    function validarSexo() {
        
        const sexoSeleccionado = document.querySelector('input[name="sexo"]:checked');
        const radios = document.querySelectorAll('input[name="sexo"]');
        const errorMsg = document.getElementById('sexoError');

        if (!sexoSeleccionado) {
            radios.forEach(r => r.classList.add("is-invalid"));
            errorMsg.classList.remove("d-none");
            return false;
        } else {
            radios.forEach(r => r.classList.remove("is-invalid"));
            errorMsg.classList.add("d-none");
            return true;
        }
    }

    //funcion guardar
     function guardarTrabajador() {
        const tipoDocumento = "DNI";
        const nroDocumento = document.getElementById("documentoInput").value.trim();
        const nombres = document.getElementById("nombreInput").value.trim();
        const departamento = document.getElementById("departamento").value;
        const provincia = document.getElementById("provincia").value;
        const distrito = document.getElementById("distrito").value;
        const sexo = document.querySelector('input[name="sexo"]:checked');
        const valorSexo = sexo?.defaultValue ?? "";
        

         const trabajador = {
             tipoDocumento: "DNI",
             numeroDocumento: nroDocumento,
             nombres: nombres,
             sexo: valorSexo,
             departamento: departamento,
             provincia: provincia,
             distrito: distrito
         };

        console.info(trabajador);
        
        if (!tipoDocumento || !nroDocumento || !nombres || departamento === "0" || provincia === "0" || distrito === "0" || !valorSexo) {
            return;
        }

         guardarTrabajadorAsycn(trabajador);
    }
});

async function guardarTrabajadorAsycn(trabajador) {
    try {
        const response = await fetch("Trabajador/Crear", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(trabajador)
        });

        if (response.ok) {
            location.reload();
        } else {
            const errorText = await response.text();

        }
    } catch (error) {
        console.error("Error:", error);
    }
}