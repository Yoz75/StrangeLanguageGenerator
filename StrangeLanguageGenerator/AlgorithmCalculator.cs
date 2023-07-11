

using System;
using System.Threading.Tasks;

namespace StrangeLanguageGenerator
{
    public class AlgorithmCalculator
        //Привет
    {
        /// <summary>
        /// Calculating algorithm
        /// </summary>
        /// <param name="inputData">Text to calculate</param>
        /// <param name="seed">Algorithm seed, use null if you want to leave random</param>
        /// <returns></returns>
        public string Calculate(string inputData, bool isReversedIndex, short wordlength = 2)
        {
            Random rand = new Random();
            string result = string.Empty;

            var index = rand.Next(0, (inputData.Length - 1));
            result += inputData[index].ToString();
            result += inputData[index + 1].ToString();

            for (int i = 0; i < inputData.Length - 1; i++)
            {
                if (i != index)
                {
                    try
                    {
                        if (isReversedIndex)
                        {

                            if (inputData[^i] == result[^i] && inputData[^(i + 1)] == result[^(i + 1)])
                            {
                                result += inputData[i + 1];
                                result += inputData[i + 2];

                            }
                        }
                        else
                        {
                            if (inputData[i] == result[i] && inputData[i + 1] == result[i + 1])
                            {
                                result += inputData[i + 1];
                                result += inputData[i + 2];

                            }
                        }

                    }
                    catch (IndexOutOfRangeException)
                    {
                        return result;
                    }
                }

            }

            return result;
        }
    }
}
