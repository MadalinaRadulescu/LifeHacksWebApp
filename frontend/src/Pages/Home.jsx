import React, {useEffect, useState} from "react";
import {Link} from "react-router-dom";
import {CategoryById} from "../Components/Categories/CategoryById";

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
                    {lifeHacks.map(item => (
                        <div key={item.id}>
                            <br />
                            <h2>{item.title}</h2>
                            {item.photoName !== "" &&
                                <img src={`data:image/png;base64,${item.photoName}`} alt={item.photoName} />
                            }
                            <p>{item.description}</p>
                            <Link to={item.link}>{item.link}</Link>
                            {item.categoriesId.map(categoryId => (
                                <div key={categoryId}>
                                    <CategoryById id={categoryId}/>
                                </div>
                            ))}
                            <p>Published at: {item.registredTime}</p>
                            <p>VoteCount: {item.points}</p>
                        </div>))}
                </div>
            </div>);
};
export default Home;