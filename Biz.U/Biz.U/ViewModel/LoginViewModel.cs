using Biz.U.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Biz.U.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Nome;
        private string _Senha;
        private bool _Result;
        private bool _IsBusy;
        private Contexto conexao;

        public Command VerificaUsuarioCommand { get; set; }

        public string Nome
        {
            get
            {
                return this._Nome;
            }
            set
            {
                this._Nome = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get
            {
                return this._Senha;
            }
            set
            {
                this._Senha = value;
                OnPropertyChanged();
            }
        }

        public bool Result
        {
            get
            {
                return this._IsBusy;
            }
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
        }

        //Método para verificar se o login está sendo realizado para evitar concorrência
        public bool IsBusy
        {
            get
            {
                return this._Result;
            }
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            VerificaUsuarioCommand = new Command(() => VerificaSeUsuarioExisteCommand());
        }

        private void VerificaSeUsuarioExisteCommand()
        {
            conexao = new Contexto();
            var buscaUsuario = conexao.conexao.Query<Usuario>("select * from Usuario where UsuarioNome = ?", _Nome);

            if(buscaUsuario?.Count > 0)
            {
                foreach(Usuario user in buscaUsuario)
                {
                    if(user.UsuarioNome.Equals(Nome)&& user.UsuarioSenha.Equals(Senha))
                    {
                        Application.Current.MainPage.DisplayAlert("Liberado", "Seja Bem-Vindo(a)", "OK");
                        App.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Erro", "Dados Não Conferem", "OK");
                    }
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Info", "Usuário Não Cadastrado", "OK");
            }
        }
    }
}
