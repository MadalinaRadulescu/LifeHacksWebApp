import {useEffect} from "react";
import validator from 'validator'

export default function LinkChecking({url}) {
    console.log(url)
    // useEffect(() => {
    //     fetch(url, {
    //         dataType: "jsonp",
    //         crossDomain: true,
    //         url: url,
    //         method: "GET",
    //         timeout: 5000,
    //         headers: 'Head'
    //         }).then(response => {
    //         if (response.ok) {
    //             console.log('Link is valid');
    //         } else {
    //             console.log('Link is invalid');
    //         }
    //     })
    //         .catch(error => {
    //             console.log('Error:', error);
    //         })
    // });
    validator.isURL(url)
    return <>test</>
}