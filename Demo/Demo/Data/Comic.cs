namespace Demo.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comic")]
    public partial class Comic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comic()
        {
            ComicDetails = new HashSet<ComicDetail>();
        }

        [Key]
        public int code { get; set; }

        public string link { get; set; }

        public string name { get; set; }

        public int? codeWebsite { get; set; }

        public virtual Website Website { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComicDetail> ComicDetails { get; set; }
    }
}
