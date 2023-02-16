import {Route, Routes} from "react-router-dom";
import Home from "./Pages/Home";
import Layout from "./Pages/Layout";
import React from "react";
import Navbar from "./Components/Navbar/Navbar";
import LifeHack from "./Pages/LifeHack";
import Login from "./Pages/Login/Login";
import AddLIfeHack from "./Pages/AddLIfeHack";
import Register from "./Pages/Register/Register"


const App = () => {
    
  return (
      <div className="App">
          <Navbar/>
        <Routes>
            <Route path="/" element={<Home/>} />
            <Route path="/Auth/login" element={<Login/>} />
            <Route path="/lifeHack/:LifeHackId" element={<LifeHack/>} />
            <Route path="/addLIfeHack" element={<AddLIfeHack/>} />
            <Route path="/" element={<Home/>} />
            <Route path="/Auth/register" element={<Register/>} />
        </Routes>
        <Layout />
      </div>
  );
};

export default App;