import React, {useEffect, useState} from "react";
import {Link, useParams} from "react-router-dom";
import {CommentByLifeHack} from "../../../Components/Comments/CommentByLifeHack";
import styles from "./styles.module.sass";
import Placeholder from "../../../Images/Placeholder.png";
import YouTube from 'react-youtube';
import Vimeo from '@u-wave/react-vimeo'
import link from "../../../Images/link.png";
import AddComment from "../../../Components/AddComment/AddComment";

const LifeHack = () => {
    const id = useParams().LifeHackId;
    const [lifeHack, setLifeHack] = useState(null);
    const [comments, setComments] = useState([]);
    const opts = {
        height: '390', width: '640', playerVars: {
            autoplay: 1,
        },
    };

    useEffect(() => {
        fetch(`https://localhost:44330/lifeHack/${id}`)
            .then((response) => response.json())
            .then((json) => setLifeHack(json))
            .catch((error) => console.log(error));
    }, [comments]);

    if (!lifeHack) {
        return (<div className={styles.container}>
            <h1 className={styles.LHTitle}>Loading...</h1>
            <div className={styles.card}>
                <div className={styles.thumbnail}>
                    <img
                        className={styles.customImg}
                        src={Placeholder}
                        alt="Placeholder"
                    />
                    <h5 className={styles.time}>00:00</h5>
                    <h5 className={styles.time}>1 January 2023</h5>
                </div>
                <div className={styles.right}>
                    <p className={styles.paragraph}>Loading...</p>
                </div>
            </div>
        </div>);
    }

    document.title = lifeHack.title;
    const youtubeRegex = /^(https?\:\/\/)?(www\.)?(youtube\.com|youtu\.be)\/.+$/;
    const vimeoRegex = /(?:https?:\/\/)?(?:www\.)?(?:vimeo\.com)\/?(.+)?/;
    const dailymotionRegex = /(?:https?:\/\/)?(?:www\.)?(?:dailymotion\.com)\/(?:video|hub)\/([^_]+)[^#]*(?:#video=([^_&]+))?/;

    return (<div className={styles.container}>
        <h1 className={styles.LHTitle}>{lifeHack.title}</h1>
        <div className={styles.card}>
            <div className={styles.thumbnail}>
                {lifeHack.image.length > 0 ? (<img
                    className={styles.customImg}
                    src={lifeHack.image[0]}
                    alt={lifeHack.image[0]}
                />) : (<img
                    className={styles.customImg}
                    src={Placeholder}
                    alt="Placeholder"
                />)}
                <h5 className={styles.time}>
                    {new Date(lifeHack.registeredTime).toLocaleTimeString("en-US", {
                        hour12: false, hour: "2-digit", minute: "2-digit",
                    })}
                </h5>
                <h5 className={styles.time}>
                    {new Date(lifeHack.registeredTime).toLocaleDateString("en-GB", {
                        day: "numeric", month: "long", year: "numeric",
                    })}
                </h5>
            </div>
            <div className={styles.right}>
                <p className={styles.paragraph}>{lifeHack.description}</p>
                <div className={styles.externalLink}>
                    {lifeHack.link !== "" && (youtubeRegex.test(lifeHack.link) ?
                        <YouTube videoId={lifeHack.link} opts={opts}/> : vimeoRegex.test(lifeHack.link) ? <Vimeo
                            video={lifeHack.link}
                            autoplay
                        /> : dailymotionRegex.test(lifeHack.link) ? <div>
                            <iframe
                                src={`https://www.dailymotion.com/embed/video/${lifeHack.link.match(dailymotionRegex)[1]}`}
                                frameBorder='0'
                                allowFullScreen></iframe>
                        </div> : <Link to={lifeHack.link} className={styles.link}><img src={link} className={styles.linkImage} alt="link"></img>See this</Link>)}
                </div>
            </div>
        </div>
        <CommentByLifeHack id={lifeHack.id} comments={comments} setComments={setComments} />
        <AddComment lifeHackId={id} setComments={setComments} comments={comments} />
    </div>);
};
export default LifeHack;
