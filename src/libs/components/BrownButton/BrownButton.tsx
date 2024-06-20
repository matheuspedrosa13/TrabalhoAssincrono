import './style.less'
import { BrownButtonProps } from './types'

export function BrownButton({
    text,
    onClick,
}: BrownButtonProps){
    return(
        <button className='BrownButton' onClick={onClick}>
            {text}
        </button>
    )
}