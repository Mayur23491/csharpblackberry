﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS4BB.lang;
using System.IO;
using CS4BB.PreValidation;

namespace CS4BB
{
    class Generator
    {
        private SourceCode sourceCode;
        private bool displayProgress;
        private List<String> errors = new List<String>();
        private string directoryName;

        public Generator(SourceCode sourceCode)
        {
            this.sourceCode = sourceCode;
        }

        public Generator(SourceCode sourceCode, bool aDisplayProgress)
        {
            this.sourceCode = sourceCode;
            this.displayProgress = aDisplayProgress;
        }

        public Generator(string aDirectoryName, SourceCode aSourceCode, bool aDisplayProgress)
        {
            this.directoryName = aDirectoryName;
            this.sourceCode = aSourceCode;
            this.displayProgress = aDisplayProgress;
        }
        
        /// <summary>
        /// Start the compile process
        /// </summary>
        public void Run()
        {
            RunPreValidation();
            if (!HasErrors())
                RunCompile();
            else if (displayProgress)
                Console.WriteLine("Can't continue with compilation due to validation error.");
        }

        private void RunPreValidation()
        {
            if (displayProgress)
                Console.WriteLine("Start pre-validation... File: {0}", this.sourceCode.GetFileName());

            IValidate onlyOneClass = new OnlySingleClassPerFile();
            String result = onlyOneClass.DoValidation(this.sourceCode);
            if (result != null) errors.Add(result);
        }

        private void RunCompile()
        {
            if (displayProgress)
                Console.WriteLine("Start compiling... File: {0}", this.sourceCode.GetFileName());

            int pos = 1;
            foreach (String currentSourceCodeLine in this.sourceCode.GetLines())
            {
                CompileLineResult currentLineResult = new CompileLineResult(currentSourceCodeLine);

                ICommand usingDirective = new UsingDirectiveComp();
                if (usingDirective.Identify(this.sourceCode, currentSourceCodeLine, pos))
                    currentLineResult = usingDirective.Compile(this.sourceCode, currentSourceCodeLine, pos);

                if (!currentLineResult.Success)
                    this.errors.Add(currentLineResult.ErrorMessage);

                if (currentLineResult.IsValidCode())
                    WriteJavaLine(currentLineResult);
                pos++;
            }
        }

        /// <summary>
        /// Indicate if there are any compile errors
        /// </summary>
        /// <returns></returns>
        public bool HasErrors()
        {
            return this.errors != null && this.errors.Count > 0;
        }

        /// <summary>
        /// Return compile errors
        /// </summary>
        /// <returns></returns>
        public List<String> GetErrors()
        {
            return this.errors;
        }

        private void WriteJavaLine(CompileLineResult currentLineResult)
        {
            StreamWriter file = null;
            try
            {
                String javaFile = this.directoryName + @"/" + this.sourceCode.GetJavaDestinationFileName();
                file = new StreamWriter(javaFile, true);
                file.WriteLine(currentLineResult.GetCode());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }
    }
}
