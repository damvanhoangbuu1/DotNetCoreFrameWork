using System;
using System.Collections.Generic;

namespace DotNetCoreFrameWork.Entities.Contexts
{
    public partial class Chapter
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string Url { get; set; } = null!;
        public decimal Seq { get; set; }
        public string? Status { get; set; }
        public string? Fileid { get; set; }
        public string Bookid { get; set; } = null!;
    }
}
