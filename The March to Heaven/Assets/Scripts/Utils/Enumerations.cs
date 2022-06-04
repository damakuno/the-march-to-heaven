using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enumerations
{
    public enum TimeOfDay { MORNING, AFTERNOON, EVENING }
    // TODO
    // not sure if we'll need Ending enums
    public enum Ending { None = 0, Bad = 1, Neutral = 2, Good = 3, True = 4 }

    #region NON-GAMEPLAY RELATED ENUMS
    public enum PhoneState { Minimized = 0, Peeking = 1, Active = 2 }
    public enum PhoneView { Notifs = 0, Home = 1, Mail = 2, MailOpen = 3, Calendar = 4 }

    #endregion
}
