using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookSoft.Domain.Entities
{
    public class Person : AggregateRoot
    {
        public string FullName {  get; set; } = null!;
        public EmailAddressAttribute Email { get; set; } = null!; 
        public DateOnly birthday { get; set; }

    }
}
