﻿using System.Collections.Generic;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Interface for a control.
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// Returns or sets the id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Returns or sets the horizontal alignment.
        /// </summary>
        TypeHorizontalAlignment HorizontalAlignment { get; set; }

        /// <summary>
        /// Returns or sets the text color.
        /// </summary>
        PropertyColorText TextColor { get; set; }

        /// <summary>
        /// Returns or sets the background color.
        /// </summary>
        PropertyColorBackground BackgroundColor { get; set; }

        /// <summary>
        /// Returns or sets the border color.
        /// </summary>
        PropertyColorBorder BorderColor { get; set; }

        /// <summary>
        /// Returns or sets the padding.
        /// </summary>
        PropertySpacingPadding Padding { get; set; }

        /// <summary>
        /// Returns or sets the margin.
        /// </summary>
        PropertySpacingMargin Margin { get; set; }

        /// <summary>
        /// Returns or sets the border.
        /// </summary>
        PropertyBorder Border { get; set; }

        /// <summary>
        /// Returns or sets the column property if the control is on a grid.
        /// </summary>
        PropertyGrid GridColumn { get; set; }

        /// <summary>
        /// Returns or sets the width property of the control.
        /// </summary>
        TypeWidth Width { get; set; }

        /// <summary>
        /// Returns or sets the height property of the control.
        /// </summary>
        TypeHeight Height { get; set; }

        /// <summary>
        /// Returns or sets the css class.
        /// </summary>
        List<string> Classes { get; set; }

        /// Returns or sets the css style.
        /// </summary>
        List<string> Styles { get; set; }

        /// <summary>
        /// Returns or sets the role.
        /// </summary>
        string Role { get; set; }

        /// <summary>
        /// Returns or sets the OnClick attribute, which executes a java script on the client.
        /// </summary>
        PropertyOnClick OnClick { get; set; }

        /// <summary>
        /// Determines whether the control is active and rendering.
        /// </summary>
        bool Enable { get; set; }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree);
    }
}
