

var pagename = window.location.pathname + window.location.search;

var connection = new signalR.HubConnectionBuilder()
    .withUrl('/trackUserHub?pagename=' + pagename)
    .build();

connection.start();

connection.onclose(function () {
    setTimeout(connection.start(), 5000);
});
