import { useState } from "react";

export function useLogin() {
  const [email, setEmail] = useState('')
  const [senha, setSenha] = useState('')
  
  function onSubmit(){

  }

  return {
    email,
    setEmail,
    senha,
    setSenha,
    onSubmit
  };
}