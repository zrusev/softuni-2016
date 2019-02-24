import React from 'react';
import SimpleSnackbar from "./SnackBar";

const AppFooter = (props) => (<SimpleSnackbar showSnack={props.showSnack} message={props.message} />);

export default AppFooter;