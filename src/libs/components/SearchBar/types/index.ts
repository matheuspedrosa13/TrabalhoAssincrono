export interface SearchBarProps{
    placeHolder?: string;
    value?: string;
    setValue: (value: string) => void;
    onPressEnter: (e: object) => void;
    className?: string;
    isDisabled: boolean;
}