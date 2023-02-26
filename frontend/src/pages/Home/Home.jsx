import React, { useEffect, useState, useRef } from "react";
import image from "../../Images/1.png";
import styles from "./styles.module.scss";
import { Link } from "react-router-dom";
import { CategoryById } from "../../Components/CategoryById/CategoryById";
import AllLifeHacks from "../LifeHacks/AllLifeHacks";

const Home = () => {
  document.title = "Life Saver Hub";
  // const [lifeHacks, setLifeHacks] = useState([]);
  const clickScroll = useRef(null);

  // useEffect(() => {
  //   fetch("https://localhost:44330/lifeHack/newest")
  //     .then((response) => response.json())
  //     .then((data) => setLifeHacks(data));
  // }, []);

  const handleScroll = (ref) => {
    window.scrollTo({
      top: ref.offsetTop,
      left: 0,
      behavior: "smooth",
    });
  };

  // if (!lifeHacks) {
  //   return <div>Loading...</div>;
  // }

  return (
    <div>
      <div className={styles.home_header}>
        <div className={styles.home_header_text}>
          <h1>Life Saver Hub</h1>
          <p>
            Our life hacks are designed to tackle a variety of challenges, from household chores to work tasks, from personal finance to self-improvement.
            We aim to make your life easier and more efficient by sharing creative solutions to everyday problems,
            unexpected uses for common items, and time-saving shortcuts that you might not have thought of before.
          </p>
          <button
            onClick={() => {
              handleScroll(clickScroll.current);
            }}
          >
            Show Me
          </button>
        </div>
        <img src={image} alt="" className={styles.home_image} />
        
      </div>
      <div className={styles.color_fill} ref={clickScroll} />

      <div className={styles.test}>
        <AllLifeHacks />
        {/*<p>Am 3l ei</p>*/}
        {/*<div>*/}
        {/*  {lifeHacks?.map((item) => (*/}
        {/*    <div key={item.id}>*/}
        {/*      <br />*/}
        {/*      <h2>{item.title}</h2>*/}
        
        {/*      <p>{item.description}</p>*/}
        {/*      <Link to={item.link}>{item.link}</Link>*/}
        {/*      {item.categoriesId.map((categoryId) => (*/}
        {/*        <div key={categoryId}>*/}
        {/*          <CategoryById id={categoryId} />*/}
        {/*        </div>*/}
        {/*      ))}*/}
        {/*      <p>Published at: {item.registredTime}</p>*/}
        {/*      <p>VoteCount: {item.points}</p>*/}
        {/*    </div>*/}
        {/*  ))}*/}
        {/*</div>*/}
      </div>
    </div>
  );
};
export default Home;
