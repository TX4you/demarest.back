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
    public class CursosAvaliacoesRepository : ICursosAvaliacoesRepository
    {
        private readonly IHelp _help;
        public CursosAvaliacoesRepository(IHelp help)
        {
            _help = help;
        }
        public void Adicionar(CursosAvaliacoes cursoAvaliacao)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO CursosAvaliacoes (
                                                         CursosId
                                                        ,AlunosId
                                                        ,Nota) 
                                                VALUES(
                                                         @CursosId
                                                        ,@AlunosId
                                                        ,@Nota);";
                    con.Execute(query, cursoAvaliacao);
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
        public IEnumerable<CursosAvaliacoes> Listar()
        {
            var connectionString = _help.GetConnection();
            List<CursosAvaliacoes> _cursoAvaliacao = new List<CursosAvaliacoes>();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"SELECT * FROM CursosAvaliacoes";
                    _cursoAvaliacao = con.Query<CursosAvaliacoes>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _cursoAvaliacao;
            }
        }
        public IEnumerable<CursosAvaliacoes> ObterPorAlunoId(int alunoId)
        {
            var connectionString = _help.GetConnection();
            List<CursosAvaliacoes> _cursoAvaliacao = new List<CursosAvaliacoes>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM CursosAvaliacoes WHERE AlunosId =" + alunoId;
                    
                    _cursoAvaliacao = con.Query<CursosAvaliacoes>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _cursoAvaliacao;
            }
        }

        public IEnumerable<CursosAvaliacoes>  ObterPorAlunoIdCursoId(int alunoId, int cursoId)
        {
             var connectionString = _help.GetConnection();
            List<CursosAvaliacoes> _cursoAvaliacao = new List<CursosAvaliacoes>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM CursosAvaliacoes WHERE AlunosId =" + alunoId + " and CursosId =" + cursoId;
                   _cursoAvaliacao = con.Query<CursosAvaliacoes>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _cursoAvaliacao;
            }
        }

        public IEnumerable<CursosAvaliacoes>  ObterPorCursoId(int cursoId)
        {
            var connectionString = _help.GetConnection();
            List<CursosAvaliacoes> _cursoAvaliacao = new List<CursosAvaliacoes>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM CursosAvaliacoes WHERE CursosId =" + cursoId;
                    _cursoAvaliacao = con.Query<CursosAvaliacoes>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _cursoAvaliacao;
            }
        }
    }
}