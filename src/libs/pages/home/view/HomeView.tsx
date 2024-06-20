import './style.less';
import {HomeViewProps} from '../types';
import { RecomendationBox, SearchBar, SideBar } from '../../../components';

export function HomeView({
    arrButtons,
    arrButtonsFooter,
    logOut,
    recomendatioArr,
    onSearch,
    searchValue,
    setSearchValue,
    perfil
} : HomeViewProps) {
  return (
    <div className='HomeView'>
        <SideBar 
            arrButtons={arrButtons} 
            arrFooterButtons={arrButtonsFooter} 
            logOut={logOut} />
            <main>
                <SearchBar 
                    isDisabled={false} 
                    onPressEnter={onSearch}
                    setValue={setSearchValue}
                    value={searchValue}
                    className='searchBarApp'
                />
            {
                perfil.valid && (
                    <div className="perfil">
                        <h1>{perfil.nome}</h1>
                        <section className='infoPerfil'>
                            
                        </section>
                        <footer></footer>
                    </div>
                )
            }
                
            </main>
            <aside className='recomendation'>
                {
                    recomendatioArr.map((item, index) => (
                        <RecomendationBox name={item.name} username={`@${item.username}`}/>
                    ))
                }
            </aside>
    </div>
  );
}