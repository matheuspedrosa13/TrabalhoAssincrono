
export interface LoginViewProps{
    email: string;
    setEmail: (value : string) => void;
    senha: string;
    setSenha: (value : string) => void;
    onSubmit: () => void;
    
}