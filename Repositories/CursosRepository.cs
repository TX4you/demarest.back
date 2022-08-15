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
    public class CursosRepository : ICursosRepository
    {
        private readonly IHelp _help;
        public CursosRepository(IHelp help)
        {
            _help = help;
        }
        public void Adicionar(Cursos curso)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Cursos (
                                                         Descricao
                                                        ,Exclusivo
                                                        ,Avaliacoes
                                                        ,FrequenciaMinima
                                                        ,QuantidadeAulas) 
                                                VALUES(
                                                         @Descricao
                                                        ,@Exclusivo
                                                        ,@Avaliacoes
                                                        ,@FrequenciaMinima
                                                        ,@QuantidadeAulas);";
                    con.Execute(query, curso);
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

        public void Alterar(Cursos curso)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Cursos SET Descricao = @Descricao, Exclusivo = @Exclusivo ,Avaliacoes = @Avaliacoes,FrequenciaMinima = @FrequenciaMinima, QuantidadeAulas = @QuantidadeAulas  WHERE Id = " + curso.Id;
                    con.Execute(query, curso);
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

        public IEnumerable<Cursos> Listar()
        {
            var connectionString = _help.GetConnection();
            List<Cursos> _cursos = new List<Cursos>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"SELECT * FROM Cursos
                                  ORDER By Descricao";
                    _cursos = con.Query<Cursos>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _cursos;
            }
        }

        public IEnumerable<Cursos> ObterPorAlunoId(int alunoId)
        {
             var connectionString = _help.GetConnection();
            List<Cursos> _cursos = new List<Cursos>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"SELECT Cursos.* from Cursos
                                    INNER JOIN AlunosCursos ON Cursos.Id = AlunosCursos.CursosId
                                    WHERE AlunosCursos.AlunosId =" + alunoId +
                                  " ORDER By Descricao";
                    _cursos = con.Query<Cursos>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _cursos;
            }
        }

        public Cursos ObterPorId(int id)
        {
            var connectionString = _help.GetConnection();
            Cursos _curso = new Cursos();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Cursos WHERE Id =" + id;
                    _curso = con.Query<Cursos>(query).FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _curso;
            }
        }

        public void Remover(Cursos curso)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"Delete from Cursos  
                                    WHERE Id = " + curso.Id;
                    con.Execute(query);
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
    }
}