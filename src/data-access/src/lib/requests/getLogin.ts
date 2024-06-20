import { UserData } from "../pages";
import { Endpoints } from "../services/endpoints";
import axios from "axios";


export async function getLogin(loginInfo : UserData){
    try{
        const response = await axios({
            method: 'GET',
            url: Endpoints.authentication.login,
            data: loginInfo
        })
        console.log(response);
        
    } catch(error) {
        console.log(error);
    }
}