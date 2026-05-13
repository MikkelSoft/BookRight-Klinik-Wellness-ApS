using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BookSoft.Domain.ValueObjects;

namespace BookSoft.Domain.Entities
{
    public class Person : AggregateRoot
    {
        //removed private set as it seemed to not appear in the patient class prolly not the best fix but it works for now
        public FullName FullName {  get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
