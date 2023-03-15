import React, { useEffect, useState } from "react";
import Placeholder from "../../../Images/Placeholder.png";
import information from "../../../Images/information.png";
import styles from "./styles.module.sass";
import { Link, useLocation } from "react-router-dom";
import { CarouselPage } from "../../../Components/Carousel/CarouselPage";

export default function AllLifeHacks(categoryId = "") {
  const location = useLocation();

  //store the state in a variable if you want
  //location.state then the property or object you want

  const Name = location.state;

  // console.log(Name)

  const [lifeHacks, setLifeHacks] = useState(null);
  let url =
    typeof categoryId === "object"
      ? "http://localhost:5260/lifeHack/newest"
      : `http://localhost:5260/lifeHack/category/${categoryId}`;
  useEffect(() => {
    fetch(url)
      .then((response) => response.json())
      .then((json) => setLifeHacks(json))
      .catch((error) => console.log(error));
  }, []);

  if (!lifeHacks) {
    const placeHolder = (
      <div className={styles.card}>
        <div className={styles.thumbnail}>
          <img
            className={styles.customImg}
            src={Placeholder}
            alt="Placeholder"
          />
        </div>
        <div className={styles.right}>
          <h1 className={styles.LHTitle}>Loading...</h1>
          <div className={styles.separator} />
          <p className={styles.paragraph}>Loading...</p>
        </div>
        <h5>25:61</h5>
        <h6>30 February</h6>
        <div className={styles.infoLink}>
          <img className={styles.infoImg} src={information} alt="Information" />
        </div>
      </div>
    );
    return (
      <>
        {placeHolder}
        {placeHolder}
        {placeHolder}
      </>
    );
  }

  return (
    <>
      {lifeHacks.map((lifeHack) => (
        <div key={lifeHack.id} className={styles.card}>
          <div className={styles.thumbnail} style={{width: '400px'}}>
            {lifeHack.image.length > 0 ? (
              <CarouselPage images={lifeHack.image} />
            ) : (
              <img
                className={styles.customImg}
                src={Placeholder}
                alt="Placeholder"
              />
            )}
          </div>
          <div className={styles.right}>
            <h1 className={styles.LHTitle}>{lifeHack.title}</h1>
            <div className={styles.separator} />
            <p className={styles.paragraph}>{lifeHack.description}</p>
            {lifeHack.link !== "" && (
              <>
                <div className={styles.separator} />
                <Link to={lifeHack.link} className={styles.paragraph}>
                  {lifeHack.link}
                </Link>
              </>
            )}
          </div>
          <h5 className={styles.time1}>
            {new Date(lifeHack.registeredTime).toLocaleTimeString("en-US", {
              hour12: false,
              hour: "2-digit",
              minute: "2-digit",
            })}
          </h5>
          <h6 className={styles.time2}>
            {new Date(lifeHack.registeredTime).toLocaleDateString("en-GB", {
              day: "numeric",
              month: "long",
              year: "numeric",
            })}
          </h6>
          <Link to={`/lifeHack/${lifeHack.id}`} className={styles.infoLink}>
            <img
              className={styles.infoImg}
              src={information}
              alt="Information"
            />
          </Link>
        </div>
      ))}
    </>
  );
}
