## Socket.io server
Socket.IO enables real-time bidirectional event-based communication. It consists of:

* Node.js server
* a JS client library for the browser.

To know more about the capabilities of socket.IO refer [socket.IO webpage](https://github.com/Rocher0724/socket.io-unity)


Within Unity, the socket.io package is provided with the SHMART toolkit. However, if you find any problem with the package then you can download and install socket.io package from Unity asset store. 

* Api Compatibility Level: .Net 4.x

Setup the server using the code below:


    var io = require('socket.io')({
        transports: ['websocket'],
    });

    //port number 
    io.attach(4567);

    //Connection establishment function

    io.sockets.on('connection', function(socket){
 
    //acknowledgement of connection
    console.log('User connected: ' + socket.id);
	socket.emit('ConnectionEstablished', {id: socket.id});

    //test function to check the succesful connection
    socket.on('beep', function(){
     socket.emit("boop");
    });

    //Incoming message from viewer application
    socket.on('ViewerMessage', function(data){
        console.log(data.name+" , "+data.position+" , "+data.rotation);
        socket.broadcast.emit("TestMessage",{message:data.me});
    });

    //Incoming message from controller application
    socket.on('ControllerMessage',function(data){
        console.log(data.message);
        //broadcast.emit is used to send out the message to the connected client using same port number
        socket.broadcast.emit("TestMessage",{rotation_msg:data.message});
    });

    });