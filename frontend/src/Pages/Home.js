import React, {useEffect, useState} from "react";
import {Link} from "react-router-dom";

const Home = () => {
    document.title = "Life Saver Hub"
    const [lifeHacks, setLifeHacks] = useState(null);
    const [error, setError] = useState(null);
    
    useEffect(() => {
        fetch("https://localhost:44330/lifeHack/all")
            .then(response => response.json())
            .then(json => setLifeHacks(json))
            .catch(error => setError(error));
    }, []);
    if (error) {
        console.log(error)
        return <div>Error: {error.message}</div>;
    } else if (!lifeHacks) {
        return <div>Loading...</div>;
    } else {
        console.log(lifeHacks)
        return (
            <div>
                <h1 className="PageTitle">Life Saver Hub</h1>
                <dib>
                    {lifeHacks.map(item => (
                        <div key={item.id}>
                            <h2>{item.title}</h2>
                            <img alt={item.photoName} />
                            <p>{item.description}</p>
                            <Link to={item.link}>{item.link}</Link>
                            <p>Published at: {item.registredTime}</p>
                            <p>VoteCount: {item.points}</p>
                        </div>
                    ))}
                </dib>
            </div>
        );
    }
};
export default Home;