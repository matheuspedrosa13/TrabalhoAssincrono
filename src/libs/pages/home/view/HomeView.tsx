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