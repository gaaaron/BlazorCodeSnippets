/* source: https://learn.microsoft.com/en-us/aspnet/core/blazor/file-downloads?view=aspnetcore-7.0#download-from-a-stream */

window.downloadFileFromStream = async (contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = '';
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
}