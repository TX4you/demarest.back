using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using dema.back.Repositories.Interface;
using dema.back.Repositories.Models;
using MySql.Data.MySqlClient;

namespace dema.back.Repositories
{
    public class ResultadoRepository : IResultadoRepository
    {
        private readonly IHelp _help;
        public ResultadoRepository(IHelp help)
        {
            _help = help;
        }

        public IEnumerable<Resultado> ObterPorAlunoId(int alunoId)
        {
            var connectionString = _help.GetConnection();
            List<Resultado> _resultado = new List<Resultado>();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"
                                SELECT 
                                    Alunos.Nome AS Aluno,
                                    Cursos.Descricao AS Curso,
                                    Cursos.Avaliacoes,
                                    Cursos.FrequenciaMinima,
                                    Cursos.QuantidadeAulas,
                                    COUNT(distinct AlunosFaltas.Id) AS faltas,
                                    AVG(CursosAvaliacoes.Nota) AS Media,
                                    COUNT(distinct CursosAvaliacoes.Id) AS CursosAvaliacoes
                                from Alunos
                                INNER JOIN AlunosCursos ON Alunos.Id = AlunosCursos.AlunosId
                                INNER JOIN Cursos ON AlunosCursos.CursosId = Cursos.Id
                                LEFT JOIN AlunosFaltas ON AlunosCursos.AlunosId = AlunosFaltas.AlunosId AND AlunosCursos.CursosId = AlunosFaltas.CursosId
                                LEFT JOIN CursosAvaliacoes ON AlunosCursos.AlunosId = CursosAvaliacoes.AlunosId AND AlunosCursos.CursosId = CursosAvaliacoes.CursosId
                                WHERE Alunos.Id =" + alunoId + " GROUP BY Alunos.Nome, Cursos.Descricao, Cursos.Avaliacoes, Cursos.FrequenciaMinima, Cursos.QuantidadeAulas";

                    _resultado = con.Query<Resultado>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _resultado;
            }
        }

    }
}