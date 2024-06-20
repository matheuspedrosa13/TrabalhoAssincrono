import './style.less';
import { LoginViewProps } from '../types'; 
import { BrownButton, GrayInput } from '../../../components';

export function LoginView({
  email,
  setEmail,
  senha,
  setSenha,
  onSubmit,
} : LoginViewProps) {
  return (
    <div className='LoginView'>
      <main>
        <header>
          <h1>Login</h1>
        </header>
        <form action="">
          <GrayInput placeHolder='Email' setValue={setEmail} value={email}/>
          <GrayInput placeHolder='Senha' setValue={setSenha} value={senha}/>
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