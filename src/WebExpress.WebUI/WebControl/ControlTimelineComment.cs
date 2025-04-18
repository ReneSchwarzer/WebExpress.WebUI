//using System;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlTimelineComment : Control
//    {
//        /// <summary>
//        /// Liefert oder setzt das Avatarbild
//        /// </summary>
//        public Uri Image { get; set; }

//        /// <summary>
//        /// Returns or sets the name. des Users
//        /// </summary>
//        public string User { get; set; }

//        /// <summary>
//        /// Liefert oder setzt den Zeitstempel
//        /// </summary>
//        public DateTime Timestamp { get; set; }

//        /// <summary>
//        /// Returns or sets the text.
//        /// </summary>
//        public string Post { get; set; }

//        /// <summary>
//        /// Liefert oder setzt die Anzahl der Gefällt-mir-Angaben
//        /// </summary>
//        public int Likes { get; set; }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlTimelineComment(string id = null)
//            : base(id)
//        {
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <param name="visualTree">The visual tree representing the control's structure.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(IRenderContext context)
//        {
//            var profile = new ControlAvatar()
//            {
//                User = User,
//                Image = Image
//            };
//            var days = (DateTime.Now - Timestamp).Days;

//            string timespan;
//            if (days == 1)
//            {
//                timespan = "vor ein Tag";
//            }
//            else if (days < 1)
//            {
//                var hours = (DateTime.Now - Timestamp).Hours;
//                if (hours == 1)
//                {
//                    timespan = "vor einer Stunde";
//                }
//                else if (hours < 1)
//                {
//                    var minutes = (DateTime.Now - Timestamp).Minutes;

//                    if (minutes == 1)
//                    {
//                        timespan = "vor einer Minute";
//                    }
//                    else if (minutes < 1)
//                    {
//                        timespan = "gerade ebend";
//                    }
//                    else
//                    {
//                        timespan = "vor " + minutes + " Minuten";
//                    }
//                }
//                else
//                {
//                    timespan = "vor " + hours + " Stunden";
//                }
//            }
//            else
//            {
//                timespan = "vor " + days + " Tagen";
//            }

//            var date = new ControlText()
//            {
//                Text = timespan,
//                Title = "Am " + Timestamp.ToShortDateString() + " um " + Timestamp.ToShortTimeString() + " Uhr",
//                Format = TypeFormatText.Span,
//                TextColor = new PropertyColorText(TypeColorText.Muted)
//            };

//            var header = new HtmlElementTextContentDiv(profile.Render(context), date.Render(context))
//            {
//                Class = "header"
//            };

//            var body = new HtmlElementTextContentDiv(new HtmlText(Post))
//            {
//                Class = "post"
//            };

//            var likeText = "Gefällt mir" + (Likes > 0 ? " (" + Likes + ")" : string.Empty);

//            var like = new ControlButtonLink()
//            {
//                Icon = new PropertyIcon(TypeIcon.ThumbsUp),
//                Text = likeText,
//                Uri = context.Uri,
//                Size = TypeSizeButton.Small,
//                BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
//                Outline = true,
//                TextColor = new PropertyColorText(TypeColorText.Primary)
//            };

//            var option = new HtmlElementTextContentDiv(Likes > 0 ? like.Render(context) : null)
//            {
//                Class = "options"
//            };

//            var html = new HtmlElementTextContentDiv(header, body, option)
//            {
//                Class = Css.Concatenate("comment", GetClasses()),
//                Style = GetStyles(),
//                Role = Role
//            };

//            return html;
//        }
//    }
//}
