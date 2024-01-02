webexpress.webui.form = {}

/**
 * Adds a progress bar to the form.
 */
webexpress.webui.form.progess = class {

    /**
     * Constructor
     * @param form A form id.
     * @param method The request method is POST.
     */
    constructor(formId, method) {

        const form = $('#' + formId);
        const progress = form.find('.progress');
        const progressBar = progress.children('.progress-bar');

        progressBar.css("width", "0%");

        form.on('submit', (event) => {
            event.preventDefault();
            progress.show();

            const xhr = new XMLHttpRequest();
            xhr.open(method, form.attr('action'));

            xhr.upload.addEventListener('progress', (event) => {
                if (event.lengthComputable) {
                    const percentComplete = (event.loaded / event.total) * 100;
                    progressBar.css("width", percentComplete + "%");
                }
            });

            xhr.onloadend = function () {
                progress.hide();
                progressBar.css("width", "0%");
                form.find('#modal_' + formId).hide();
            };

            xhr.send(new FormData(form.get(0)));
        });
    }
}