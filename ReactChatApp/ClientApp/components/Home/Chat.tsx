﻿// components/Home/chat.tsx

import * as React from 'react';
//import { ChatService } from '../../services/ChatService';
import { ChatMessage } from '../../services/Models/ChatMessage';
import * as moment from 'moment';

interface ChatState {

    messages: ChatMessage[];

    currentMessage: string;

}

export class Chat extends React.Component<{}, ChatState> {
    msg: HTMLInputElement;

    panel: HTMLDivElement;

    //_chatService: ChatService;

    constructor() {
        super();

        this.state = { messages: [], currentMessage: '' };
        this.handlePanelRef = this.handlePanelRef.bind(this);
        this.handleMessageRef = this.handleMessageRef.bind(this);
        this.handleMessageChange = this.handleMessageChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);

        /*let that = this;
        this._chatService = new ChatService((msg: ChatMessage) => {
            this.handleOnSocket(that, msg);
        });

        this._chatService.fetchInitialMessages(this.handleOnInitialMessagesFetched);*/
    }

    /*handleOnInitialMessagesFetched(messages: ChatMessage[]) {
        this.setState({
            messages: messages
        });
        this.scrollDown(this);
    }

    handleOnSocket(that: Chat, message: ChatMessage) {
        let messages = that.state.messages;

        messages.push(message);

        that.setState({
            messages: messages,
            currentMessage: ''
        });

        that.scrollDown(that);
        that.focusField(that);
    }*/

    handlePanelRef(div: HTMLDivElement) {
        this.panel = div;
    }

    handleMessageRef(input: HTMLInputElement) {
        this.msg = input;
    }

    handleMessageChange(event: any) {
        this.setState({ currentMessage: event.target.value });
    }

    onSubmit(event: any) {
        event.preventDefault();
        this.addMessage();
    }

    addMessage() {
        let currentMessage = this.state.currentMessage;

        if (currentMessage.length === 0) {
            return;
        }

        let id = this.state.messages.length;
        let date = new Date();
        let messages = this.state.messages;

        messages.push({
            id: id,
            date: date,
            message: currentMessage,
            sender: 'juergen'
        })

        this.setState({
            messages: messages,
            currentMessage: ''

        });

        this.msg.focus();
        this.panel.scrollTop = this.panel.scrollHeight - this.panel.clientHeight;
    }

    public render() {
        return <div className='panel panel-default'>

            <div className='panel-body panel-chat'

                ref={this.handlePanelRef}>

                <ul>

                    {this.state.messages.map(message =>

                        <li key={message.id}><strong>{message.sender} </strong>

                            ({moment(message.date).format('HH:mm:ss')})<br />

                            {message.message}</li>

                    )}

                </ul>

            </div>

            <div className='panel-footer'>

                <form className='form-inline' onSubmit={this.onSubmit}>

                    <label className='sr-only' htmlFor='msg'>Message</label>

                    <div className='input-group col-md-12'>

                        <button className='chat-button input-group-addon'>:-)</button>

                        <input type='text' value={this.state.currentMessage}

                            onChange={this.handleMessageChange}

                            className='form-control'

                            id='msg'

                            placeholder='Your message'

                            ref={this.handleMessageRef} />

                        <button className='chat-button input-group-addon'>Send</button>

                    </div>

                </form>

            </div>

        </div>;
    }

}
