import React, {useEffect, useState} from "react";
import {GetUserName} from "../Users/GetUserName";

export function CommentByLifeHack({id}) {
    const [comments, setComments] = useState([]);

    useEffect(() => {
        fetch(`https://localhost:44330/comment/lifeHack/${id}`)
            .then(response => response.json())
            .then(data => setComments(data))
            .catch(error => console.log(error));
    }, [id]);

    if (!comments) {
        return <div>Loading data...</div>;
    }
    
    return (
        <div>
            {comments.map(comment => (
                <div key={comment.id}>
                    <h3>{comment.text}</h3>
                    <div>{comment.points}</div>
                    <div>{comment.points}</div>
                    <div>{comment.registeredTime}</div>
                    <GetUserName id={comment.userId} />
                </div>
            ))}
        </div>
    );
}