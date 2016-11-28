using System;
using Sitecore.Services.Core.Model;

namespace CustomService.Model
{
    public class Todo : EntityIdentity
    {
        private static int _lastId = 1;

        public Todo()
        {
            _lastId++;

            Id = _lastId.ToString();


        }

        public string Title { get; set; }

        public bool Completed { get; set; }

        public int Index { get; set; }
    }
}