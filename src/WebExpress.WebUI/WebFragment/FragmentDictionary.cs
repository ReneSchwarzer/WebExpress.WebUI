using System.Collections.Generic;
using WebExpress.Core.WebPlugin;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// component directory
    /// key = plugin context 
    /// value { key = section:context, value = component item }
    /// </summary>
    internal class FragmentDictionary : Dictionary<IPluginContext, FragmentDictionaryItem>
    {
    }
}
