﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CS4BB
{
    public class SourceCode
    {
        private FileInfo sourceFile;
        private List<String> sourceCode = new List<String>();
        private string[] arguments;

        public SourceCode(FileInfo aSourceFile, string[] aArguments)
        {
            this.sourceFile = aSourceFile;
            this.arguments = aArguments;
            ReadSourceCode();
        }

        /// <summary>
        /// Indicate if the file does contain source code
        /// </summary>
        /// <returns></returns>
        public bool DoesHaveCode()
        {
            return this.sourceCode != null && this.sourceCode.Count > 0;
        }

        /// <summary>
        /// Get the java destination file name
        /// </summary>
        /// <returns></returns>
        public string GetJavaDestinationFileName()
        {
            return this.sourceFile.Name.Replace(".cs", ".java");
        }

        /// <summary>
        /// Get the java destination file name full name
        /// </summary>
        /// <returns></returns>
        public string GetJavaDestinationFullName()
        {
            return this.sourceFile.FullName.Replace(".cs", ".java");
        }

        /// <summary>
        /// Get the source file name
        /// </summary>
        /// <returns></returns>
        public String GetFileName()
        {
            return this.sourceFile.Name;
        }

        /// <summary>
        /// Return all the source code lines
        /// </summary>
        /// <returns></returns>
        public List<String> GetLines()
        {
            return this.sourceCode;
        }

        /// <summary>
        /// Return the next item in the source code line
        /// </summary>
        /// <param name="aLinePosition"></param>
        /// <returns></returns>
        public String GetNextLine(int aLinePosition)
        {
            //int nextLinePos = aLinePosition;
            //nextLinePos++;
            return GetCode(this.sourceCode.ElementAtOrDefault<String>(aLinePosition));
        }

        private void ReadSourceCode()
        {
            StreamReader file = null;
            try
            {
                file = new StreamReader(sourceFile.FullName);
                String line = null;
                while ((line = file.ReadLine()) != null)
                    if (ContainCode(line))
                        sourceCode.Add(GetCode(line));
                    else
                        sourceCode.Add(" ");
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }

        private string GetCode(String aCodeLine)
        {
            return ContainCode(aCodeLine) ? aCodeLine.Trim() : "";
        }

        private bool ContainCode(string aCodeLine)
        {
            return aCodeLine != null && aCodeLine.Length > 0;
        }

        /// <summary>
        /// Get the previous code line that isn't the same as the current code line
        /// </summary>
        /// <param name="aCodeLine"></param>
        /// <param name="aLinePosition"></param>
        /// <returns></returns>
        public String GetPreviousLine(String aCodeLine, int aLinePosition)
        {
            String result = "";
            String currentCode = "";

            int prevLinePos = aLinePosition;
            while (currentCode.CompareTo(aCodeLine) == 0 || !ContainCode(currentCode))
            {
                prevLinePos--;
                currentCode = GetCode(this.sourceCode.ElementAtOrDefault<String>(prevLinePos));
            }

            result = currentCode;
            return result;
        }

        /// <summary>
        /// Indicate if program contain a given argument
        /// </summary>
        /// <param name="aSeachArgument"></param>
        /// <returns></returns>
        public bool ContainProgramArgument(string aSeachArgument)
        {
            var found = (from f in arguments
                         where f.Trim().CompareTo(aSeachArgument) == 0
                         select f).FirstOrDefault();
            
            return found != null;
        }

        /// <summary>
        /// Indicate if there are more code
        /// </summary>
        /// <param name="aLinePosition"></param>
        /// <returns></returns>
        public bool IsThereMoreCode(int aLinePosition)
        {
            bool result = false;

            for (int i = aLinePosition; i < this.sourceCode.ToArray().Length; i++)
            {
                if (ContainCode(this.sourceCode.ToArray()[i].Trim()))
                    result = true;
            }

            return result;
        }

        /// <summary>
        /// Count how many times a token is found in a string
        /// </summary>
        /// <param name="aCurrentCodeLine"></param>
        /// <param name="aSearchChar"></param>
        /// <returns></returns>
        public int CountTokens(string aCurrentCodeLine, char aSearchChar)
        {
            int result = 0;
            char[] ch = aCurrentCodeLine.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i].CompareTo(aSearchChar) == 0)
                result++;
            }
            return result;
        }
    }
}