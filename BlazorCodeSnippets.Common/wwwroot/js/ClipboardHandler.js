class ClipboardHandler {
    static dotNetHelper;

    static initialize(value) {
        ClipboardHandler.dotNetHelper = value;

        document.addEventListener('paste', async (e) => {

            // Prevent the default behavior, so you can code your own logic.
            e.preventDefault();

            if (!e.clipboardData.files.length) {
                var clipboardText = e.clipboardData.getData('Text');
                await ClipboardHandler.dotNetHelper.invokeMethodAsync('TextPastedCallback', clipboardText);
            }
            else {
                // Iterate over all pasted files.
                Array.from(e.clipboardData.files).forEach(async (file) => {
                    var fileContent = await file.text();
                    await ClipboardHandler.dotNetHelper.invokeMethodAsync('FilePastedCallback', file.name, fileContent);
                });
            }
        });
    }

    static async copyTextToClipboard(text) {
        navigator.clipboard.writeText(text);
    }
}

window.ClipboardHandler = ClipboardHandler;