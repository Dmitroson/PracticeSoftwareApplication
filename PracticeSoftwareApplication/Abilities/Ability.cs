using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSoftwareApplication.Abilities
{
    public abstract class Ability
    {
        protected abstract bool CheckAvailability();
    }
}