﻿/*import { HubConnection, TransportType, ConsoleLogger, LogLevel } from '@aspnet/signalr';

import { ChatMessage } from './Models/ChatMessage';

class ChatWebsocketService {

    private _connection: HubConnection;

    constructor() {
        var transport = TransportType.WebSockets;

        let logger = new ConsoleLogger(LogLevel.Information);

        // create Connection
        this._connection = new HubConnection(`http://${document.location.host}/chat`,
            { transport: transport, logging: logger });

        // start connection
        this._connection.start().catch(err => console.error(err, 'red'));
    }

    registerUserLoggedOn(userLoggedOn: (id: number, name: string) => void) {
        // get new user from the server
        this._connection.on('UserLoggedOn', (id: number, name: string) => {

            userLoggedOn(id, name);
        });
    }

    registerMessageAdded(messageAdded: (msg: ChatMessage) => void) {
        // get nre chat message from the server
        this._connection.on('MessageAdded', (message: ChatMessage) => {

            messageAdded(message);
        });
    }

    sendMessage(message: string) {
        // send the chat message to the server
        this._connection.invoke('AddMessage', message);
    }
}

const WebsocketService = new ChatWebsocketService();

export default WebsocketService;*/
