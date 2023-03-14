import React from "react";
import { Carousel } from "react-responsive-carousel";
import "react-responsive-carousel/lib/styles/carousel.min.css";

export function CarouselPage({ images }) {
  return (
    <Carousel>
      {images.map((image) => (
        <div>
          <img src={image} alt={image}  />
        </div>
      ))}
    </Carousel>
  );
}
