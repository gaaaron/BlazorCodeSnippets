window.getHighlightedText = function (text) {
    return hljs.highlightAuto(text).value;
}