import {useState} from "react";

const Login = ()=>{
  const [user, setUser] = useState()  
    // const [ceva,setCeva] = useState();
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
            setUser(response)
        }
    };
  
    const handleSubmit = (event) =>{
        event.preventDefault();
        let form = new FormData();
        form.append("email",event.target.email.value)
        form.append("password",event.target.password.value)
        
     
        fetchData(form);
    };
    
    // const handleChange =(event) =>{
    //     setCeva(event.currentTarget.value);
    // };

    return (
        <>
        <div>
            <form onSubmit={handleSubmit}>
                <label>
                    Email:
                    <input type="text"  name="email"  id="email"/>
                </label>
                <label>
                    Password:
                    <input type="password" name="password"  />
                </label>
                <input type="submit" value="Submit" />
            </form>
            
        </div>
        </>
    )
};

export default Login;