import { UserData } from "../pages";
import { Endpoints } from "../services/endpoints";
import axios from "axios";


export async function getLogin(loginInfo : UserData, setIsloading : (value: boolean) => void) : Promise<boolean>{
    try{
        setIsloading(true)
        const response = await axios({
            method: 'GET',
            url: `${Endpoints.authentication.login}${loginInfo.email}/${loginInfo.password}`,
            data: loginInfo
        }).finally(() => {
            setIsloading(false)
        })
        if(response.data === 'Logado'){
            return true
        } else{
            return false
        }
        
    } catch(error) {
        return false
    }
}