import React, {useState} from "react";
import styles from "./styles.module.sass";
import {useNavigate} from "react-router-dom";

export default function AddComment({lifeHackId, setComments, comments}) {
    const [comment, setComment] = useState("")
    let navigate = useNavigate();

    const handleSubmit = event => {
        event.preventDefault();
        console.log(JSON.stringify({
            userId: "0",
            text: comment,
            lifeHackId: lifeHackId
        }))
        fetch('http://localhost:5260/comment/add', {
            method: 'POST', headers: {'Content-Type': 'application/json'}, body: JSON.stringify({
                userId: "0",
                text: comment,
                lifeHackId: lifeHackId
            })
        }).then(result => {
            if (result.ok){
                console.log(result)
                console.log(comment)
                setComments(comments => [...comments, comment])
                console.log(comments)
                navigate("/lifeHack/" + lifeHackId);
            }
        })
            .catch(error => console.log(error));
    };
    
    const handleInput = event => {
        setComment(event.target.value)
    }

    return (<form
        onSubmit={handleSubmit} className={styles.card}>
        <textarea name="comment" className={styles.input} value={comment} placeholder="Got any mentions?"
                  onChange={handleInput}/>
        {comment !== "" && <button type={"submit"} className={styles.postComment}>Post</button>}
    </form>)
}