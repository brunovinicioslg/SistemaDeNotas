using SistemaDeNotas.Data;
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
        public List<NotaModel> BuscarTodos()
        {
            return _bancoContext.Notas.ToList();
        }
        public NotaModel Adicionar(NotaModel nota)
        {
            //gravar no banco de dados
            NotaModel notaDB = ListarPorMateria(nota.Materia);
            if (notaDB != null) throw new Exception("Já existe uma matéria com esse nome!");
            _bancoContext.Notas.Add(nota);
            _bancoContext.SaveChanges();
            return nota;
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
