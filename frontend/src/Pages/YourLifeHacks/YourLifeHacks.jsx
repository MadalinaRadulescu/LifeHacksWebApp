import React, { useEffect, useState } from "react";
import Placeholder from "../../Images/Placeholder.png";
import information from "../../Images/information.png";
import styles from "../LifeHacks/AllLifeHacks/styles.module.sass";
import { Link, useLocation, useParams } from "react-router-dom";
import { CarouselPage } from "../../Components/Carousel/CarouselPage";

export default function YourLifeHacks() {
    const{userId}= useParams();
    console.log(userId)
    const [yourLifeHacks, setYourLifeHacks] = useState(null);

    
    useEffect(() => {
      fetch(`http://localhost:5260/lifeHack/user/${userId}`)
        .then((response) => response.json())
        .then((json) => setYourLifeHacks(json))
        .catch((error) => console.log(error));
    }, []);
    console.log(yourLifeHacks)
    console.log("am ajuns aici")
  
    if (!yourLifeHacks) {
        return (<>
        <p>You did not post anything</p>
        </>)
    }

  
    return (
      <>
        {yourLifeHacks.map((lifeHack) => (
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