import {Route, Routes} from "react-router-dom";
import Home from "./Pages/Home";
import Layout from "./Pages/Layout";
import React from "react";
import Navbar from "./components/Navbar/Navbar";
import Login from "./Pages/Login/Login";
import Register from "./Pages/Register/Register"


const App = () => {
    
  return (
      <div className="App">
          <Navbar/>
        <Routes>
            <Route path="/" element={<Home/>}/>
            <Route path="/Auth/login" element={<Login/>}></Route>
            <Route path="/Auth/register" element={<Register/>}></Route>
        </Routes>
        <Layout />
      </div>
  );
};

export default App;