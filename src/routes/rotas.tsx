import { createBrowserRouter } from "react-router-dom";
import { Home, Login } from "../libs";
export const router = createBrowserRouter([
    {
        path: '/',
        element: <Login/>,
        children: [{

        }, {
            
        }]
    },   
    {
        path: '/home',
        element: <Home/>,
        children: [{

        }, {
            
        }]
    },   
])