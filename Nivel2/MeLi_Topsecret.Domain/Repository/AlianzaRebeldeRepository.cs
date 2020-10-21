using System;
using System.Collections.Generic;
using System.Linq;
using MeLi_Topsecret.Domain.CommandModel;

namespace MeLi_Topsecret.Domain.Repository
{
    public class AlianzaRebeldeRepository
    {
        const double X1 = Constants.KENOBI_X;
        const double Y1 = Constants.KENOBI_Y;

        const double X2 = Constants.SKYWALKER_X;
        const double Y2 = Constants.SKYWALKER_Y;

        const double X3 = Constants.SATO_X;
        const double Y3 = Constants.SATO_Y;

        public virtual double CalculateX(double d1, double d2, double d3)
        {
            var partial1 = ((Math.Pow(Y2, 2) - Math.Pow(Y1, 2)) + (Math.Pow(X2, 2) - Math.Pow(X1, 2)) +
                           (Math.Pow(d1, 2) - Math.Pow(d2, 2))) * (Y2 - Y3);

            var partial2 = (Math.Pow(Y3, 2) - Math.Pow(Y2, 2)) + (Math.Pow(X3, 2) - Math.Pow(X2, 2)) +
                           (Math.Pow(d2, 2) - Math.Pow(d3, 2)) * (Y1 - Y2);

            var partial3 = ((X1 - X2) * (Y2 - Y3)) - ((X2 - X3) * (Y1 - Y2));

            var final = (partial1 - partial2) / (partial3 * 2);

            return final;
        }

        public virtual double CalculateY(double d1, double d2, double d3)
        {
            var partial1 = ((Math.Pow(X2, 2) - Math.Pow(X1, 2)) + (Math.Pow(Y2, 2) - Math.Pow(Y1, 2)) +
                            (Math.Pow(d1, 2) - Math.Pow(d2, 2))) * (X2 - X3);

            var partial2 = (Math.Pow(X3, 2) - Math.Pow(X2, 2)) + (Math.Pow(Y3, 2) - Math.Pow(Y2, 2)) +
                           (Math.Pow(d2, 2) - Math.Pow(d3, 2)) * (X1 - X2);

            var partial3 = ((Y1 - Y2) * (X2 - X3)) - ((Y2 - Y3) * (X1 - X2));

            var final = (partial1 - partial2) / (partial3 * 2);

            return final;
        }

        public virtual string CreateMessage(SatelliteMessage[] satelliteMessages)
        {

            int cont = satelliteMessages.Max(s => s.Message.Count);
            string[] message = new string[cont];

            foreach (var satelliteMessage in satelliteMessages)
            {
                int index = 0;
                foreach (var word in satelliteMessage.Message)
                {
                    if (!string.IsNullOrEmpty(message[index]))
                    {
                        if (!string.IsNullOrEmpty(word) && message[index] != word)
                        {
                            //2 palabras distintas en la misma posicion, sale del loop y retorna string vacio
                            return string.Empty;
                        }
                        index += 1;
                        continue;
                    }

                    message[index] = word;
                    index += 1;
                }
            }

            if (message.Any(word => string.IsNullOrEmpty(word)))
            {
                return string.Empty;
            }

            return string.Join(" ", message);
        }
    }
}
