import styles from "./styles.module.scss"

export default function Navbar() {
  return (
    <>
          <ul className={styles.navbar}>
            <li><a href="/">Home</a></li>
            <li><a href="/">Categories</a></li>
            <li><a href="/">Search</a></li>
          </ul>
    </>
  );
}
