import React from 'react';

function warningWrapper (WrappedComponent) {
    return function WarningWrapper (props) {
        return (
            <div className="alert">
                <span className="alert-symbol">&#9888;</span>
                <WrappedComponent {...props} />
            </div>
        )
    }
}

export default warningWrapper;