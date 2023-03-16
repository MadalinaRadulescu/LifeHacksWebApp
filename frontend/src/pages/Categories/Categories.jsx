import { useEffect, useState } from "react";

export default function Categories() {
    const [categoriesData, setCategoriesData] = useState(null);

    useEffect(() => {
        fetch("http://localhost:5260/category/all")
            .then((response) => response.json())
            .then((data) => setCategoriesData(data))
            .catch((error) => console.log(error));
    }, []);
    
    if (!categoriesData){
        return <></>;
    }
    
    return (
        <>
            {categoriesData.map((category) => (
                <p key={category.id}>{category.name}</p>
            ))}
        </>
    );
}
