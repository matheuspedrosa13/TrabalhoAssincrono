import { useHome } from './useHome';
import { HomeView } from './view/HomeView';

export function Home() {

const {
    arrButtons,
    arrButtonsFooter,
    logOut,
    recomendatioArr,
    onSearch,
    searchValue,
    setSearchValue,
    perfil,
} = useHome();
  return (
<HomeView
    arrButtons={arrButtons}
    arrButtonsFooter={arrButtonsFooter}
    logOut={logOut}
    recomendatioArr={recomendatioArr}
    onSearch={onSearch}
    searchValue={searchValue}
    setSearchValue={setSearchValue}
    perfil={perfil}
/>
  );
}