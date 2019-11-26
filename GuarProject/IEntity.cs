using System;
using System.Collections.Generic;
using System.Text;

namespace GuarProject
{
    public interface IEntity
    {
        int Health { get; set; }
        int Damage { get; set; }
        int Perception { get; set; }
        int ID { get; set; }
        int Intelligence { get; set; }
        int Energy { get; set; }
    }
}
