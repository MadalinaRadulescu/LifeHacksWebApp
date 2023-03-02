import { Route, Routes } from "react-router-dom";
import React from "react";

import "./App.css";

import Navbar from "./components/Navbar/Navbar";
import Home from "./Pages/Home/Home";
import Login from "./Pages/Login/Login";
import LifeHack from "./Pages/LifeHacks/LifeHack";
import AddLifeHack from "./Pages/LifeHacks/AddLifeHack";
import Register from "./Pages/Register/Register";
import Categories from "./Pages/Categories/Categories";
import Logout from "./Pages/Logout/Logout";
import Footer from "./components/Footer/Footer";

const App = () => {
    return (
        <>
            <Navbar />
            <div>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/Auth/login" element={<Login />} />
                    <Route
                        path="/lifeHack/:LifeHackId"
                        element={<LifeHack />}
                    />
                    <Route path="/addLifeHack" element={<AddLifeHack />} />
                    <Route path="/Auth/register" element={<Register />} />
                    <Route path="/category" element={<Categories />} />
                    <Route path="/Auth/Logout" element={<Logout />} />
                </Routes>
            </div>
            <br />
            <Footer />
        </>
    );
};

export default App;
