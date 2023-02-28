import { useEffect } from "react";
import { useNavigate } from "react-router-dom";



const Logout = () => {
  let navigate = useNavigate();
  useEffect(() => {
    fetch("http://localhost:5260/api/Auth/Logout", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      credentials: "include",
      mode: "cors",
    })
      .then((response) => response.json())
      .then((r) => {
        // console.log(r)
        let path = `/`;
        document.cookie =
          "jwt= ; Path=/; expires = Thu, 01 Jan 1970 00:00:00 GMT";
        navigate(path);
      });
  }, [navigate]);
  
  window.localStorage.clear();



  return <></>;
};

export default Logout;
