import { useAtom } from "jotai";
import { useEffect, useState } from "react";
import { loginInfoAtom, perfilAtom } from "../../../data-access";
import { useNavigate } from "react-router-dom";

export function useHome() {
  const [arrButtons, setArrButtons] = useState([
    {
      text: 'Home',
      onClick: () => {}
    },
    {
      text: 'Pesquisar',
      onClick: () => {}
    },
  {
    text: 'Explorar',
    onClick: () => {}
  }
])
  const [arrButtonsFooter, setArrButtonsFooter] = useState([{
    text: 'Perfil',
    onClick: () => {navigate('/perfil')}
  }])
  const [loginInfo, setLoginInfo] = useAtom(loginInfoAtom)
  const [recomendatioArr, setRecomendatioArr] = useState([
    {
      username: 'realmp',
      name: 'Matheus Pedrosa'
    },
    {
      username: 'guifelipee___',
      name: 'Real Golden Boy'
    },
    {
      username: 'juanaraujo_',
      name: 'Juan Araujo'
    },
  ])
  const [searchValue, setSearchValue] = useState('')
  const [perfil, setPerfil] = useAtom(perfilAtom)
  const navigate = useNavigate()

  function logOut(){
    setLoginInfo({
      email: '',
      password: ''
    })
    localStorage.clear()
    navigate('/')
  }

  function onSearch(){
    console.log(searchValue);
    
  }
  return {
    arrButtons,
    arrButtonsFooter,
    logOut,
    recomendatioArr,
    onSearch,
    searchValue,
    setSearchValue,
    perfil
  };
}