namespace Demo.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComicDetail")]
    public partial class ComicDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComicDetail()
        {
            ComicDetailImgaes = new HashSet<ComicDetailImgae>();
        }

        [Key]
        public int code { get; set; }

        public string link { get; set; }

        public string name { get; set; }

        public int? codeComic { get; set; }

        public virtual Comic Comic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComicDetailImgae> ComicDetailImgaes { get; set; }
    }
}
