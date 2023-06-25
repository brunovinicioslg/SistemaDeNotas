using Microsoft.EntityFrameworkCore;
using SistemaDeNotas.Data;
using SistemaDeNotas.Models;

namespace SistemaDeNotas.Repositorio
{
    public class AvisosRepositorio : IAvisosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public AvisosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public AvisosModel ListarPorId(int id)
        {
            return _bancoContext.Avisos.FirstOrDefault(x => x.Id == id);
        }
        public List<AvisosModel> BuscarTodosAdm()
        {
            return _bancoContext.Avisos.ToList();
        }
        public AvisosModel Adicionar(AvisosModel aviso)
        {
            _bancoContext.Avisos.Add(aviso);
            _bancoContext.SaveChanges();
            return aviso;
        }

        public bool Apagar(int id)
        {
            AvisosModel avisoDB = ListarPorId(id);
            if (avisoDB == null) throw new Exception("Houve um erro ao apagar!");
            _bancoContext.Avisos.Remove(avisoDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public AvisosModel Atualizar(AvisosModel aviso)
        {
            AvisosModel avisoDB = ListarPorId(aviso.Id);

            if (avisoDB == null) throw new Exception("Houve um erro na atualização!");
            avisoDB.AvisoTitulo = aviso.AvisoTitulo;
            avisoDB.AvisoCorpo = aviso.AvisoCorpo;
            _bancoContext.Avisos.Update(avisoDB);
            _bancoContext.SaveChanges();
            return avisoDB;
        }
        
    }
}
