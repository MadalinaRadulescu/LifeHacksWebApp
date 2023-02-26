import React from 'react';

const Layout = ({children}) => {
    return (
        <>
            <header className="App-header">
            </header>
            <main>{children}</main>
            <footer>
                © 2023 LifeSaverHub
            </footer>
        </>
    )
}

export default Layout;