import { useLogin } from './useLogin';
import { LoginView } from './view/LoginView';

export function Login() {

  const {
    email,
    senha,
    setEmail,
    setSenha,
    onSubmit,
    loginFail,
    emailIsError,
    isLoading,
  } = useLogin();
  return (
    <LoginView
      email={email}
      onSubmit={onSubmit}
      senha={senha}
      setSenha={setSenha}
      setEmail={setEmail}
      emailIsError={emailIsError}
      loginFail={loginFail}
      isLoading={isLoading}
    />
  );
}