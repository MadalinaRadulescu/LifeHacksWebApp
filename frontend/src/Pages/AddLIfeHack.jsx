import React, {useState} from "react";
import {Navigate} from 'react-router-dom';
import Resizer from "react-image-file-resizer";

const AddLIfeHack = () => {
    document.title = "Add Life Hack";
    
    const [image, setImage] = useState(null);
    const [result, setResult] = useState(null);
    const [lifeHack, setLifeHack] = useState({
        title: '',
        description: '',
        userId: '',         //*** To Do *** take id from connected user
        categoriesId: [],
        photoName: image && '',
        link: ''
    });


    const handleImageUpload = (event) => {
        const file = event.target.files[0];
        Resizer.imageFileResizer(
            file,
            300, // max width
            300, // max height
            'JPEG', // compress format
            100, // quality
            0, // rotation
            (uri) => {
                // uri is the resized image in base64 string format
                setImage(uri);
            },
            'base64' // output type
        );
    };
    
    const handleInputChange = event => {
        const {name, value} = event.target;
        setLifeHack(prevState => ({...prevState, [name]: value}));
    };

    const handleSubmit = event => {
        event.preventDefault();
        fetch('https://localhost:44330/lifeHack/add', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(lifeHack),
        })
            .then(response => response.json())
            .then(data => setResult(data))
            .catch(error => console.log(error));
    };
    
    if (result) {
        return (<Navigate replace to={"/lifeHack/" + result} />)
    }

    return (<form onSubmit={handleSubmit}>
        <label>
            Title:
            <textarea
                name="title"
                value={lifeHack.title}
                onChange={handleInputChange}
            />
        </label>
        <label>
            Description:
            <textarea
                name="description"
                value={lifeHack.description}
                onChange={handleInputChange}
            />
        </label>
        <label>
            External link:
            <textarea
                name="link"
                value={lifeHack.link}
                onChange={handleInputChange}
            />
        </label>
        <label>
            <input type="file" onChange={handleImageUpload} />
            {image && <img src={image} alt="uploaded image" />}
        </label>
        <button type="submit">Submit</button>
    </form>)
};
export default AddLIfeHack;