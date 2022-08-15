using System;
using System.Collections.Generic;
using Dapper;
using dema.back.Repositories.Interface;
using dema.back.Repositories.Models;
using MySql.Data.MySqlClient;
using System.Linq;

namespace dema.back.Repositories
{
    public class AlunosRepository : IAlunosRepository
    {
        private readonly IHelp _help;
        public AlunosRepository(IHelp help)
        {
            _help = help;
        }
        public void Adicionar(Alunos aluno)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Alunos (
                                                         Nome
                                                        ,SobreNome
                                                        ,Cpf
                                                        ,Sexo) 
                                                VALUES(
                                                         @Nome
                                                        ,@SobreNome
                                                        ,@Cpf
                                                        ,@Sexo);";
                    con.Execute(query, aluno);
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

        public void Alterar(Alunos aluno)
        {
            var connectionString = _help.GetConnection();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Alunos SET Nome = @Nome, SobreNome = @SobreNome ,Cpf = @Cpf,Sexo = @Sexo  WHERE Id = " + aluno.Id;
                    con.Execute(query, aluno);
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

        public IEnumerable<Alunos> Listar()
        {
            var connectionString = _help.GetConnection();
            List<Alunos> _alunos = new List<Alunos>();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"SELECT * FROM Alunos
                                  ORDER By Nome";
                    _alunos = con.Query<Alunos>(query).ToList();
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

        public Alunos ObterPorId(int id)
        {
            var connectionString = _help.GetConnection();
            Alunos _aluno = new Alunos();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Alunos WHERE Id =" + id;
                    _aluno = con.Query<Alunos>(query).FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return _aluno;
            }
        }

        public void Remover(Alunos aluno)
        {
            var connectionString = _help.GetConnection();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"Delete from Alunos  
                                    WHERE Id = " + aluno.Id;
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