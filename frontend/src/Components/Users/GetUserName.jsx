import React, {useEffect, useState} from "react";

export function GetUserName({id}) {
    const [userName, setUserName] = useState(null);

    useEffect(() => {
        fetch(`https://localhost:44330/userData/user/${id}`)  // *** To Do *** => change from card holder to userName
            .then(response => response.json())
            .then(data => setUserName(data))
            .catch(error => console.log(error));
    }, [id]);

    if (!userName) {
        return <div>Loading...</div>;
    }

    return (<h3>{userName.cardHolder}</h3>);
}