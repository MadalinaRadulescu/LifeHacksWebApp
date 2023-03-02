import { useEffect, useState } from "react";

export default function Categories() {
    const [categoriesData, setCategoriesData] = useState();

    useEffect(() => {
        fetch("https://localhost:44330/category/all")
            .then((response) => response.json())
            .then((data) => setCategoriesData(data));
    }, []);
    console.log(categoriesData);
    return (
        <>
            {categoriesData !== undefined &&
                categoriesData.map((category) => (
                    <p key={category.id}>{category.name}</p>
                ))}
        </>
    );
}
