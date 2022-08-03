using System.Collections.Generic;
using System;

namespace Dojo.Models
{
  public class Disciple
  {
    public Disciple()
    {
      this.JoinEntities = new HashSet<DiscipleSensei>();
    }
    public int DiscipleId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<DiscipleSensei> JoinEntities { get; set; }
  }
}