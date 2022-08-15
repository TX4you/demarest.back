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
    public class CriteriosRepository : ICriteriosRepository
    {
        private readonly IHelp _help;
        public CriteriosRepository(IHelp help)
        {
            _help = help;
        }
        public void Adicionar(Criterios criterio)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Criterios (
                                                         Descricao
                                                        ,ValorMinimo
                                                        ,ValorMaximo) 
                                                VALUES(
                                                         @Descricao
                                                        ,@ValorMinimo
                                                        ,@ValorMaximo);";
                    con.Execute(query, criterio);
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

        public void Alterar(Criterios criterio)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Criterios SET Descricao = @Descricao, ValorMinimo = @ValorMinimo ,ValorMaximo = @ValorMaximo  WHERE Id = " + criterio.Id;
                    con.Execute(query, criterio);
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

        public IEnumerable<Criterios> Listar()
        {
            var connectionString = _help.GetConnection();
            List<Criterios> _alunos = new List<Criterios>();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"SELECT * FROM Criterios ORDER By Descricao";
                    _alunos = con.Query<Criterios>(query).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _alunos;
            }
        }

        public Criterios ObterPorId(int id)
        {
            var connectionString = _help.GetConnection();
            Criterios _criterio = new Criterios();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Criterios WHERE Id =" + id;
                    _criterio = con.Query<Criterios>(query).FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _criterio;
            }

        }

        public void Remover(Criterios criterio)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"Delete from Criterios  
                                    WHERE Id = " + criterio.Id;
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