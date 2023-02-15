import React, {useEffect, useState} from "react";
import {Link, useParams} from "react-router-dom";
import {CategoryById} from "../Components/Categories/CategoryById";
import {CommentByLifeHack} from "../Components/Comments/CommentByLifeHack";
import {GetUserName} from "../Components/Users/GetUserName";

const LifeHack = () => {
    const id = useParams().LifeHackId;
    document.title = "Life Saver Hub"
    const [lifeHack, setLifeHack] = useState(null);

    useEffect(() => {
        fetch(`https://localhost:44330/lifeHack/${id}`)
            .then(response => response.json())
            .then(json => setLifeHack(json))
            .catch(error => console.log(error));
    }, []);

    if (!lifeHack) {
        return <div>Loading...</div>;
    }

    return (<div>
        <h1 className="PageTitle">Life Saver Hub</h1>
                <div key={lifeHack.id}>
                    <br />
                    <h2>{lifeHack.title}</h2>
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
                    <p>Published at: {lifeHack.registredTime}</p>
                    <p>VoteCount: {lifeHack.points}</p>
                </div>
            <CommentByLifeHack id={lifeHack.id}/>
        <GetUserName id={lifeHack.userId} />
    </div>);
};
export default LifeHack;