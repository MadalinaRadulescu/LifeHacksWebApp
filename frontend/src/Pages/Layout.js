import React from 'react';
import {Link} from "react-router-dom";

const Layout = ({children}) => {
    return (
        <>
            <header className="App-header">
                <nav>
                    {/* Nav Bar Space */}
                    {/* link model :*/}
                    {/*<Link to="/" className="App-link">Home</Link>*/}
                    {/*<Link to="/lifeHack" className="App-link">LifeHack</Link>*/}
                    {/*<Route path="/Profile" element={<Profile/>}/>*/}
                </nav>
            </header>
            <main>{children}</main>
            <footer>
                This is an example project for practicing React routing
            </footer>
        </>
    )
}

export default Layout;