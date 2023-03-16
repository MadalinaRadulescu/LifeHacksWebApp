import { useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useAtom } from "jotai";
import state from "../../Store";

const Remove = () => {
    const id = useParams().lifeHackId;
    const[user] = useAtom(state.userData)
    let navigate = useNavigate();
    console.log(id)
    
    useEffect(() => {
        console.log("din fetch  " + user.userId)
        fetch(`http://localhost:5260/lifeHack/remove/${id}`, {
            method: "DELETE"
            
        })
        .then((r) => {
            let path = `/lifeHack/user/${user.userId}`;
            navigate(path);
        });
    }, [navigate, user.userId, id]);
    

    return(<></>)
};

export default Remove;