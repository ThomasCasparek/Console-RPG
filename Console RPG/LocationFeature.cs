using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
   abstract class LocationFeature
    {
        public bool isResloved;

        public LocationFeature(bool isResloved)
        {
            this.isResloved = isResloved;
        }
        public abstract void Resolve(List<Player> players);
    }
}
