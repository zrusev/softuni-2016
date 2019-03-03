import React from 'react';

function errorHandlingWrapper(WrappedComponent) {
    return class ErrorHandlingWrapper extends React.Component {
        constructor(props) {
            super(props);

            this.state = {
                hasError: false
            }
        }
        componentDidCatch(error, info) {
            console.log(error, info);            
        }
        static getDerivedStateFromError(error) {
            return { hasError: true }
        }
        render() {
            if (this.state.hasError) {
                return (<h1>Something went wrong with component {WrappedComponent.name}!</h1>)
            }
            return <WrappedComponent {...this.props} />;
        }
    }
}

export default errorHandlingWrapper;