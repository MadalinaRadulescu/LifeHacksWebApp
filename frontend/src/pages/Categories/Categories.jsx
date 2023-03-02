import { useEffect, useState } from "react";

export default function Categories() {
  const [categoriesData, setCategoriesData] = useState(null);

  useEffect(() => {
      fetch("https://localhost:44330/category/all")
      .then((response) => response.json())
      .then((data) => setCategoriesData(data));
      
  }, []);
  return (
    <>
      {categoriesData !== null &&
        categoriesData.map((category) => <p key={category.id}>{category.name}</p>)}
    </>
  );
}
