import { useState } from "react";
import { getLogin, loginInfoAtom } from "../../../data-access";
import { useAtom } from "jotai";
import { emailValidation } from "../../functions";

export function useLogin() {
  const [email, setEmail] = useState('')
  const [senha, setSenha] = useState('')
  const [loginInfo, setLoginInfo] = useAtom(loginInfoAtom)
  const [emailIsError, setEmailIsError] = useState(false)

  function onSubmit(e : React.FormEvent<HTMLFormElement>){
    e.preventDefault()
    if(email !== '' && senha !== ''){
      if(emailValidation(email)){
        getLogin({
          email: email,
          password: senha
        })
      } else{
        setEmailIsError(true)
      }
    } else{

    }
    
  }

  return {
    email,
    setEmail,
    senha,
    setSenha,
    onSubmit,
    emailIsError
  };
}