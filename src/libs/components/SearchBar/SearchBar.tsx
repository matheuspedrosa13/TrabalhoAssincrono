import { CiSearch } from 'react-icons/ci'
import './style.less'
import { SearchBarProps } from './types'
import { useAtom } from 'jotai'
export function SearchBar({
    placeHolder,
    value,
    onPressEnter,
    className,
    isDisabled,
    setValue
}: SearchBarProps) {
    return (
        <div className={isDisabled ? "isDisabled SearchBar " : "SearchBar " + className} onKeyUp={onPressEnter}>
            <div className="boxIcon">
                <CiSearch onClick={() => {
                }}/></div>
            <input type="text" 
                placeholder={placeHolder} 
                value={value} 
                onChange={(e) => {setValue(e.target.value)}}
            />
        </div>
    )
}