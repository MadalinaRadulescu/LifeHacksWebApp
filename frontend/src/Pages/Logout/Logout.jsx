import { useEffect } from "react";
import { useNavigate } from "react-router-dom";

const Logout = () => {
    let navigate = useNavigate();
    useEffect(() => {
        fetch("https://localhost:44330/api/Auth/Logout", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            credentials: "include",
            mode: "cors",
        })
            .then((response) => response.json())
            .then((r) => {
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
