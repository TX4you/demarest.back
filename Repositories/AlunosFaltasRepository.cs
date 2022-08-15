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
    public class AlunosFaltasRepository : IAlunosFaltasRepository
    {
        private readonly IHelp _help;
        public AlunosFaltasRepository(IHelp help)
        {
            _help = help;
        }
        public void Adicionar(AlunosFaltas alunoFalta)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO AlunosFaltas (
                                                         AlunosId
                                                        ,CursosId) 
                                                VALUES(
                                                         @AlunosId
                                                        ,@CursosId);";
                    con.Execute(query, alunoFalta);
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

        public IEnumerable<AlunosFaltas> Listar()
        {
            var connectionString = _help.GetConnection();
            List<AlunosFaltas> _alunofalta = new List<AlunosFaltas>();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"SELECT * FROM AlunosFaltas";
                    _alunofalta = con.Query<AlunosFaltas>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _alunofalta;
            }
        }

        public IEnumerable<AlunosFaltas> ObterPorAlunoIdCursoId(int alunoId, int cursoId)
        {
             var connectionString = _help.GetConnection();
            List<AlunosFaltas> _alunofalta = new List<AlunosFaltas>();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM AlunosFaltas WHERE  AlunosId =" + alunoId +" and CursosId =" + cursoId;
                    _alunofalta = con.Query<AlunosFaltas>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _alunofalta;
            }
        }

        public IEnumerable<AlunosFaltas> ObterPorCursoId(int cursoId)
        {
           var connectionString = _help.GetConnection();
            List<AlunosFaltas> _alunofalta = new List<AlunosFaltas>();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM AlunosFaltas WHERE CursosId =" + cursoId;
                    _alunofalta = con.Query<AlunosFaltas>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _alunofalta;
            }
        }

        public IEnumerable<AlunosFaltas> ObterPorAlunoId(int alunoId)
        {
            var connectionString = _help.GetConnection();
            List<AlunosFaltas> _alunofalta = new List<AlunosFaltas>();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM AlunosFaltas WHERE AlunosId =" + alunoId;
                    _alunofalta = con.Query<AlunosFaltas>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _alunofalta;
            }
        }

    }
}