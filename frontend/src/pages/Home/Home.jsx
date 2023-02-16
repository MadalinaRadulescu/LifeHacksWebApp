import React, { useEffect, useState, useRef } from "react";
import image from "../../images/1.png";
import styles from "./styles.module.scss";
import { Link } from "react-router-dom";
import { CategoryById } from "../../components/CategoryById/CategoryById";

const Home = () => {
  document.title = "Life Saver Hub";
  const [lifeHacks, setLifeHacks] = useState([]);
  const clickScroll = useRef(null);

  useEffect(() => {
    fetch("http://localhost:5260/lifeHack/newest")
      .then((response) => response.json())
      .then((data) => setLifeHacks(data));
  }, []);

  const handleScroll = (ref) => {
    window.scrollTo({
      top: ref.offsetTop,
      left: 0,
      behavior: "smooth",
    });
  };

  if (!lifeHacks) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <div className={styles.home_header}>
        <div className={styles.home_header_text}>
          <h1>Lorem ipsum dolor</h1>
          <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
            eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim
            ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut
            aliquip ex ea commodo consequat. Duis aute irure dolor in
            reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
            pariatur. Excepteur sint occaecat cupidatat non proident, sunt in
            culpa qui officia deserunt mollit anim id est laborum.
          </p>
          <button
            onClick={() => {
              handleScroll(clickScroll.current);
            }}
          >
            Lorem ipsum dolor sit amet
          </button>
        </div>
        <img src={image} alt="" className={styles.home_image} />
      </div>
      <div className={styles.color_fill} ref={clickScroll} />

      <div className={styles.test}>
        <p>Am 3l ei</p>
        <div>
          {lifeHacks?.map((item) => (
            <div key={item.id}>
              <br />
              <h2>{item.title}</h2>

              <p>{item.description}</p>
              <Link to={item.link}>{item.link}</Link>
              {item.categoriesId.map((categoryId) => (
                <div key={categoryId}>
                  <CategoryById id={categoryId} />
                </div>
              ))}
              <p>Published at: {item.registredTime}</p>
              <p>VoteCount: {item.points}</p>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};
export default Home;
