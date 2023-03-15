import styles from "./styles.module.scss";
import logo from "../../Images/LifeSaverHubLogo.png";
import { Link, useNavigate } from "react-router-dom";
import { useState, useEffect, useRef } from "react";
import useOnClickOutside from "../../Hooks/useOnClickOutside";
import { useAtom } from "jotai";
import state from "../../Store";


function LoggedIn({ addLifeHack, logOut, user, yourLifeHacks }) {
    return (
        <>
            <div className={styles.overflow}>
                <li onClick={addLifeHack}>Add</li>
            </div>
            <div className={styles.overflow}>
                <li onClick={logOut}>Log Out</li>
            </div>
            <div className={styles.overflow}>
                <Link to={`/lifeHack/user/${user.userId}`}> Your Life Hacks</Link>
            </div>
            <div className={styles.message}>Welcome {user.userId}{user.userName}</div>
        </>
    );
}

function LoggedOut({ register, logIn }) {
    return (
        <>
            <div className={styles.overflow}>
                <li onClick={register}>Register</li>
            </div>
            <div className={styles.overflow}>
                <li onClick={logIn}>Log In</li>
            </div>
            <div className={styles.message}>You are not logged in </div>
        </>
    );
}

export default function Navbar() {
    const [isDropDown, setIsDropDown] = useState(false);
    const [categoriesData, setCategoriesData] = useState(null);
    const [searchValue, setSearchValue] = useState("Search");
    const outside = useRef(null);
    const [user] = useAtom(state.userData);
    

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

    let navigate = useNavigate();
    const addLifeHack = () => {
        let path = `/addLifeHack`;
        navigate(path);
    };

    const register = () => {
        let path = `/Auth/register`;
        navigate(path);
    };

    const yourLifeHacks = (userId)=>{
        let path = `/lifeHack/user/${userId}`;
        navigate(path);
    }

    const logIn = () => {
        let path = `/Auth/login`;
        navigate(path);
    };

    const logOut = () => {
        let path = `/Auth/Logout`;
        navigate(path);
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
                {user?.isSuccess ? (
                    <LoggedIn addLifeHack={addLifeHack} logOut={logOut} user={user}  yourLifeHacks={yourLifeHacks}  />
                ) : (
                    <LoggedOut register={register} logIn={logIn} />
                )}
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
