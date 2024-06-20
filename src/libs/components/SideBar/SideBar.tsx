import { OptionButton } from '../OptionButton';
import './style.less';
import {SideBarProps} from './types/';

export function SideBar({
    logo,
    arrButtons,
    arrFooterButtons,
    logOut,
} : SideBarProps) {
  return (
    <div className='SideBar'>
        <header><img src={logo} alt="logo do app" /></header>
        <main>
            {arrButtons.map((item, index) => (
                <OptionButton onClick={item.onClick} text={item.text}/>
            ))}
        </main>
        <footer>
            {arrFooterButtons?.map((item, index) => (
                <OptionButton onClick={item.onClick} text={item.text}/>
            ))}
            <OptionButton text='LogOut' onClick={logOut}/>
        </footer>
    </div>
  );
}