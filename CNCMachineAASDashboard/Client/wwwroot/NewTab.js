window.NavigationManagerExtensions = {};
window.NavigationManagerExtensions.openInNewWindow = (url, message) => {
    var newTab = window.open('', '_blank');
    newTab.document.write(message);
    newTab.location.href = url;
} 