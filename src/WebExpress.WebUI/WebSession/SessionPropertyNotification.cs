using System;
using System.Collections.Generic;
using WebExpress.WebCore.WebSession;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.WebUI.WebSession
{
    /// <summary>
    /// Collection of notifications.
    /// Key = The notification id.
    /// Value = The notification.
    /// </summary>
    public class SessionPropertyNotification : Dictionary<Guid, INotification>, ISessionProperty
    {
    }
}
