import { useState } from "react";

export default function SearchBar(props) {
  const [searchTerm, setSearchTerm] = useState("");
  function handleChange(event) {
    
  }


  return (
    <div>
      <form>
        <input
          type="text"
          name="name"
          value={searchTerm}
          onChange={handleChange}
          placeholder="Search..."
        />
        <button type="submit">Go</button>
      </form>
      {searchResults.map((item) => (
        <div key={item.id}>{item.title}</div>
      ))}
    </div>
  );
}

// className={styles.searchbar_container}
// className={styles.searchbar}
