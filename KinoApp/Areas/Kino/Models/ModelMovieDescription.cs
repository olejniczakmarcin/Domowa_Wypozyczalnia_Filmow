using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinoApp.Areas.Kino.Models
{
    public class ModelMovieDescription
    {
        public int MovieId { get; set; }
        public string Description { get; set; }
        public double? Time { get; set; }

        public int? Scale { get; set; }
    }
}