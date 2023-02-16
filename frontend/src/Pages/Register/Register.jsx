import { useState } from "react";
import { useNavigate } from "react-router-dom"
import styles from "./styles.module.scss"



const Register = () => {
    const navigate = useNavigate();
    const[user, setUser] = useState();
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;


    
    const fetchData = async(form)=>{
        console.log(form.get("email"), " din fetch!!!!!")
        let response = await fetch("https://localhost:44330/api/Auth/register", {
            method: "POST",
            headers: {
            
                'credentials': "include",
                'Token': "dummy-token"
                
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
        form.append("email",event.target.email.value);
        form.append("password",event.target.password.value);
        form.append("confirmPassword",event.target.confirmPassword.value);
        console.log(event.target.password.value)
        console.log(event.target.confirmPassword.value)

        if(!emailRegex.test(event.target.email.value)){
            alert("Email requierd!")
        }
        else if(!event.target.password.value || !event.target.confirmPassword.value){
            alert("Passowrd and confirm password requaired!")
        }else if(event.target.password.value !== event.target.confirmPassword.value){
            alert("Password does not match confirm password!")
        }
        else{
            fetchData(form)
        }
        
    };

    if(user){
        if (user.isSuccess){
            let path = `/Auth/login`;
            navigate(path);
        }   
    }



    return(
        <>
        <div className={styles.form}>
            <h1>Register</h1>
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
                <label className={styles.confirmPassword}>
                    Confirm Password:<br/>
                    <input type="password" name="confirmPassword" placeholder="Confirm Password" />
                </label>
                <br/>
                <input type="submit" value="Register"  />

            </form>
            
        </div>
        </>
    )

};
export default Register;