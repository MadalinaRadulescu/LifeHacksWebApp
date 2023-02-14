import {Route, Routes} from "react-router-dom";
import Home from "./Pages/Home";
import Layout from "./Pages/Layout";
import React from "react";
import Navbar from "./Components/Navbar/Navbar";


const App = () => {
    
  return (
      <div className="App">
          <Navbar/>
        <Routes>
            <Route path="/" element={<Home/>}/>
        </Routes>
        <Layout />
      </div>
  );
};

export default App;