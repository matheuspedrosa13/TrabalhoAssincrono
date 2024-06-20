import { createBrowserRouter } from "react-router-dom";
import { Login } from "../libs";
export const router = createBrowserRouter([
    {
        path: '/',
        element: <Login/>,
        children: [{

        }, {
            
        }]
    },   
])