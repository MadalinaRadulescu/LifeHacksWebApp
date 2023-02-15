import React, {useEffect, useState} from "react";
import {Link} from "react-router-dom";
import {CategoryById} from "../Components/Categories/CategoryById";
import {GetUserName} from "../Components/Users/GetUserName";

const Home = () => {
    document.title = "Life Saver Hub"
    const [lifeHacks, setLifeHacks] = useState(null);

    useEffect(() => {
        fetch("https://localhost:44330/lifeHack/newest")
            .then(response => response.json())
            .then(json => setLifeHacks(json))
            .catch(error => console.log(error));
    }, []);
    
    if (!lifeHacks) {
        return <div>Loading...</div>;
    }
    
    return (<div>
                <h1 className="PageTitle">Life Saver Hub</h1>
                <div>
                    {lifeHacks.map(lifeHack => (
                        <div key={lifeHack.id}>
                            <br />
                            <Link to={`/lifeHack/${lifeHack.id}`}>
                                <h2>{lifeHack.title}</h2>
                            </Link>
                            {lifeHack.photoName !== "" &&
                                <img src={`data:image/png;base64,${lifeHack.photoName}`} alt={lifeHack.photoName} />
                            }
                            <p>{lifeHack.description}</p>
                            <Link to={lifeHack.link}>{lifeHack.link}</Link>
                            {lifeHack.categoriesId.map(categoryId => (
                                <div key={categoryId}>
                                    <CategoryById id={categoryId}/>
                                </div>
                            ))}
                            <p>Published at: {lifeHack.registeredTime}</p>
                            <p>VoteCount: {lifeHack.points}</p>
                            <GetUserName id={lifeHack.userId} />
                        </div>))}
                </div>
            </div>);
};
export default Home;