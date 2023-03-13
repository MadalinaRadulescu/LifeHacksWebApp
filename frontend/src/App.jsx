import { Route, Routes } from "react-router-dom";
import React from "react";
import Navbar from "./Components/Navbar/Navbar";
import LifeHack from "./Pages/LifeHacks/IndividualLifeHack/LifeHack";
import Login from "./Pages/Login/Login";
import AddLifeHack from "./Pages/LifeHacks/AddLifeHack/AddLifeHack";
import Register from "./Pages/Register/Register"
import "./App.css";
import Footer from "./Components/Footer/Footer";
import Categories from "./Pages/Categories/Categories";
import Logout from "./Pages/Logout/Logout";
import Home from "./Pages/Home/Home"

const App = () => {
    return (
        <>
            <Navbar />
            <div>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/:categoryId" element={<Home />} />
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
