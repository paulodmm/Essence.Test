using Essence.Test.Domain.DTO;
using Essence.Test.RepositoryCore;
using Essence.Test.RepositoryCore.DAL;
using Essence.Test.RepositoryCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Test.Base.BUS
{
    public class AmigoBUS
    {
        AmigoDAL dal;

        public AmigoBUS()
        {
            dal = new AmigoDAL();
        }

        /// <summary>
        /// Adiciona um novo amigo
        /// </summary>
        /// <param name="dto"></param>
        public void Add(AmigoDTO dto)
        {
            Amigo model = Converter(dto);

            if (!dal.Confirmar(dto.Latitude, dto.Longitude))
                dal.Add(model);
            else
                throw new Exception("Ja existe um amigo nesta localidade");
        }

        /// <summary>
        /// Lista todos
        /// </summary>
        /// <returns></returns>
        public List<AmigoDTO> GetAll()
        {
            var amigos = dal.GetAll();

            List<AmigoDTO> retorno = new List<AmigoDTO>();

            foreach (var item in amigos)
                retorno.Add(Converter(item));

            return retorno;
        }

        /// <summary>
        /// lista todos amigos proximos
        /// </summary>
        /// <param name="amigoId"></param>
        /// <returns></returns>
        public List<AmigoDTO> AmigosProximos(int amigoId)
        {
            var amigos=dal.AmigosProximos(amigoId);

            List<AmigoDTO> retorno = new List<AmigoDTO>();

            foreach (var item in amigos)
                retorno.Add(Converter(item));

            return retorno;
        }

        /// <summary>
        /// preferi o mapeamento manual para este teste
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Amigo Converter(AmigoDTO dto)
        {
            Amigo retorno = new Amigo();

            retorno.AmigoId = dto.AmigoId;
            retorno.Latitude = dto.Latitude;
            retorno.Longitude = dto.Longitude;
            retorno.Nome = dto.Nome;

            return retorno;
        }

        /// <summary>
        /// preferi o mapeamento manual para este teste
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AmigoDTO Converter(Amigo model)
        {
            AmigoDTO retorno = new AmigoDTO();

            retorno.AmigoId = model.AmigoId;
            retorno.Latitude = model.Latitude;
            retorno.Longitude = model.Longitude;
            retorno.Nome = model.Nome;

            return retorno;
        }
    }
}
