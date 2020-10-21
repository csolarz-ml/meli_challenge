using System;
using MeLi_Topsecret_split.Domain.Entities;
using MeLi_Topsecret_split.Domain.Repository;
using MeLi_Topsecret_split.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using SchipService.Persistence.Sql;
using SchipService.Persistence.Sql.Repositories;

namespace MeLi_Topsecret_split.Persistence.Repository
{
    public class SqlAlianzaRebeldeRepository : SqlRepositoryBase, IAlianzaRebeldeRepository
    {
        public SqlAlianzaRebeldeRepository(SqlUnitOfWork uow) : base(uow) { }

        public double CalculateX(double d1, double d2, double d3)
        {
            var x1 = Constants.KENOBI_X;
            var y1 = Constants.KENOBI_Y;

            var x2 = Constants.SKYWALKER_X;
            var y2 = Constants.SKYWALKER_Y;

            var x3 = Constants.SATO_X;
            var y3 = Constants.SATO_Y;

            var partial1 = ((Math.Pow(y2, 2) - Math.Pow(y1, 2)) + (Math.Pow(x2, 2) - Math.Pow(x1, 2)) +
                           (Math.Pow(d1, 2) - Math.Pow(d2, 2))) * (y2 - y3);

            var partial2 = (Math.Pow(y3, 2) - Math.Pow(y2, 2)) + (Math.Pow(x3, 2) - Math.Pow(x2, 2)) +
                           (Math.Pow(d2, 2) - Math.Pow(d3, 2)) * (y1 - y2);

            var partial3 = ((x1 - x2) * (y2 - y3)) - ((x2 - x3) * (y1 - y2));

            var final = (partial1 - partial2) / (partial3 * 2);

            return final;
        }

        public double CalculateY(double d1, double d2, double d3)
        {
            var x1 = Constants.KENOBI_X;
            var y1 = Constants.KENOBI_Y;

            var x2 = Constants.SKYWALKER_X;
            var y2 = Constants.SKYWALKER_Y;

            var x3 = Constants.SATO_X;
            var y3 = Constants.SATO_Y;

            var partial1 = ((Math.Pow(x2, 2) - Math.Pow(x1, 2)) + (Math.Pow(y2, 2) - Math.Pow(y1, 2)) +
                            (Math.Pow(d1, 2) - Math.Pow(d2, 2))) * (x2 - x3);

            var partial2 = (Math.Pow(x3, 2) - Math.Pow(x2, 2)) + (Math.Pow(y3, 2) - Math.Pow(y2, 2)) +
                           (Math.Pow(d2, 2) - Math.Pow(d3, 2)) * (x1 - x2);

            var partial3 = ((y1 - y2) * (x2 - x3)) - ((y2 - y3) * (x1 - x2));

            var final = (partial1 - partial2) / (partial3 * 2);

            return final;
        }

        //public string CreateMessage(SatelliteMessage[] satelliteMessages)
        //{

        //    int cont = satelliteMessages.Max(s => s.Message.Count);
        //    string[] message = new string[cont];

        //    foreach (var satelliteMessage in satelliteMessages)
        //    {
        //        int index = 0;
        //        foreach (var word in satelliteMessage.Message)
        //        {
        //            if (!string.IsNullOrEmpty(message[index]))
        //            {
        //                if (!string.IsNullOrEmpty(word) && message[index] != word)
        //                {
        //                    //2 palabras distintas en la misma posicion, sale del loop y retorna string vacio
        //                    return string.Empty;
        //                }
        //                index += 1;
        //                continue;
        //            }

        //            message[index] = word;
        //            index += 1;
        //        }
        //    }

        //    if (message.Any(word => string.IsNullOrEmpty(word)))
        //    {
        //        return string.Empty;
        //    }

        //    return string.Join(" ", message);
        //}


        public void Save(Satellites satellite)
        {
            throw new NotImplementedException();
        }
    }
}
