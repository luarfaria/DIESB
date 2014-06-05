using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIESB.Negocio
{
    public class IndexViewModel
    {
        public ProgramaPosGraduacao ProgramaPosGraduacao { get; set; }
        public Instituicao Instituicao { get; set; }
        public UF UF { get; set; }
        public int Count { get; set; }
    }
}
