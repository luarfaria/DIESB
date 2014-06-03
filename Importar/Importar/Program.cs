using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Entity;
using Microsoft.Office.Interop.Excel;

namespace Importar
{
    namespace ImportarProgramas
    {
        class Program
        {
            public class Tabela
            {
                public List<String> ProgramasList { get; set; }
                public String Instituicao { get; set; }
                public String InstituicaoComEstado { get; set; }
                public String UF { get; set; }
            }

            private static void ChangeExtension()
            {
                String diretorio = @"C:\Users\TI\Desktop\IES";
                var files = Directory.GetFiles(diretorio);

                foreach (var file in files)
                {
                    File.Move(file, Path.ChangeExtension(file, ".xls"));
                }
            }

            private static void InsereProgramas(IList<Tabela> tabelaList)
            {
                using (var context = new DIESBContext())
                {
                    foreach (var tabela in tabelaList)
                    {
                        var uf = context.UF.Where(x => x.Descricao == tabela.UF).FirstOrDefault();

                        if (uf == null)
                        {

                        }

                        else
                        {

                            Instituicao instituicao = context.Instituicao.Where(x => x.Descricao == tabela.Instituicao).FirstOrDefault();

                            if (instituicao == null)
                            {
                                instituicao = new Instituicao { Descricao = tabela.Instituicao, ID_UF = uf.ID };
                                context.Instituicao.AddObject(instituicao);
                                context.SaveChanges();
                            }

                            foreach (var programaStr in tabela.ProgramasList)
                            {
                                var programa = new ProgramaPosGraduacao
                                {
                                    Descricao = programaStr.ToUpper(),
                                    ID_Instituicao = instituicao.ID
                                };
                                context.ProgramaPosGraduacao.AddObject(programa);
                            }
                        }
                    }
                    context.SaveChanges();
                }

            }

            static void Main(string[] args)
            {
                String diretorio = @"C:\Users\TI\Desktop\IES";
                var files = Directory.GetFiles(diretorio);
                IList<Tabela> tabelaList = new List<Tabela>();

                foreach (var file in files)
                {
                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbook xlWorkbook = xlApp.Workbooks.Open(file);
                    _Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Range xlRange = xlWorksheet.UsedRange;
                    int nRows = xlRange.Rows.Count;
                    int nCols = xlRange.Columns.Count;
                    Tabela tabela = new Tabela();
                    xlRange = (Microsoft.Office.Interop.Excel.Range)xlWorksheet.Cells[1, 1];
                    String programaDescricao = xlRange.Text;
                    var arr = programaDescricao.Split('-');
                    tabela.Instituicao = programaDescricao;
                    tabela.UF = programaDescricao.Split('/').LastOrDefault().Replace(" ", String.Empty);
                    //tabela.InstituicaoComEstado = arr.LastOrDefault().Remove(0, 1) + " - " + arr.FirstOrDefault();
                    //int indexOfTraco = tabela.InstituicaoComEstado.IndexOf('-');
                    //tabela.InstituicaoComEstado = tabela.InstituicaoComEstado.Remove(indexOfTraco - 5, 5);
                    //tabela.Instituicao = tabela.Instituicao.Split('/').FirstOrDefault();


                    for (int iRow = 3; iRow <= nRows - 3; iRow++)
                    {
                        xlRange = (Microsoft.Office.Interop.Excel.Range)xlWorksheet.Cells[iRow, 1];
                        if (tabela.ProgramasList == null)
                        {
                            tabela.ProgramasList = new List<String>();
                        }
                        if (!String.IsNullOrEmpty(xlRange.Text) && !tabela.ProgramasList.Contains(xlRange.Text))
                            tabela.ProgramasList.Add(xlRange.Text);
                    }
                    if (tabela.ProgramasList.Any())
                        tabelaList.Add(tabela);
                    xlWorkbook.Close();
                }

                InsereProgramas(tabelaList);

            }
        }
    }
}
