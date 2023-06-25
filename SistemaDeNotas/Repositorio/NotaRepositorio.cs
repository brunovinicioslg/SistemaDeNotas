using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SistemaDeNotas.Data;
using SistemaDeNotas.Enums;
using SistemaDeNotas.Filters;
using SistemaDeNotas.Models;

namespace SistemaDeNotas.Repositorio
{
    public class NotaRepositorio : INotaRepositorio
    {
        private readonly BancoContext _bancoContext;
        public NotaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public NotaModel ListarPorId(int id)
        {
            return _bancoContext.Notas.FirstOrDefault(x => x.Id == id);
        }

        public List<NotaModel> BuscarTodos(int usuarioId)
        {
            return _bancoContext.Notas.Where(x=>x.UsuarioID == usuarioId).ToList();
        }
        public List<NotaModel> BuscarTodosAdm()
        {
            return _bancoContext.Notas.ToList();
        }
        public NotaModel Adicionar(NotaModel nota2)
        {

            _bancoContext.Notas.Add(nota2);
            _bancoContext.SaveChanges();
            return nota2;
        }


        public NotaModel Atualizar(NotaModel nota)
        {
           NotaModel notaDB = ListarPorId(nota.Id);
            
            if (notaDB == null) throw new Exception("Houve um erro na atualização!");
            notaDB.Materia = nota.Materia;
            notaDB.Nota1Bimestre = nota.Nota1Bimestre;
            notaDB.Nota2Bimestre = nota.Nota2Bimestre;
            notaDB.Nota3Bimestre = nota.Nota3Bimestre;
            notaDB.Nota4bimestre = nota.Nota4bimestre;
            _bancoContext.Notas.Update(notaDB);
            _bancoContext.SaveChanges();
            return notaDB;
        }

        public bool Apagar(int id)
        {
            NotaModel notaDB = ListarPorId(id);
            if (notaDB == null) throw new Exception("Houve um erro ao apagar!");
            _bancoContext.Notas.Remove(notaDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public NotaModel ListarPorMateria(string mat)
        {
            return _bancoContext.Notas.FirstOrDefault(x => x.Materia == mat);

        }


    }
}
