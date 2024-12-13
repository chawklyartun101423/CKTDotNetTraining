using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKTDotNetTraining.Models
{
    public class BlogDapperDataModel
    {
        public int BlogId
        {
            get; set;   //Integer Default Value is Zero
        }
        public String BlogTitle
        {
            get;set;    //String Default Value is null
        }
        public String BlogAuthor
        {
            get; set;
        }
        public String BlogContent
        {
            get; set;
        }
    }

    [Table("Tbl_Blog")]
    public class BlogDataModel
    {
        [Key]
        [Column("BlogId")]
        public int BlogId
        {
            get; set;   //Integer Default Value is Zero
        }

        [Column("BlogTitle")]
        public String BlogTitle
        {
            get; set;    //String Default Value is null
        }

        [Column("BlogAuthor")]
        public String BlogAuthor
        {
            get; set;
        }

        [Column("BlogContent")]
        public String BlogContent
        {
            get; set;
        }
        [Column("DeleteFlag")]
        public bool DeleteFlag {  get; set; }

    }
}
