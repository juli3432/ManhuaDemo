namespace Demo.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComicDetailImgae")]
    public partial class ComicDetailImgae
    {
        [Key]
        public int code { get; set; }

        public string link { get; set; }

        public int? codeComicDetail { get; set; }

        public virtual ComicDetail ComicDetail { get; set; }
    }
}
