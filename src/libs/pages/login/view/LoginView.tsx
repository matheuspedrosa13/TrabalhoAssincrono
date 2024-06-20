import './style.less';
import { LoginViewProps } from '../types'; 
import { BrownButton, GrayInput, LoadingCircle } from '../../../components';

export function LoginView({
  email,
  setEmail,
  senha,
  setSenha,
  onSubmit,
  emailIsError,
  loginFail,
  isLoading
} : LoginViewProps) {
  return (
    <div className='LoginView'>
      <main>
        <header>
          <h1>Login</h1>
        </header>
        <form action="" onSubmit={onSubmit}>
          <GrayInput placeHolder='Email' setValue={setEmail} value={email} errorMessage='Formato de email inválido' isError={emailIsError}/>
          <GrayInput placeHolder='Senha' setValue={setSenha} value={senha} errorMessage='Login falhou' isError={loginFail}/>
          {
            isLoading && (
              <LoadingCircle className='loading'/>
            )
            }
          <BrownButton text='Login' onClick={() => {}}/>
        </form>
      </main>
      <aside>
        <h1>Assincronismo em CSHARP</h1>
        <h3>Você sabia? Daniel Freitas Neto, ja foi jogador profissional.Conhecido pelas suas pedaladas rapidas e habilidosas, além de sua excepcional característica de goleador.</h3>
        <h3>Danile atuou nos clubes: São bernardo (Sp) e Milan b (Itália).</h3>
      </aside>
    </div>
  );
}