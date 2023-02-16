import React, {useEffect, useState} from "react";
import Placeholder from "../../Images/Placeholder.png"
import information from "../../Images/information.png"
import styles from "./styles.module.sass";
import {Link} from "react-router-dom";

const AllLifeHacks = () => {
    const [lifeHacks, setLifeHacks] = useState(null);

    useEffect(() => {
        fetch("https://localhost:44330/lifeHack/newest")
            .then(response => response.json())
            .then(json => setLifeHacks(json))
            .catch(error => console.log(error));
    }, []);

    if (!lifeHacks) {
        const placeHolder =
            <div className={styles.card}>
                <div className={styles.thumbnail}>
                        <img className={styles.customImg} src={Placeholder} alt="Placeholder"/>
                </div>
                <div className={styles.right}>
                    <h1>Loading...</h1>
                    <div className={styles.separator}/>
                    <p>Loading...</p>
                </div>
                <h5>25:61</h5>
                <h6>30 February</h6>
                <div className={styles.fab}><img className={styles.customImg} src={information} alt="Information"/></div>
            </div>
        return (<>{placeHolder}{placeHolder}{placeHolder}</>);
    }

    return (<>
        {lifeHacks.map(lifeHack => (

            <Link key={lifeHack.id} to={`/lifeHack/${lifeHack.id}`} style={{textDecoration: 'none'}}>
                <div className={styles.card}>
                    <div className={styles.thumbnail}>

                        {lifeHack.photoName !== "" ?
                            <img className={styles.customImg} src={`data:image/png;base64,${lifeHack.photoName}`}
                                 alt={lifeHack.photoName}/> :
                            <img className={styles.customImg} src={Placeholder} alt="Placeholder"/>}
                    </div>
                    <div className={styles.right}>
                        <h1>{lifeHack.title}</h1>
                        <div className={styles.separator}/>
                        <p>{lifeHack.description}</p>
                        {lifeHack.link !== '' && <>
                            <div className={styles.separator}/>
                            <Link to={lifeHack.link}>{lifeHack.link}</Link></>}
                    </div>
                    <h5>{new Date(lifeHack.registeredTime).toLocaleTimeString('en-US', {
                        hour12: false, hour: '2-digit', minute: '2-digit'
                    })}</h5>
                    <h6>{new Date(lifeHack.registeredTime).toLocaleDateString('en-GB', {
                        day: 'numeric', month: 'long', year: 'numeric'
                    })}</h6>
                    <div className={styles.fab}><img className={styles.customImg} src={information} alt="Information"/></div>
                </div>
            </Link>))}
    </>);
};
export default AllLifeHacks;