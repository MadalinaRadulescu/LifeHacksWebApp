import { useEffect, useState } from "react";
import { redirect, useNavigate} from "react-router-dom";
import Home from "../Home/Home"
import styles from "./styles.module.scss"


const Login = ()=>{
    let navigate = useNavigate();
    const [user, setUser] = useState();
    
    const fetchData = async(form) =>{
        console.log(form.get("email"), " din fetch!!!!!")
        let response = await  fetch("https://localhost:44330/api/Auth/login",{
            method: "POST",
            headers: {
                'credentials': "include",
                'Token': "dummy-token"
                // DON'T overwrite Content-Type header
            },
            body: form
        });
    
        if (response.ok){
            let data = await response.json();
            console.log(data);
            setUser(data);
        }
        
    };

  
    const handleSubmit = (event) =>{
        event.preventDefault();

        let form = new FormData();
        form.append("email",event.target.email.value)
        form.append("password",event.target.password.value)
        
        fetchData(form);
       
    };
    
        
    if(user){
        if (user.isSuccess){
            let path = `/`;
            navigate(path);
        }   
    }
        
    

    return (
        <>
        <div className={styles.form}>
            <h1>Log in</h1>
            <br/>
            <form onSubmit={handleSubmit}>
                
                <label className={styles.email}>
                    Email:<br/>
                    <input type="email"  name="email"  id="email" placeholder="Enter Email"/>
                </label>
                <br/>
                <label className={styles.password}>
                    Password:<br/>
                    <input type="password" name="password" placeholder="Enter Password" />
                </label>
                {user && 
                <div> {user.message}</div>
                }
                <br/>
                <input type="submit" value="Login"  />

            </form>
            
        </div>
        </>
    )
};

export default Login;