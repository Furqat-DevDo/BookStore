document.addEventListener('DOMContentLoaded', function () {
    var uploadButton = document.getElementById('uploadButton');

    if (uploadButton) {
        uploadButton.addEventListener('click', function (e) {
            e.preventDefault();

            var modelInput = document.getElementById('model1');
            var formData = new FormData();
            formData.append('file', modelInput.files[0]);

            var xhr = new XMLHttpRequest();
            xhr.open('POST', '/File/Upload', true);

            xhr.onload = function () {
                if (xhr.status === 200) {
                    var response = JSON.parse(xhr.responseText);
                    if (response !== '') {
                        document.getElementById('CoverImageSrc').value = response;
        
                    }else {
                         console.log("Response was :" + response);
                    } 
                }else {
                    console.log("Server Response was :" + xhr.status);
                }
            };

            xhr.onerror = function () {
                
            };

            xhr.send(formData);
        });
    }
});


document.addEventListener('DOMContentLoaded', function () {
    var uploadButton = document.getElementById('uploadButton2');

    if (uploadButton) {
        uploadButton.addEventListener('click', function (e) {
            e.preventDefault();

            var modelInput = document.getElementById('model2');
            var formData = new FormData();
            formData.append('file', modelInput.files[0]);

            var xhr = new XMLHttpRequest();
            xhr.open('POST', '/File/Upload', true);

            xhr.onload = function () {
                if (xhr.status === 200) {
                    var response = JSON.parse(xhr.responseText);
                    if (response !== '') {
                        document.getElementById('BookFileSrc').value = response;
                    } else {
                         console.log("Response was :" + response);
                    }
                } else {
                    console.log("Server Response was :" + xhr.status);
                } 
            };

            xhr.onerror = function () {
               
            };

            xhr.send(formData);
        });
    }
});
