import {Route, Routes} from "react-router-dom";
import Home from "./Pages/Home";
import React from "react";
import Navbar from "./Components/Navbar/Navbar";
import LifeHack from "./Pages/LifeHack";
import Login from "./Pages/Login/Login";
import AddLIfeHack from "./Pages/AddLIfeHack";
import Register from "./Pages/Register/Register"

import "./App.css";
import { Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Navbar from "./components/Navbar/Navbar";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";
import Footer from "./components/Footer/Footer";
import Categories from "./pages/Categories/Categories";

const App = () => {
  return (
    <>
      <Navbar />
      <div>
        <Routes>
            <Route path="/" element={<Home/>} />
            <Route path="/Auth/login" element={<Login/>} />
            <Route path="/lifeHack/:LifeHackId" element={<LifeHack/>} />
            <Route path="/addLIfeHack" element={<AddLIfeHack/>} />
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