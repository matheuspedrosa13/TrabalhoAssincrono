export interface GrayInputProps{
    placeHolder: string;
    value: string;
    setValue: (value: string) => void;
    errorMessage?: string;
    isError?: boolean;
    isTitleFixed?: boolean;
    required?: boolean
}