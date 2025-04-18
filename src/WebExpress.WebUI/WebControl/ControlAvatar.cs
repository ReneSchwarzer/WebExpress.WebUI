﻿using System;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a control that displays a user's avatar, which can include an image or initials, and optionally a modal dialog.
    /// </summary>
    public class ControlAvatar : Control
    {
        /// <summary>
        /// Returns or sets the avatar image.
        /// </summary>
        public Uri Image { get; set; }

        /// <summary>
        /// Returns or sets the name of the user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Returns or sets the size.
        /// </summary>
        public TypeSizeButton Size
        {
            get => (TypeSizeButton)GetProperty(TypeSizeButton.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets a modal dialogue.
        /// </summary>
        public ControlModal Modal { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlAvatar(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var img = default(HtmlElement);

            if (Image != null)
            {
                img = new HtmlElementMultimediaImg() { Src = Image.ToString(), Class = "" };
            }
            else if (!string.IsNullOrWhiteSpace(User))
            {
                var split = User.Split(' ');
                var i = split[0].FirstOrDefault().ToString();
                i += split.Count() > 1 ? split[1].FirstOrDefault().ToString() : "";

                img = new HtmlElementTextSemanticsB(new HtmlText(i))
                {
                    Class = Css.Concatenate("bg-info text-light")
                };
            }

            var html = new HtmlElementTextContentDiv(img, new HtmlText(User))
            {
                Id = Id,
                Class = Css.Concatenate("wx-profile", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };

            if (Modal != null)
            {
                html.AddUserAttribute("data-bs-toggle", "modal");
                html.AddUserAttribute("data-bs-target", "#" + Modal.Id);

                return new HtmlList(html, Modal.Render(renderContext, visualTree));
            }

            return html;
        }
    }
}
