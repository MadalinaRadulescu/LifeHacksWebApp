import React, {useEffect, useState} from "react";

export function CategoryById({id}) {
    const [data, setData] = useState(null);

    useEffect(() => {
        fetch(`https://localhost:44330/category/${id}`)
            .then(response => response.json())
            .then(data => setData(data))
            .catch(error => console.error(error));
    }, [id]);

    if (!data) {
        return <div>Loading data for Category with id: {id}...</div>;
    }

    return (<h3>{data.name}</h3>);
}