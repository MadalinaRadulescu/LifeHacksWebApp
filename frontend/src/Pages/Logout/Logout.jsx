import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Home from "../Home/Home";
import { useAtom } from "jotai";
import {RESET} from "jotai/utils"
import state from "../../Store";

const Logout = () => {
    const[user, setUser] = useAtom(state.userData)
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
                setUser(RESET)
                let path = `/`;
                document.cookie =
                    "jwt= ; Path=/; expires = Thu, 01 Jan 1970 00:00:00 GMT";
                navigate(path);
            });
    }, [navigate]);
    

    return(<></>)
};

export default Logout;
