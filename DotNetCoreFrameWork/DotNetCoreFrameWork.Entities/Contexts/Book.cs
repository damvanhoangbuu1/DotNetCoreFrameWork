using System;
using System.Collections.Generic;

namespace DotNetCoreFrameWork.Entities.Contexts
{
    public partial class Book
    {
        public string Id { get; set; } = null!;
        public string? Booknm { get; set; }
        public string? Author { get; set; }
        public string? Status { get; set; }
        public string? Source { get; set; }
        public string? Folderid { get; set; }
    }
}
