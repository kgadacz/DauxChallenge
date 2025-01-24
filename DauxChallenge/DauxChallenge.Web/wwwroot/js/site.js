(function () {
    'use strict';
    var forms = document.querySelectorAll('.needs-validation');
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                var nombreInput = document.getElementById('nombre');
                var apellidoInput = document.getElementById('apellido');
                var isValid = true;

                nombreInput.classList.remove('is-valid', 'is-invalid');
                apellidoInput.classList.remove('is-valid', 'is-invalid');

                if (nombreInput.value.length < 3) {
                    nombreInput.classList.add('is-invalid');
                    isValid = false;
                } else {
                    nombreInput.classList.add('is-valid');
                }

                if (apellidoInput.value.length < 3) {
                    apellidoInput.classList.add('is-invalid');
                    isValid = false;
                } else {
                    apellidoInput.classList.add('is-valid');
                }

                if (!isValid) {
                    event.preventDefault();
                    event.stopPropagation();
                }
            }, false);

            form.querySelectorAll('#nombre, #apellido').forEach(function (input) {
                input.addEventListener('input', function () {
                    this.classList.remove('is-valid', 'is-invalid');
                    if (this.value.length < 3) {
                        this.classList.add('is-invalid');
                    } else {
                        this.classList.add('is-valid');
                    }
                });
            });
        });
})();