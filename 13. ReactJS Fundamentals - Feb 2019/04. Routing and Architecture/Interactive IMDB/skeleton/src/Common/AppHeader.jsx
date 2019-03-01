import React, {Component} from 'react';
import AppNav from "./AppNav";

class AppHeader extends Component {
    render() {
        return (
            <AppNav
                userName={this.props.userName}
                isAdmin={this.props.isAdmin}
            />
        )
    }
}

export default AppHeader;