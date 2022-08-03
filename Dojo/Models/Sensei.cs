using System.Collections.Generic;
using System;

namespace Dojo.Models
{
  public class Sensei
  {
    public Sensei()
    {
      this.JoinEntities = new HashSet<DiscipleSensei>();
    }
    public int SenseiId { get; set; }
    public string Name { get; set; }
    public int MartialArtId { get; set; }
    public virtual ICollection<DiscipleSensei> JoinEntities { get; set; }
  }
}