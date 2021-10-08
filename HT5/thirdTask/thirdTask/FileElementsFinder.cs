using System;
using System.Collections.Generic;
using System.Text;

namespace thirdTask
{
    static class FileElementsFinder
    {
        public static string GetFileName(string filePath) //This method does not need extra memory, so I find it the best
        {
            int dotPosition = 0;
            int fileNameStartindex = 0;

            for (int i = filePath.Length - 1; i > 0; i--) 
            {
                if (filePath[i] == '.')
                {
                    dotPosition = i;
                }
                else if (filePath[i]== '\\')
                {
                    fileNameStartindex = i;
                    break;
                }
            }

            return filePath.Substring(fileNameStartindex + 1, dotPosition - fileNameStartindex - 1);
        }


        public static string GetFileNameWithSplit(string filePath) //Get file name with split function
        {
            string[] inputElements = filePath.Split(@"\", StringSplitOptions.RemoveEmptyEntries);

            return inputElements[inputElements.Length - 1].Split('.')[0];
        }


        public static string GetRootName(string filePath) //This method does not need extra memory, so I find it the best
        {
            int dostPosition = 0;
            int slashPosition = 0;

            for (int i = 0; i < filePath.Length; i++)
            {
                if (filePath[i] == ':')
                {
                    dostPosition = i;
                }

                else if (filePath[i] == '\\' && i > dostPosition + 1) 
                {
                    slashPosition = i;
                    break;
                }
            }

            return filePath.Substring(dostPosition + 2, slashPosition - dostPosition - 2);
        }

        public static string GetRootNameWithSplit(string filePath) //Use of split function
        {
            string[] inputElements = filePath.Split(@"\", StringSplitOptions.RemoveEmptyEntries);

            return inputElements[1].Substring(0, inputElements[1].Length);
        }

    }
}
