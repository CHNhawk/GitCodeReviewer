using System;

namespace Utils
{
    public class GitCommandType
    {
        public const string Clone = "clone";
        public const string Status = "status";
        public const string Diff = "diff";
        public const string Commit = "clone";
        public const string Log = "log";
        public const string Blame = "blame";
        public const string Remote = "remote";
        public const string Fetch = "fetch";
        public const string Pull = "pull";
        public const string Push = "push";
    }

    public class GitCommand: CommandRunner
    {
        public string Type { get; set; }

        public GitCommand(params Object[] param)
        {
            Command = "git";
            foreach (Object o in param) 
            {
                Command += $" {o}";
            }
        }

        public bool Excute()
        {
            return base.Excute();
        }

    }

    public class GitCommandFactory 
    {
        public GitCommand Create()
        {
            return new GitCommand();
        }

        public GitCommand GetCloneCommand(string url) 
        {
            return new GitCommand(GitCommandType.Clone, url);
        }
        
    }

    public class GitCommandUtils
    {


    }


}