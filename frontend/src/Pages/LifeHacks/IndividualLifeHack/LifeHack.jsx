import React, { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { CommentByLifeHack } from "../../../Components/Comments/CommentByLifeHack";
import { GetUserName } from "../../../Components/Users/GetUserName";
import styles from "./styles.module.sass";
import Placeholder from "../../../Images/Placeholder.png";
import information from "../../../Images/information.png";

const LifeHack = () => {
  const id = useParams().LifeHackId;
  const [lifeHack, setLifeHack] = useState(null);

  useEffect(() => {
    fetch(`http://localhost:5260/lifeHack/${id}`)
      .then((response) => response.json())
      .then((json) => setLifeHack(json))
      .catch((error) => console.log(error));
  }, []);

  if (!lifeHack) {
    return (
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
        <div className={styles.fab}>
          <img
            className={styles.customImg}
            src={information}
            alt="Information"
          />
        </div>
       </div>
     );
   }

  document.title = lifeHack.title;

  return (
    <div className={styles.container}>
      <h1 className="PageTitle">{lifeHack.title}</h1>
      <div className={styles.card}>
        <div className={styles.thumbnail}>
          {lifeHack.image.length > 0 ? (
            <img
              className={styles.customImg}
              src={lifeHack.image[0]}
              alt={lifeHack.image[0]}
            />
          ) : (
            <img
              className={styles.customImg}
              src={Placeholder}
              alt="Placeholder"
            />
          )}
        </div>
              <div className={styles.right}>
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
      </div>

      <CommentByLifeHack id={lifeHack.id} />
      <GetUserName id={lifeHack.userId} />
    </div>
  );
};
export default LifeHack;
