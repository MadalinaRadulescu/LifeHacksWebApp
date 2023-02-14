import styles from "./styles.module.css"
import logo from "./Logo.png"

export default function Navbar() {
    return (
        <>
            <ul className={styles.navbar}>
                <li><a href="/"><img src={logo} alt="Logo" width="50"/></a></li>
                <li><a href="/category">Categories</a></li>
                <li><a href="/">Search</a></li>
            </ul>
        </>
    );
}