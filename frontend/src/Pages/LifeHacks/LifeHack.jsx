import React, {useEffect, useState} from "react";
import {Link, useParams} from "react-router-dom";
import {CategoryById} from "../../components/Categories/CategoryById";
import {CommentByLifeHack} from "../../components/Comments/CommentByLifeHack";
import {GetUserName} from "../../components/Users/GetUserName";
import styles from "./styles.module.sass";
import Placeholder from "../../Images/Placeholder.png";
import information from "../../Images/information.png";

const LifeHack = () => {
    const id = useParams().LifeHackId;
    const [lifeHack, setLifeHack] = useState(null);

    useEffect(() => {
        fetch(`http://localhost:5260/lifeHack/${id}`)
            .then(response => response.json())
            .then(json => setLifeHack(json))
            .catch(error => console.log(error));
    }, []);

    if (!lifeHack) {
        return (
            <div className={styles.card}>
                <div className={styles.thumbnail}>
                    <img className={styles.customImg} src={Placeholder} alt="Placeholder"/>
                </div>
                <div className={styles.right}>
                    <h1 className={styles.LHTitle}>Loading...</h1>
                    <div className={styles.separator}/>
                    <p className={styles.paragraph}>Loading...</p>
                </div>
                <h5>25:61</h5>
                <h6>30 February</h6>
                <div className={styles.fab}><img className={styles.customImg} src={information} alt="Information"/></div>
            </div>);
    }

    document.title = lifeHack.title;

    return (<div>
        <h1 className="PageTitle">{lifeHack.title}</h1>
        <div className={styles.card}>
            <div className={styles.thumbnail}>

                {lifeHack.photoName !== "" ?
                    <img className={styles.customImg} src={`data:image/png;base64,${lifeHack.photoName}`}
                         alt={lifeHack.photoName}/> :
                    <img className={styles.customImg} src={Placeholder} alt="Placeholder"/>}
            </div>
            <div className={styles.right}>
                <h1 className={styles.LHTitle}>{lifeHack.title}</h1>
                <div className={styles.separator}/>
                <p className={styles.paragraph}>{lifeHack.description}</p>
                {lifeHack.link !== '' && <>
                    <div className={styles.separator}/>
                    <Link to={lifeHack.link} className={styles.paragraph}>{lifeHack.link}</Link></>}
            </div>
            <h5>{new Date(lifeHack.registeredTime).toLocaleTimeString('en-US', {
                hour12: false, hour: '2-digit', minute: '2-digit'
            })}</h5>
            <h6>{new Date(lifeHack.registeredTime).toLocaleDateString('en-GB', {
                day: 'numeric', month: 'long', year: 'numeric'
            })}</h6>
        </div>


        {/*<div key={lifeHack.id}>*/}
        {/*    <br />*/}
        {/*    {lifeHack.photoName !== "" &&*/}
        {/*        <img src={`data:image/png;base64,${lifeHack.photoName}`} alt={lifeHack.photoName} />*/}
        {/*    }*/}
        {/*    <p className={styles.paragraph}>{lifeHack.description}</p>*/}
        {/*    <Link to={lifeHack.link}>{lifeHack.link}</Link>*/}
        {/*    {lifeHack.categoriesId.map(categoryId => (*/}
        {/*        <div key={categoryId}>*/}
        {/*            <CategoryById id={categoryId}/>*/}
        {/*        </div>*/}
        {/*    ))}*/}
        {/*    <p className={styles.paragraph}>Published at: {lifeHack.registredTime}</p>*/}
        {/*    <p className={styles.paragraph}>VoteCount: {lifeHack.points}</p>*/}
        {/*</div>*/}
        <CommentByLifeHack id={lifeHack.id}/>
        <GetUserName id={lifeHack.userId}/>
    </div>);
};
export default LifeHack;