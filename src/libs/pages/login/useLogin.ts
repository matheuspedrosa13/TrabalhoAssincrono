import { useState } from "react";
import { getLogin, loginInfoAtom } from "../../../data-access";
import { useAtom } from "jotai";
import { emailValidation } from "../../functions";
import { useNavigate } from "react-router-dom";

export function useLogin() {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [loginInfo, setLoginInfo] = useAtom(loginInfoAtom);
  const [emailIsError, setEmailIsError] = useState(false);
  const [loginFail, setLoginFail] = useState(false);
  const [isLoading, setIsLoading] = useState(false);

  const navigate = useNavigate()
  async function onSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();
    setEmailIsError(false)
    if (email !== '' && senha !== '') {
      if (emailValidation(email)) {
        const loginSuccess = await getLogin({ email: email, password: senha}, setIsLoading);
        if (loginSuccess) {
          setEmail('')
          setSenha('')
          localStorage.setItem('taLogado?', 'sim')
          setLoginInfo({
            email: email,
            password: senha
          })
          navigate('/home')

        } else {
          setLoginFail(true)
        }
      } else {
        setEmailIsError(true);
      }
    } else {
      alert('preencha')
    }
  }

  return {
    email,
    setEmail,
    senha,
    setSenha,
    onSubmit,
    emailIsError,
    loginFail,
    isLoading
  };
}
