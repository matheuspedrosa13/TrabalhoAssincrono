import { atom } from "jotai"; 

export interface UserData{
    email: string;
    password: string;
}

export interface Response{
    // data: 
}

export const loginInfoAtom = atom<UserData>({
    email: '',
    password: ''
})

// const loginResponse = atom<Response>({

// })