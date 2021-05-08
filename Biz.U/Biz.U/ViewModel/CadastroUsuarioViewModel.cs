using Biz.U.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Biz.U.Views;

namespace Biz.U.ViewModel
{
    public class CadastroUsuarioViewModel : BaseViewModel
    {
        private string _Nome;
        private string _Senha;
        private bool _Result;
        private bool _IsBusy;
        private Contexto conexao;

        public Command CadastroUsuarioCommand { get; set; }

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

        public CadastroUsuarioViewModel()
        {
            CadastroUsuarioCommand = new Command(() => CadastroCommand());
        }

        private void CadastroCommand()
        {
            conexao = new Contexto();
            var buscaUsuario = conexao.conexao.Query<Usuario>("select * from Usuario where UsuarioNome = ?", Nome);

            if (buscaUsuario?.Count > 0)
            {
                Application.Current.MainPage.DisplayAlert("Erro", "Usuário Já Cadastrado", "OK");
            }
            else
            {
                try
                {
                    Usuario user = new Usuario();
                    var userServices = new Contexto();
                    user.UsuarioNome = Nome;
                    user.UsuarioSenha = Senha;                    
                    Result = userServices.InserirDados(user);

                    if (Result)
                    {
                        Application.Current.MainPage.DisplayAlert("Sucesso", "Usuário Registrado Com Sucesso", "OK");                        
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
