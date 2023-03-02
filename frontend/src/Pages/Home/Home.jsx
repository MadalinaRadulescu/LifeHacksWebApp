import React, { useRef } from "react";
import AllLifeHacks from "../LifeHacks/AllLifeHacks/AllLifeHacks";

import image from "../../Images/1.png";
import styles from "./styles.module.scss";

const Home = () => {
    document.title = "Life Saver Hub";

    const clickScroll = useRef(null);

    const handleScroll = (ref) => {
        window.scrollTo({
            top: ref.offsetTop,
            left: 0,
            behavior: "smooth",
        });
    };

    return (
        <div>
            <div className={styles.home_header}>
                <div className={styles.home_header_text}>
                    <h1>Life Saver Hub</h1>
                    <p>
                        Our life hacks are designed to tackle a variety of
                        challenges, from household chores to work tasks, from
                        personal finance to self-improvement. We aim to make
                        your life easier and more efficient by sharing creative
                        solutions to everyday problems, unexpected uses for
                        common items, and time-saving shortcuts that you might
                        not have thought of before.
                    </p>
                    <button onClick={() => handleScroll(clickScroll.current)}>
                        Show Me
                    </button>
                </div>
                <img src={image} alt="" className={styles.home_image} />
            </div>
            <div className={styles.color_fill} ref={clickScroll} />

            <div className={styles.test}>
                <AllLifeHacks />
            </div>
        </div>
    );
};
export default Home;
