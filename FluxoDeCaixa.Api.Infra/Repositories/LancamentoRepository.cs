using FluxoDeCaixa.Api.Domain.DataObjects;
using FluxoDeCaixa.Api.Domain.Domain;
using FluxoDeCaixa.Api.Infra.Context;
using FluxoDeCaixa.Api.Infra.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Infra.Repositories;

public class LancamentoRepository : ILancamentoRepository
{
    readonly DataContext _context;

    public LancamentoRepository(DataContext context)
	{
		_context = context;
	}

    public async Task<ResultViewModel> GetAllLancamentos()
    {
        var ListaLancamentos = new List<LancamentoModel>();
        try
        {
            var selectQuery = new StringBuilder();
            selectQuery.Append("SELECT * FROM lancamentos order by id desc");

            var connectionString = _context.Database.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(selectQuery.ToString(), conn))
                {
                    cmd.CommandTimeout = 30;

                    var reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        LancamentoModel lancamento = new LancamentoModel();
                        lancamento.ID = reader[0].Equals(DBNull.Value) ? 0 : (int)(reader[0]);
                        lancamento.Descricao = reader[1].Equals(DBNull.Value) ? "" : (string)(reader[1]);
                        lancamento.valor = reader[2].Equals(DBNull.Value) ? 0 : (decimal)(reader[2]);
                        lancamento.Tipo = reader[3].Equals(DBNull.Value) ? 0 : (int)(reader[3]);
                        lancamento.Data = reader[4].Equals(DBNull.Value) ? DateTime.Today : (DateTime)(reader[4]);
                        lancamento.Consolidado = reader[5].Equals(DBNull.Value) ? 0 : (int)(reader[5]);
                        ListaLancamentos.Add(lancamento);
                    }
                }

                conn.Close();

                var result = new ResultViewModel()
                {
                    Data = ListaLancamentos,
                    Message = "Carregamento concluído",
                    Success = true
                };

                return result;

            }
        }
        catch (Exception ex)
        {
            var result = new ResultViewModel()
            {
                Data = ex.Message,
                Message = "Ocorreu um erro na consulta",
                Success = false
            };

            return result;
        }
    }

    public async Task<List<LancamentoModel>> GetLancamentoByData(DateTime startTime, DateTime endTime)
    {
        var ListaLancamentos = new List<LancamentoModel>();
        try
        {
            var selectQuery = new StringBuilder();
            selectQuery.Append("SELECT * FROM lancamentos where data >= @startTime and data <= @endTime order by id desc");

            var connectionString = _context.Database.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(selectQuery.ToString(), conn))
                {
                    cmd.CommandTimeout = 30;

                    // Adiciona os parâmetros para evitar injeção de SQL
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@endTime", endTime);

                    var reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        LancamentoModel lancamento = new LancamentoModel();
                        lancamento.ID = reader[0].Equals(DBNull.Value) ? 0 : (int)(reader[0]);
                        lancamento.Descricao = reader[1].Equals(DBNull.Value) ? "" : (string)(reader[1]);
                        lancamento.valor = reader[2].Equals(DBNull.Value) ? 0 : (decimal)(reader[2]);
                        lancamento.Tipo = reader[3].Equals(DBNull.Value) ? 0 : (int)(reader[3]);
                        lancamento.Data = reader[4].Equals(DBNull.Value) ? DateTime.Today : (DateTime)(reader[4]);
                        lancamento.Consolidado = reader[5].Equals(DBNull.Value) ? 0 : (int)(reader[5]);
                        ListaLancamentos.Add(lancamento);
                    }
                }

                conn.Close();
                return ListaLancamentos;

            }
        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public async Task<ResultViewModel> InsereLancamento(LancamentoDTO lancamentoDTO)
    {
		try
		{
			var selectQuery = new StringBuilder();
            selectQuery.Append("INSERT INTO lancamentos ( descricao, valor, tipo, data, consolidado ) VALUES ( @descricao , @valor , @tipo , @data , @consolidado )");
			
            var connectionString = _context.Database.GetConnectionString();

			using (var conn = new SqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new SqlCommand(selectQuery.ToString(), conn))
				{
					// Adiciona os parâmetros para evitar injeção de SQL
					cmd.Parameters.AddWithValue("@descricao", lancamentoDTO.Descricao);
                    cmd.Parameters.AddWithValue("@valor", lancamentoDTO.valor);
                    cmd.Parameters.AddWithValue("@tipo", lancamentoDTO.Tipo);
                    cmd.Parameters.AddWithValue("@data", lancamentoDTO.Data);
                    cmd.Parameters.AddWithValue("@consolidado", lancamentoDTO.Consolidado);

					cmd.ExecuteNonQuery();
                }

				conn.Close();

				var result =  new ResultViewModel()
				{
					Data = "",
					Message = "Lançamento registrado com sucesso!",
					Success = true
				};

				return result;

            }
        }
		catch (Exception ex)
		{
            var result = new ResultViewModel()
            {
                Data = ex.Message,
                Message = "Ocorreu um erro na execução da query de inserção de lançamento",
                Success = false
            };

            return result;
        }
    }
}
