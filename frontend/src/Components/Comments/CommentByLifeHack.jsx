import styles from "./styles.module.sass";
import Placeholder from "../../Images/Placeholder.png";
import information from "../../Images/information.png";
import React, { useEffect, useState } from "react";
import { GetUserName } from "../Users/GetUserName";

export function CommentByLifeHack({ id, comments, setComments }) {

    useEffect(() => {
        fetch(`https://localhost:44330/comment/lifeHack/${id}`)
            .then((response) => response.json())
            .then((data) => setComments(data))
            .catch((error) => console.log(error));
    }, [id, comments]);

    if (!comments) {
        return <div>Loading data...</div>;
    }

    return (
        <div>
            {comments.map((comment) => (
                <div className={styles.card}>
                    <div className={styles.right}>
                        <h1>{comment.title}</h1>
                        <div className={styles.separator} />
                        <p>{comment.text}</p>
                    </div>
                    <h5>
                        {new Date(comment.registeredTime).toLocaleTimeString(
                            "en-US",
                            {
                                hour12: false,
                                hour: "2-digit",
                                minute: "2-digit",
                            }
                        )}
                    </h5>
                    <h6>
                        {new Date(comment.registeredTime).toLocaleDateString(
                            "en-GB",
                            {
                                day: "numeric",
                                month: "long",
                                year: "numeric",
                            }
                        )}
                    </h6>
                </div>
            ))}
        </div>

        //         <div key={comment.id}>
        //             <h3>{comment.text}</h3>
        //             <div>{comment.points}</div>
        //             <div>{comment.points}</div>
        //             <div>{comment.registeredTime}</div>
        //             <GetUserName id={comment.userId} />
        //         </div>
        //     ))}
        // </div>
    );
}
