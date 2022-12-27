using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proje2.Abstracts.Movements
{
    public interface IMover
    {
        void FixedTick(float direction);
    }
}

