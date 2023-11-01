namespace WebExpress.WebUI.Script
{
    public interface IScriptControl
    {
        /// <summary>
        /// Umwandlung in Javascript
        /// </summary>
        /// <returns>Das Javascript</returns>
        string ToScript();
    }
}
