import './style.less';
import {OptionButtonProps} from './types/';

export function OptionButton({text, onClick, classname} : OptionButtonProps) {
  return (
    <button className={'OptionButton ' + classname} onClick={onClick} type='button'>
        {text}
    </button>
  );
}