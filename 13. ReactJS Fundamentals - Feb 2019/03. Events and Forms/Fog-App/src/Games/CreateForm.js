import React from 'react';

const innerState = {
    title: null,
    description: null,
    imageUrl: null
}

const handleChange = (event) => {    
    innerState[event.target.name] = event.target.value;    
}

const CreateForm = (props) => {
    return (
        <div className="create-form">
            <h1>Create game</h1>
            <form id="create-course-form" onSubmit={(event) => {
                event.preventDefault();
                props.createGame(innerState);
            }}>
                <label>Title</label>
                <input type="text" name="title" id="title" onChange={handleChange} />
                <label>Description</label>
                <textarea type="text" name="description" id="description" onChange={handleChange} />
                <label>ImageUrl</label>
                <input type="text" name="imageUrl" id="imageUrl" onChange={handleChange} />
                <input type="submit" value="Create"/>
            </form>
        </div>
    )
};

export default CreateForm;

