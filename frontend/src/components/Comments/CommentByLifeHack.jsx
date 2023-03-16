import styles from "./styles.module.sass";
import React, {useEffect} from "react";

export function CommentByLifeHack({id, comments, setComments}) {

    useEffect(() => {
        fetch(`https://localhost:44330/comment/lifeHack/${id}`)
            .then((response) => response.json())
            .then((data) => setComments(data))
            .catch((error) => console.log(error));
    }, [id, comments]);

    if (!comments) {
        return (<div className={styles.card}>
            <p className={styles.text}>Loading data...</p>
            <div className={styles.timeBox}>
                <div className={styles.time}>
                    <div className={styles.time}>00:00</div>
                    <div className={styles.time}>1 January 2023</div>
                </div>
            </div>
        </div>);
    }
    return (<div>
            {comments.map((comment) => (<div className={styles.card} key={comment.id}>
                <p className={styles.text}>{comment.text}</p>
                <div className={styles.timeBox}>
                    <div className={styles.time}>
                        {new Date(comment.registeredTime).toLocaleTimeString("en-US", {
                            hour12: false, hour: "2-digit", minute: "2-digit",
                        })}
                    </div>
                    <div className={styles.time}>
                        {new Date(comment.registeredTime).toLocaleDateString("en-GB", {
                            day: "numeric", month: "long", year: "numeric",
                        })}
                    </div>
                </div>
            </div>))}
        </div>);
}
