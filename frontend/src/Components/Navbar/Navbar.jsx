import styles from "./styles.module.scss";
import logo from "../../images/LifeSaverHubLogo.png";
import { Link } from "react-router-dom";
import { useState, useEffect, useRef } from "react";
import useOnClickOutside from "../../hooks/useOnClickOutside";

export default function Navbar() {
  const [isDropDown, setIsDropDown] = useState(false);
  const [categoriesData, setCategoriesData] = useState();
  const [searchValue, setSearchValue] = useState("Search");
  const outside = useRef(null);

  useEffect(() => {
    fetch("http://localhost:5260/category/all")
      .then((response) => response.json())
      .then((data) => setCategoriesData(data));
  }, []);

  useOnClickOutside(outside, () => setIsDropDown(false));

  function searchVal(event) {
    setSearchValue(event.target.value);
  }

  const handleDropdown = () => {
    setIsDropDown(!isDropDown);
  };

  return (
    <>
      <ul className={styles.navbar}>
        <li>
          <Link to="/">
            <img src={logo} alt="Logo" className={styles.logo} />
          </Link>
        </li>
        <div className={styles.overflow} ref={outside}>
          <li onClick={handleDropdown}>Categories</li>
        </div>
        <div className={styles.overflow}>
          <li onClick={handleDropdown}>Categories</li>
        </div>
        <label>
          <input
            type="text"
            name="name"
            value={searchValue}
            onChange={searchVal}
            className={styles.searchbar}
          />
        </label>
      </ul>

      <div className={styles.dropdown}>
        {isDropDown ? (
          <ul>
            {categoriesData.map((item) => (
              <li key={item.id}>
                <Link to={`/${item.name}`}>{item.name}</Link>
              </li>
            ))}
          </ul>
        ) : null}
      </div>
    </>
  );
}
