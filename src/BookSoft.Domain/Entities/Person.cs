using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BookSoft.Domain.ValueObjects;

namespace BookSoft.Domain.Entities
{
    public class Person : AggregateRoot
    {
        public FullName FullName {  get; private set; } = null!;
        public string Email { get; private set; } = null!;
    }
}
