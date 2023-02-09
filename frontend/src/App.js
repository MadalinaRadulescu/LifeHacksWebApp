import {Route, Routes} from "react-router-dom";
import Home from "./Pages/Home";
import Layout from "./Pages/Layout";
import React from "react";


const App = () => {
    
  return (
      <div className="App">
        <Routes>
            <Route path="/" element={<Home/>}/>
        </Routes>
        <Layout />
      </div>
  );
};

export default App;