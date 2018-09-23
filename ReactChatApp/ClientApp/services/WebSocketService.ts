import * as signalR from "@aspnet/signalr";
import { ChatMessage } from './Models/ChatMessage';
import { User } from "./Models/User";

class ChatWebsocketService {
    private _connection: signalR.HubConnection;

    constructor() {
        this._connection = new signalR.HubConnectionBuilder()
            .withUrl("/chat")
            .build();
        this._connection.start().catch(err => console.error(err, 'red'));
    }

    registerUserLoggedOn(userLoggedOn: (user: User) => void) {
        this._connection.on('UserLoggedOn', (user: User) => {
            userLoggedOn(user);
        });
    }

    registerMessageAdded(messageAdded: (msg: ChatMessage) => void) {
        this._connection.on('MessageAdded', (message: ChatMessage) => {
            messageAdded(message);
        });
    }

    sendMessage(message: string) {
        this._connection.invoke('AddMessage', message);
    }
}

const WebsocketService = new ChatWebsocketService();
export default WebsocketService;
