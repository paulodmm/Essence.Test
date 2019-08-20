using Essence.Test.RepositoryCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Essence.Test.RepositoryCore.DAL
{
    /// <summary>
    /// classe de banco de dados
    /// não vou me preocupar com performance ou heranças de classes bases
    /// apenas no funcionamento dos métodos, porem existem formas melhores de instância
    /// e objetos nesta classes de banco
    /// </summary>
    public class AmigoDAL : DALBase, IDisposable
    {
        public AmigoDAL() : base()
        {
        }

        /// <summary>
        /// adiciona
        /// </summary>
        /// <param name="model"></param>
        public void Add(Amigo model)
        {
            contexto.Entry<Amigo>(model).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            contexto.SaveChanges();
        }

        /// <summary>
        /// confirma se ja estão na mesma localidade
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="logitude"></param>
        /// <returns></returns>
        public bool Confirmar(double latitude, double logitude)
        {
            return contexto.Amigos.Any(l => l.Latitude == latitude && l.Longitude == logitude);
        }

        /// <summary>
        /// retorna todos amigos cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Amigo> GetAll()
        {
            return contexto.Amigos.ToList();
        }

        public List<Amigo> AmigosProximos(int amigoId)
        {
            List<Amigo> retorno = new List<Amigo>();

            using (var command = contexto.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "stBuscarProximos";
                command.CommandType = CommandType.StoredProcedure;

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@AmigoId";
                parameter.Value = amigoId;

                command.Parameters.Add(parameter);

                contexto.Database.OpenConnection();

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Amigo addItem = new Amigo();

                    addItem.AmigoId = dataReader.GetInt32(dataReader.GetOrdinal("AmigoId"));
                    addItem.Distancia = dataReader.GetDouble(dataReader.GetOrdinal("Distancia"));
                    addItem.Latitude = dataReader.GetDouble(dataReader.GetOrdinal("Latitude"));
                    addItem.Longitude = dataReader.GetDouble(dataReader.GetOrdinal("Longitude"));
                    addItem.Nome = dataReader.GetString(dataReader.GetOrdinal("Nome"));

                    retorno.Add(addItem);
                }
            }

            return retorno;
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
