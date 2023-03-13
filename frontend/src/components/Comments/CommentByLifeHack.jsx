import styles from "./styles.module.sass";
import Placeholder from "../../Images/Placeholder.png";
import information from "../../Images/information.png";
import React, {useEffect, useState} from "react";
import {GetUserName} from "../Users/GetUserName";

export function CommentByLifeHack({id}) {
    const [comments, setComments] = useState([]);

    useEffect(() => {
        fetch(`https://localhost:44330/comment/lifeHack/${id}`)
            .then((response) => response.json())
            .then((data) => setComments(data))
            .catch((error) => console.log(error));
    }, [id]);

    if (!comments) {
        return <div>Loading data...</div>;
    }

    return (<div>
            {comments.map((comment) => (<div key={comment.id} className={styles.card}>
                    <p className={styles.points}>{comment.points}</p>
                    <p className={styles.text}>{comment.text}</p>
                    <div>
                        <p className={styles.time}>
                            {new Date(comment.registeredTime).toLocaleTimeString("en-US", {
                                hour12: false, hour: "2-digit", minute: "2-digit",
                            })}
                        </p>
                        <p className={styles.date}>
                            {new Date(comment.registeredTime).toLocaleDateString("en-GB", {
                                day: "numeric", month: "long", year: "numeric",
                            })}
                        </p>
                    </div>
                </div>))}
        </div>);
}
