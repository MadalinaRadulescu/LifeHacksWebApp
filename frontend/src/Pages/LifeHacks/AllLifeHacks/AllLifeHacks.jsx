import React, { useEffect, useState } from "react";
import Placeholder from "../../../Images/Placeholder.png";
import information from "../../../Images/information.png";
import styles from "./styles.module.sass";
import {Link} from "react-router-dom";

export default function AllLifeHacks({categoryId}) {
    console.log(categoryId)
    const [lifeHacks, setLifeHacks] = useState(null);
    let url = (categoryId === undefined)? 'http://localhost:5260/lifeHack/newest' : `http://localhost:5260/lifeHack/category/${categoryId}`
    useEffect(() => {
        fetch(url)
            .then((response) => response.json())
            .then((json) => setLifeHacks(json))
            .catch((error) => console.log(error));
    }, [categoryId]);

    if (!lifeHacks) {
        const placeHolder = (<div className={styles.card}>
                <div className={styles.thumbnail}>
                    <img
                        className={styles.customImg}
                        src={Placeholder}
                        alt="Placeholder"
                    />
                </div>
                <div className={styles.right}>
                    <h1 className={styles.LHTitle}>Loading...</h1>
                    <div className={styles.separator}/>
                    <p className={styles.paragraph}>Loading...</p>
                </div>
                <div className={styles.time}>
                    <h5 className={styles.time2}>1 January 2023</h5>
                    <h5 className={styles.time1}>00:00</h5>
                </div>
                <div className={styles.infoLink}>
                    <img
                        className={styles.infoImg}
                        src={information}
                        alt="Information"
                    />
                </div>
            </div>);
        return (<>
                {placeHolder}
                {placeHolder}
                {placeHolder}
            </>);
    }

  return (
    <>
      {lifeHacks.map((lifeHack) => (
        <div key={lifeHack.id} className={styles.card}>
          <div className={styles.thumbnail} >
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
          </div>
          <div className={styles.time}>
          <h5 className={styles.time2}>
      {new Date(lifeHack.registeredTime).toLocaleDateString("en-GB", {
          day: "numeric", month: "long", year: "numeric",
      })}
          </h5>
          <h5 className={styles.time1}>
      {new Date(lifeHack.registeredTime).toLocaleTimeString("en-US", {
          hour12: false, hour: "2-digit", minute: "2-digit",
      })}
          </h5>
          </div>
          <Link to={`/lifeHack/${lifeHack.id}`} className={styles.infoLink}>
          <img className={styles.infoImg} src={information} alt="Information"/>
          </Link>
          </div>))}
    </>
  );
}

