import * as React from 'react';
import { UsersService } from '../../services/UsersService';

interface UsersState {
    users: User[];
}

interface User {
    id: number;
    name: string;
}

export class Users extends React.Component<{}, UsersState> {
    private userService: UsersService = new UsersService((user: User) => {
        this.handleOnSocket(this, user)
    });

    constructor() {
        super();

        this.state = {
            users: []
        };

        this.handleOnSocket = this.handleOnSocket.bind(this);
        this.handleOnLogedOnUserFetched = this.handleOnLogedOnUserFetched.bind(this);

        this.userService.fetchLogedOnUsers(this.handleOnLogedOnUserFetched); 
    }

    public render() {
        return <div className='panel panel-default'>
            <div className='panel-body'>
                <h3>Users online:</h3>
                <ul className='chat-users'>
                    {this.state.users.map(user =>
                        <li key={user.id}>{user.name}</li>
                    )}
                </ul>
            </div>
        </div>;
    }

    handleOnLogedOnUserFetched(users: User[]) {
        this.setState({
            users: users
        });
    }

    handleOnSocket(that:Users, user: User) {
        let users = that.state.users;
        users.push(user);
        that.setState({
            users: users
        });
    }
}
