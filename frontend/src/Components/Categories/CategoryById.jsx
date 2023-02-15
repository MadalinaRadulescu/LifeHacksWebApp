﻿import React, {useEffect, useState} from "react";

export function CategoryById({id}) {
    const [category, setCategory] = useState(null);

    useEffect(() => {
        fetch(`https://localhost:44330/category/${id}`)
            .then(response => response.json())
            .then(data => setCategory(data))
            .catch(error => console.error(error));
    }, [id]);

    if (!category) {
        return <div>Loading data for Category with id: {id}...</div>;
    }

    return (<h3>{category.name}</h3>);
}