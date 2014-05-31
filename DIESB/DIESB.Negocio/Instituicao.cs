using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIESB.Negocio
{
    public partial class Instituicao
    {
        public static IList<String> GetUFS()
        {
            using (var db = new DIESBContext())
            {
                return db.Instituicao.Select(x => x.UF).Distinct().ToList();                
            }
        }
    }
}
