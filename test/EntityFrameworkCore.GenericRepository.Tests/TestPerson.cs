using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.GenericRepository.Models;

namespace EntityFrameworkCore.Tests
{
    public class TestPerson: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id {get;set;}
        public string firstName {get;set;}
        public string lastName {get;set;}
       
    }
}
 