using StyleCop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSFile;
using VSFile.Source;

namespace StyleCopTool.StyleCop
{
    public class StyleCopHelper
    {

        public static IList<CodeProject> CodeProjects;

        public int NextCodeProjectKey { get; private set; }
        public int NumberViolations { get; set; }
        private StyleCopConsole Analyzer { get; set; }
        public string CacheFilePath { get; set; }

        public StyleCopHelper() 
        {
            InitializeConsole();
            var cacheFileName = $"out_cache_{DateTime.Now.Ticks}";
            CacheFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}/{cacheFileName}";
        }

        public bool Test()
        {
            //Initialize();
            string InputFilePath = "D:/Xuanyu/projects/GitCodeReviewer/StyleCopTool/StyleCopTool/Program.cs";
            Run(InputFilePath);
            bool success = Analyzer.Start(CodeProjects, true);
            Analyzer.OutputGenerated -= OnOutputGenerated;
            Analyzer.ViolationEncountered -= OnViolationEncountered;
            return success;
        }

        public string[] GetAllSettings() 
        {
            return null;
        }

        private void Initialize()
        {
            if (Analyzer != null) 
            {
                return;
            }
            Analyzer = new StyleCopConsole(null, true, CacheFilePath, null, true);

            CodeProjects = new List<CodeProject>();

            NextCodeProjectKey = 0;
            NumberViolations = 0;

            Analyzer.OutputGenerated += OnOutputGenerated;
            Analyzer.ViolationEncountered += OnViolationEncountered;
        }


        public string Run(string file) 
        {

            bool RecursiveSearch = false;
            string[] filePaths = new string[] { file };
            VisualStudioFiles files = new VisualStudioFiles(filePaths, RecursiveSearch);

            foreach (CSharpSourceFile sourceFile in files.CSharpSourceFiles)
            {
                CodeProject codeProject = CreateCodeProject(sourceFile.DirectoryPath);
                AddSourceFile(sourceFile, codeProject);
                CodeProjects.Add(codeProject);
            }
            bool success = Analyzer.Start(CodeProjects, true);

            return null;
        }

        public string filter(LineGroup[] groups) 
        {
            foreach (var g in groups) 
            {
                
            }
            return "";
        }


        private CodeProject CreateCodeProject(string directoryPath)
        {
            return new CodeProject(NextCodeProjectKey, directoryPath, new Configuration(null));
        }

        private void AddSourceFile(CSharpSourceFile sourceFile, CodeProject codeProject)
        {
            sourceFile.Load();
            var a = Analyzer.Core.Environment.AddSourceCode(codeProject, sourceFile.FilePath, null);
        }

        private void OnOutputGenerated(object sender, OutputEventArgs e)
        {
            Console.WriteLine(e.Output);
        }

        private void OnViolationEncountered(object sender, ViolationEventArgs e)
        {
            NumberViolations++;
        }
    }
}
