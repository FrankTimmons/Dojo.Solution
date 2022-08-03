using System.Collections.Generic;

namespace Dojo.Models
{
  public class DiscipleSensei
  {
    public int DiscipleSenseiId { get; set; }
    public int DiscipleId { get; set; }
    public int SenseiId { get; set; }
    public virtual Disciple Disciple { get; set; }
    public virtual Sensei Sensei { get; set; }
  }
}