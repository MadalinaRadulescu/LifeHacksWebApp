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
          <Route path="/" element={<Home />} />
          <Route path="/category" element={<Categories />} />
          <Route path="/Auth/login" element={<Login />}></Route>
          <Route path="/Auth/register" element={<Register />}></Route>
        </Routes>
      </div>
      <br />
      <Footer />
    </>
  );
};

export default App;
