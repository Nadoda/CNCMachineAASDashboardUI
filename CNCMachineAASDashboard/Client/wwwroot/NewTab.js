window.NavigationManagerExtensions = {};
window.NavigationManagerExtensions.openInNewWindow = (url, message) => {
    var newTab = window.open('', '_blank');
    newTab.document.write(message);
    newTab.location.href = url;
} 
window.updateDateTime = () => {
    const element = document.getElementById('dateTimeElement');
    const now = new Date();
    element.innerText = now.toLocaleString();
};