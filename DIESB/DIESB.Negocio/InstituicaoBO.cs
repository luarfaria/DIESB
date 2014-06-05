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

        public IList<IndexViewModel> GetByCursosSearch(String curso, String UF, int pagina)
        {
            using (var db = new DIESBContext())
            {
                IList<IndexViewModel> list = new List<IndexViewModel>();
                if(!String.IsNullOrEmpty(curso) && !String.IsNullOrEmpty(UF))
                {
                    var item = db.ProgramaPosGraduacao
                   .Select(x => new IndexViewModel { Instituicao = x.Instituicao, ProgramaPosGraduacao = x, UF = x.Instituicao.UF })
                   .Where(x => x.UF.Descricao == UF && x.ProgramaPosGraduacao.Descricao.Contains(curso))
                   .Distinct().OrderBy(x => x.ProgramaPosGraduacao.Descricao).ToList();

                    int skip = (200 * pagina) > item.Count ? 0 : 200 * pagina;
                    list = item.Select(x => new IndexViewModel { Instituicao = x.Instituicao, ProgramaPosGraduacao = x.ProgramaPosGraduacao, UF = x.Instituicao.UF, Count = item.Count() }).Skip(skip).Take(200).ToList();                    
                }

                else if (String.IsNullOrEmpty(curso) && String.IsNullOrEmpty(UF))
                {
                    var item = db.ProgramaPosGraduacao
                   .Select(x => new IndexViewModel { Instituicao = x.Instituicao, ProgramaPosGraduacao = x, UF = x.Instituicao.UF })
                   .Distinct().OrderBy(x => x.ProgramaPosGraduacao.Descricao).ToList();

                    int skip = (200 * pagina) > item.Count ? 0 : 200 * pagina;
                    list = item.Select(x => new IndexViewModel { Instituicao = x.Instituicao, ProgramaPosGraduacao = x.ProgramaPosGraduacao, UF = x.Instituicao.UF, Count = item.Count() }).Skip(skip).Take(200).ToList();
                }

                else if(String.IsNullOrEmpty(curso))
                {
                    var item = db.ProgramaPosGraduacao
                   .Select(x => new IndexViewModel { Instituicao = x.Instituicao, ProgramaPosGraduacao = x, UF = x.Instituicao.UF })
                   .Where(x => x.UF.Descricao == UF).Distinct().OrderBy(x => x.ProgramaPosGraduacao.Descricao).ToList();

                    int skip = (200 * pagina) > item.Count ? 0 : 200 * pagina;
                    list = item.Select(x => new IndexViewModel { Instituicao = x.Instituicao, ProgramaPosGraduacao = x.ProgramaPosGraduacao, UF = x.Instituicao.UF, Count = item.Count() }).Skip(skip).Take(200).ToList();
                }
                
                else if(String.IsNullOrEmpty(UF))
                {
                    var item = db.ProgramaPosGraduacao
                   .Select(x => new IndexViewModel { Instituicao = x.Instituicao, ProgramaPosGraduacao = x, UF = x.Instituicao.UF })
                   .Where(x => x.ProgramaPosGraduacao.Descricao.Contains(curso)).Distinct().OrderBy(x => x.ProgramaPosGraduacao.Descricao).ToList();

                    int skip = (200 * pagina) > item.Count ? 0 : 200 * pagina;
                    list = item.Select(x => new IndexViewModel { Instituicao = x.Instituicao, ProgramaPosGraduacao = x.ProgramaPosGraduacao, UF = x.Instituicao.UF, Count = item.Count() }).Skip(skip).Take(200).ToList();                    
                }
                
                return list;
            }
        }
    }
}
