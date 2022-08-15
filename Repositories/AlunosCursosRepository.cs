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
    public class AlunosCursosRepository : IAlunosCursosRepository
    {
        private readonly IHelp _help;
        public AlunosCursosRepository(IHelp help)
        {
            _help = help;
        }
        public void Adicionar(AlunosCursos alunoCursos)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO AlunosCursos (
                                                         AlunosId
                                                        ,CursosId) 
                                                VALUES(
                                                         @AlunosId
                                                        ,@CursosId);";
                    con.Execute(query, alunoCursos);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public AlunosCursos ObterPorAlunoIdCursoId(int alunoId, int cursoId)
        {
             var connectionString = _help.GetConnection();
            AlunosCursos _alunoCurso = new AlunosCursos();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM AlunosCursos WHERE AlunosId =" + alunoId + " and CursosId =" + cursoId;
                    _alunoCurso = con.Query<AlunosCursos>(query).FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _alunoCurso;
            }
        }

        public AlunosCursos ObterPorId(int id)
        {
             var connectionString = _help.GetConnection();
            AlunosCursos _alunoCurso = new AlunosCursos();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM AlunosCursos WHERE Id =" + id;
                    _alunoCurso = con.Query<AlunosCursos>(query).FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _alunoCurso;
            }
        }
    }
}