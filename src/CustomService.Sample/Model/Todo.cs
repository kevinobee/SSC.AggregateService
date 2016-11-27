using Sitecore.Services.Core.Model;

namespace CustomService.Model
{
    public class Todo : EntityIdentity
    {
        public string Title { get; set; }

        public bool Completed { get; set; }

        public int Index { get; set; }
    }
}