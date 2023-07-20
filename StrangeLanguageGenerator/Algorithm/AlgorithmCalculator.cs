

using System;
using System.Windows;

public class AlgorithmCalculator : IAlgorithmCalculator
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
                            result = AddChars(inputData, result, i,wordlength); 
                            }
                        }
                        else
                        {
                            if (inputData[i] == result[i] && inputData[i + 1] == result[i + 1])
                            {
                            result = AddChars(inputData, result, i,wordlength);
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

        string AddChars(string inputData, string result, int i,short charsCount)
        {
            for (int j = 1; j <= charsCount; j++)
            {
                try
                {
                    result += inputData[(i + j)];
                }
                catch(IndexOutOfRangeException)
                {
                    result += inputData[^(i + j)];
                }
            }
            return result;
        }
    }
    }

