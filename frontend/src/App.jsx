import {Route, Routes} from "react-router-dom";
import Home from "./Pages/Home/Home";
import React from "react";
import Navbar from "./Components/Navbar/Navbar";
import LifeHack from "./Pages/LifeHack";
import Login from "./Pages/Login/Login";
import AddLifeHack from "./Pages/AddLifeHack";
import Register from "./Pages/Register/Register"
import "./App.css";
import Footer from "./Components/Footer/Footer";
import Categories from "./Pages/Categories/Categories";

const App = () => {
  return (
    <>
      <Navbar />
      <div>
        <Routes>
            <Route path="/" element={<Home/>} />
            <Route path="/Auth/login" element={<Login/>} />
            <Route path="/lifeHack/:LifeHackId" element={<LifeHack/>} />
            <Route path="/addLifeHack" element={<AddLifeHack/>} />
            <Route path="/Auth/register" element={<Register/>} />
          <Route path="/category" element={<Categories />} />
        </Routes>
      </div>
      <br />
      <Footer />
    </>
  );
};

export default App;