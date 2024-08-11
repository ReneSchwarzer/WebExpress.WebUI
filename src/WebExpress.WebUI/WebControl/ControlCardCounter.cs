using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Informationszähler
    /// </summary>
    public class ControlCardCounter : ControlPanelCard
    {
        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon Icon { get; set; }

        /// <summary>
        /// Returns or sets the value. des Counters
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Returns or sets the value of the progrss.
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlCardCounter(string id = null)
            : base(id)
        {
            TextColor = new PropertyColorText(TypeColorText.Default);
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Progress = -1;
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            Content.Clear();

            if (Icon != null && Icon.HasIcon)
            {
                Content.Add(new ControlIcon()
                {
                    Icon = Icon,
                    TextColor = TextColor,
                    HorizontalAlignment = TypeHorizontalAlignment.Right
                });
            }

            var text = new ControlText(string.IsNullOrWhiteSpace(Id) ? null : Id + "_header")
            {
                Text = Value,
                Format = TypeFormatText.H4
            };

            var info = new ControlText()
            {
                Text = Text,
                Format = TypeFormatText.Span,
                TextColor = new PropertyColorText(TypeColorText.Muted)
            };

            Content.Add(new ControlPanel(text, info) { });

            if (Progress > -1)
            {
                Content.Add(new ControlProgressBar()
                {
                    Value = Progress,
                    Format = TypeFormatProgress.Striped,
                    BackgroundColor = BackgroundColor,
                    //Color = Color,
                    Size = TypeSizeProgress.Small
                });
            }

            return base.Render(context);
        }
    }
}
