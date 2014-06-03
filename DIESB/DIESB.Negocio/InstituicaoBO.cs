using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIESB.Negocio
{
    public class InstituicaoBO
    {
        public IList<UF> GetUFS()
        {
            using (var db = new DIESBContext())
            {
                return db.Instituicao.Select(x => x.UF).Distinct().ToList();
            }
        }

        public IList<IndexViewModel> GetByCursosSearch(String curso, String UF)
        {
            using (var db = new DIESBContext())
            {
                return db.ProgramaPosGraduacao.Where(x => String.IsNullOrEmpty(UF) ? true : x.Instituicao.UF.Descricao == UF && String.IsNullOrEmpty(curso) ? true : x.Descricao.Contains(curso))
                    .Select(x => new IndexViewModel { Instituicao = x.Instituicao, ProgramaPosGraduacao = x }).Distinct().ToList();
            }
        }
    }
}
