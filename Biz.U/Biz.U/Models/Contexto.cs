using PCLExt.FileStorage.Folders;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biz.U.Models
{
    public class Contexto
    {
        public SQLite.SQLiteConnection conexao;

        public Contexto()
        {
            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile("bizudb", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
            conexao = new SQLiteConnection(arquivo.Path);
            conexao.CreateTable<Usuario>();
        }

        public bool InserirDados<T>(T model)
        {
            conexao.Insert(model);

            return true;

        }

        public void Deletar<T>(T model)
        {
            conexao.Delete(model);
        }

        public void AtualizaDados<T>(T model)
        {
            conexao.Update(model);
        }
    }
}
