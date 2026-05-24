using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.DTOs;
public class Patient
{
    public int Id { get; set; }
    public string Navn { get; set; } = "";
    public string FoedselsDag { get; set; } = "";
    public string Cpr { get; set; } = "";
    public int LoyaltyScore { get; set; }
}
