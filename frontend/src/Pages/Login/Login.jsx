import { useEffect, useState } from "react";
import { redirect} from "react-router-dom";
import Home from "../Home"
import styles from "./styles.module.scss"
// import { useNavigate } from "react-router-dom";

// function CheckUser({form}){
//     const [user, setUser] = useState()
//     useEffect(()=>{
//         fetch("http://localhost:5260/api/Auth/login", {
//                     method: "POST",
//                     headers: {
//                         'credentials': "include",
//                         'Token': "dummy-token"
//                         // DON'T overwrite Content-Type header
//                     },
//                     body: form
//                 }).then(response=>response.json())
//                 .then(json=>setUser(json))
//                 .catch(error=>console.log(error));
//     },[form]);
//     console.log(user)
//     if(user.isSucces){
//         return redirect("/");
//     }
// }

const Login = ()=>{
    const [user, setUser] = useState()
  const [error, setError] = useState() 
    const fetchData = async(form) =>{
        console.log(form.get("email"), " din fetch!!!!!")
        let response = await  fetch("http://localhost:5260/api/Auth/login",{
            method: "POST",
            headers: {
                'credentials': "include",
                'Token': "dummy-token"
                // DON'T overwrite Content-Type header
            },
            body: form
        });
    
        if (response.ok){
            let data = await response.json()
            console.log(data)
            setUser(data)
            
        }
        
    };
  
    const handleSubmit = (event) =>{
        event.preventDefault();
        // const navigate = useNavigate();
        let form = new FormData();
        form.append("email",event.target.email.value)
        form.append("password",event.target.password.value)
        
        fetchData(form);
        
        
        
    
    };
    if(user){
        if (user.isSuccess){
            console.log("am ajuns pana aici!!!!")
            return <Home />
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
                    <input type="text"  name="email"  id="email"/>
                </label>
                <br/>
                <label className={styles.password}>
                    Password:<br/>
                    <input type="password" name="password"  />
                </label>
                {user && 
                <div> {user.message}</div>
                }
                <br/>
                <input type="submit" value="Submit" />

            </form>
            
        </div>
        </>
    )
};

export default Login;