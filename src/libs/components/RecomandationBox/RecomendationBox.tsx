import { useNavigate } from 'react-router-dom';
import { OptionButton } from '../OptionButton';
import './style.less';
import {RecomendationBoxProps} from './types/';

export function RecomendationBox({
    username,
    name,
} : RecomendationBoxProps) {
    return (
    <div className='RecomendationBox'>
        <header>
            <h2>{name}</h2>
            <h3>{username}</h3>
        </header>
        <OptionButton text='Ver Perfil' classname='verPerfil' onClick={() => {
            
        }}/>
    </div>
  );
}