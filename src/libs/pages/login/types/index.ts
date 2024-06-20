
export interface LoginViewProps{
    email: string;
    setEmail: (value : string) => void;
    senha: string;
    setSenha: (value : string) => void;
    onSubmit: (e: React.FormEvent<HTMLFormElement>) => void;
    emailIsError: boolean;
    loginFail: boolean;
    isLoading: boolean;
}