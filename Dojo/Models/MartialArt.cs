using System.Collections.Generic;
using System;

namespace Dojo.Models
{
  public class MartialArt
  {
    public MartialArt()
    {
      this.Senseis = new HashSet<Sensei>();
    }
    public int MartialArtId { get; set; }
    public string Type { get; set; }
    public virtual ICollection<Sensei> Senseis { get; set; }
  }
}